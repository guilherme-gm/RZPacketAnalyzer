using Newtonsoft.Json;
using RZPacketAnalyzer.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RZPacketAnalyzer.UI
{
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();
        }

        private void Options_Load(object sender, EventArgs e)
        {
            SettingsReader reader = new SettingsReader();
            reader.LoadSettings("Data/custom.json");
            Dictionary<string, string> customSettings = (Dictionary<string, string>) reader.ReadObject("settings", typeof(Dictionary<string, string>));

            this.txt_ClientIp.Text = Settings.ClientIp;
            this.txt_ClientPort.Text = Settings.ClientPort;
            this.txt_AuthIp.Text = Settings.AuthIp;
            this.txt_AuthPort.Text = Settings.AuthPort;

            this.grid_CustomSettings.Rows.Clear();
            foreach(string key in Settings.Variables.Keys)
            {
                if (customSettings.ContainsKey(key))
                {
                    customSettings.Remove(key);
                }
                this.grid_CustomSettings.Rows.Add(key, Settings.Variables[key]);
            }

            foreach (string key in customSettings.Keys)
            {
                this.grid_CustomSettings.Rows.Add(key, customSettings[key]);
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> settings = new Dictionary<string, object>();
            settings.Add("client_ip", txt_ClientIp.Text);
            settings.Add("client_port", txt_ClientPort.Text);
            settings.Add("auth_ip", txt_AuthIp.Text);
            settings.Add("auth_port", txt_AuthPort.Text);

            Dictionary<string, string> custom = new Dictionary<string, string>();
            
            for (int i = 0; i < grid_CustomSettings.Rows.Count; i++)
            {
                custom.Add(
                    grid_CustomSettings.Rows[i].Cells[0].Value.ToString(),
                    grid_CustomSettings.Rows[i].Cells[1].Value.ToString()
                );
            }

            settings.Add("custom", custom);

            string json = JsonConvert.SerializeObject(settings);
            File.WriteAllText("settings.json", json);

            MessageBox.Show("Done.");
        }
    }
}
