using RZPacketAnalyzer.DataClasses;
using RZPacketAnalyzer.Utils;
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
                Instance.grid_Packets.Rows[i].Cells[6].Value = ""; // Hex
            }));
        }
    }
}
