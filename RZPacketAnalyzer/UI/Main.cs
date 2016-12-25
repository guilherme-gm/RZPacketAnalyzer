using Common.DataClasses;
using RZPacketAnalyzer.DataClasses;
using RZPacketAnalyzer.Utils;
using RZPacketAnalyzer.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RZPacketAnalyzer.UI
{
    public partial class Main : Form
    {
        private static Main Instance;
        public static bool IsPaused { get; set; }

        public static Session Auth { get; set; }
        public static Session Game { get; set; }
        public static Session Client { get; set; }

        public static SocketService AuthSocket { get; set; }
        public static SocketService GameSocket { get; set; }
        public static SocketService ClientSocket { get; set; }

        public Main()
        {
            InitializeComponent();
            Instance = this;
            IsPaused = false;
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void btn_Options_Click(object sender, EventArgs e)
        {
            Options options = new Options();
            options.Show();
        }

        private void btn_StartStop_Click(object sender, EventArgs e)
        {
            RequestParser.Load();

            AuthSocket = new SocketService(Settings.AuthIp, ushort.Parse(Settings.AuthPort), true, new AuthFactory(), new AuthClientController());
            AuthSocket.StartConnection();
            
            ClientSocket = new SocketService(Settings.ClientIp, ushort.Parse(Settings.ClientPort), true, new ClientFactory(), new ClientAuthController());
            ClientSocket.StartListening();
        }

        public static void OnPacketReceive(PacketInfo info)
        {
            if (IsPaused) return;

            string dir = "??";
            Color rowColor = Color.White;

            switch (info._Type)
            {
                case RequestType.ClientAuth:
                    dir = "CA";
                    rowColor = Color.LightBlue;
                    break;
                case RequestType.AuthClient:
                    dir = "AC";
                    rowColor = Color.LightGreen;
                    break;
                case RequestType.ClientGame:
                    dir = "CG";
                    rowColor = Color.LightBlue;
                    break;
                case RequestType.GameClient:
                    dir = "CG";
                    rowColor = Color.LightGreen;
                    break;
            }

            Instance.Invoke(new MethodInvoker(delegate
            {
                int i = Instance.grid_Packets.Rows.Add();
                Instance.grid_Packets.Rows[i].DefaultCellStyle.BackColor = rowColor;
                Instance.grid_Packets.Rows[i].Cells[0].Value = dir;
                Instance.grid_Packets.Rows[i].Cells[1].Value = "0x" + info.PacketId.ToString("X4");
                Instance.grid_Packets.Rows[i].Cells[2].Value = info.Name;
                Instance.grid_Packets.Rows[i].Cells[3].Value = info.Data.Length;
                Instance.grid_Packets.Rows[i].Cells[4].Value = info.Data;
                Instance.grid_Packets.Rows[i].Cells[5].Value = info.Struct;
            }));
        }

        private void grid_Packets_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                richText_Struct.Text = (string) grid_Packets.Rows[e.RowIndex].Cells[5].Value;
                richText_Hex.Text = HexDump((byte[])grid_Packets.Rows[e.RowIndex].Cells[4].Value);
            }
        }

        public static string HexDump(byte[] bytes, int bytesPerLine = 16)
        {
            if (bytes == null)
            {
                return "";
            }

            int bytesLength = bytes.Length;

            char[] HexChars = "0123456789ABCDEF".ToCharArray();

            int firstCharColumn =
                 bytesPerLine * 3       // - 2 digit for the hexadecimal value and 1 space
                 + (bytesPerLine - 1) / 8; // - 1 extra space every 8 characters from the 9th

            int lineLength = firstCharColumn
                + Environment.NewLine.Length; // Carriage return and line feed (should normally be 2)

            char[] line = (new String(' ', lineLength - 2) + Environment.NewLine).ToCharArray();
            int expectedLines = (bytesLength + bytesPerLine - 1) / bytesPerLine;
            StringBuilder result = new StringBuilder(expectedLines * lineLength);

            for (int i = 0; i < bytesLength; i += bytesPerLine)
            {
                int hexColumn = 0;

                for (int j = 0; j < bytesPerLine; j++)
                {
                    if (j > 0 && (j & 7) == 0) hexColumn++;
                    if (i + j >= bytesLength)
                    {
                        line[hexColumn] = ' ';
                        line[hexColumn + 1] = ' ';
                    }
                    else
                    {
                        byte b = bytes[i + j];
                        line[hexColumn] = HexChars[(b >> 4) & 0xF];
                        line[hexColumn + 1] = HexChars[b & 0xF];
                    }
                    hexColumn += 3;
                }
                result.Append(line);
            }

            return result.ToString();
        }
    }
}
