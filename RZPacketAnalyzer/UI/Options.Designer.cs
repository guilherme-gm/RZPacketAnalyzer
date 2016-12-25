namespace RZPacketAnalyzer.UI
{
    partial class Options
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txt_AuthIp = new System.Windows.Forms.TextBox();
            this.txt_AuthPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_ClientPort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_ClientIp = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grid_CustomSettings = new System.Windows.Forms.DataGridView();
            this.btn_Save = new System.Windows.Forms.Button();
            this.col_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_CustomSettings)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Auth IP:";
            // 
            // txt_AuthIp
            // 
            this.txt_AuthIp.Location = new System.Drawing.Point(63, 38);
            this.txt_AuthIp.Name = "txt_AuthIp";
            this.txt_AuthIp.Size = new System.Drawing.Size(114, 20);
            this.txt_AuthIp.TabIndex = 1;
            // 
            // txt_AuthPort
            // 
            this.txt_AuthPort.Location = new System.Drawing.Point(263, 38);
            this.txt_AuthPort.Name = "txt_AuthPort";
            this.txt_AuthPort.Size = new System.Drawing.Size(70, 20);
            this.txt_AuthPort.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(203, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Auth Port:";
            // 
            // txt_ClientPort
            // 
            this.txt_ClientPort.Location = new System.Drawing.Point(263, 12);
            this.txt_ClientPort.Name = "txt_ClientPort";
            this.txt_ClientPort.Size = new System.Drawing.Size(70, 20);
            this.txt_ClientPort.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(199, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Client Port:";
            // 
            // txt_ClientIp
            // 
            this.txt_ClientIp.Location = new System.Drawing.Point(63, 12);
            this.txt_ClientIp.Name = "txt_ClientIp";
            this.txt_ClientIp.Size = new System.Drawing.Size(114, 20);
            this.txt_ClientIp.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Client IP:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grid_CustomSettings);
            this.groupBox1.Location = new System.Drawing.Point(12, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(460, 330);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Custom Settings";
            // 
            // grid_CustomSettings
            // 
            this.grid_CustomSettings.AllowUserToAddRows = false;
            this.grid_CustomSettings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid_CustomSettings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_CustomSettings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_Name,
            this.col_Value});
            this.grid_CustomSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_CustomSettings.Location = new System.Drawing.Point(3, 16);
            this.grid_CustomSettings.Name = "grid_CustomSettings";
            this.grid_CustomSettings.Size = new System.Drawing.Size(454, 311);
            this.grid_CustomSettings.TabIndex = 0;
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(394, 15);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 9;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // col_Name
            // 
            this.col_Name.HeaderText = "Name";
            this.col_Name.Name = "col_Name";
            this.col_Name.ReadOnly = true;
            // 
            // col_Value
            // 
            this.col_Value.HeaderText = "Value";
            this.col_Value.Name = "col_Value";
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 418);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txt_ClientPort);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_ClientIp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_AuthPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_AuthIp);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Options";
            this.ShowIcon = false;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Options_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_CustomSettings)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_AuthIp;
        private System.Windows.Forms.TextBox txt_AuthPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_ClientPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_ClientIp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView grid_CustomSettings;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Value;
    }
}