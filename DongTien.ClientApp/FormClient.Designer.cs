namespace DongTien.ClientApp
{
    partial class FormClient
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormClient));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Txt_IpServer = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Txt_Password = new System.Windows.Forms.TextBox();
            this.Txt_Username = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gridviewPath = new System.Windows.Forms.DataGridView();
            this.col_source = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_destination = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbtn_notsync = new System.Windows.Forms.RadioButton();
            this.btn_ASyncFiles = new System.Windows.Forms.Button();
            this.rbtn_sync = new System.Windows.Forms.RadioButton();
            this.btn_saveConfig = new System.Windows.Forms.Button();
            this.btn_start = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.btn_stop = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPathServer = new System.Windows.Forms.TextBox();
            this.btnCreateMapFolderAuto = new System.Windows.Forms.Button();
            this.btnOpenDialogFolder = new System.Windows.Forms.Button();
            this.txtPathLocalToMap = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridviewPath)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Txt_IpServer);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.Txt_Password);
            this.groupBox1.Controls.Add(this.Txt_Username);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(10, 6);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(548, 134);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tài khoản xác thực";
            // 
            // Txt_IpServer
            // 
            this.Txt_IpServer.Location = new System.Drawing.Point(106, 76);
            this.Txt_IpServer.Margin = new System.Windows.Forms.Padding(2);
            this.Txt_IpServer.Name = "Txt_IpServer";
            this.Txt_IpServer.Size = new System.Drawing.Size(425, 20);
            this.Txt_IpServer.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 80);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "IP Server";
            // 
            // Txt_Password
            // 
            this.Txt_Password.Location = new System.Drawing.Point(106, 52);
            this.Txt_Password.Margin = new System.Windows.Forms.Padding(2);
            this.Txt_Password.Name = "Txt_Password";
            this.Txt_Password.PasswordChar = '*';
            this.Txt_Password.Size = new System.Drawing.Size(425, 20);
            this.Txt_Password.TabIndex = 3;
            // 
            // Txt_Username
            // 
            this.Txt_Username.Location = new System.Drawing.Point(106, 25);
            this.Txt_Username.Margin = new System.Windows.Forms.Padding(2);
            this.Txt_Username.Name = "Txt_Username";
            this.Txt_Username.Size = new System.Drawing.Size(425, 20);
            this.Txt_Username.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 54);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mật khẩu";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên tài khoản";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox2.Controls.Add(this.gridviewPath);
            this.groupBox2.Location = new System.Drawing.Point(10, 144);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(909, 347);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cấu hình đường dẫn";
            // 
            // gridviewPath
            // 
            this.gridviewPath.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridviewPath.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridviewPath.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_source,
            this.col_destination,
            this.col_description});
            this.gridviewPath.Location = new System.Drawing.Point(8, 17);
            this.gridviewPath.Margin = new System.Windows.Forms.Padding(2);
            this.gridviewPath.Name = "gridviewPath";
            this.gridviewPath.RowTemplate.Height = 24;
            this.gridviewPath.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridviewPath.Size = new System.Drawing.Size(889, 315);
            this.gridviewPath.TabIndex = 0;
            // 
            // col_source
            // 
            this.col_source.HeaderText = "Nguồn";
            this.col_source.Name = "col_source";
            this.col_source.Width = 350;
            // 
            // col_destination
            // 
            this.col_destination.HeaderText = "Đích";
            this.col_destination.Name = "col_destination";
            this.col_destination.Width = 350;
            // 
            // col_description
            // 
            this.col_description.HeaderText = "Mô tả";
            this.col_description.Name = "col_description";
            this.col_description.Width = 300;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbtn_notsync);
            this.groupBox3.Controls.Add(this.btn_ASyncFiles);
            this.groupBox3.Controls.Add(this.rbtn_sync);
            this.groupBox3.Location = new System.Drawing.Point(574, 11);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(332, 67);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Cấu hình đồng bộ";
            // 
            // rbtn_notsync
            // 
            this.rbtn_notsync.AutoSize = true;
            this.rbtn_notsync.Location = new System.Drawing.Point(115, 25);
            this.rbtn_notsync.Margin = new System.Windows.Forms.Padding(2);
            this.rbtn_notsync.Name = "rbtn_notsync";
            this.rbtn_notsync.Size = new System.Drawing.Size(99, 17);
            this.rbtn_notsync.TabIndex = 1;
            this.rbtn_notsync.TabStop = true;
            this.rbtn_notsync.Text = "Không đồng bộ";
            this.rbtn_notsync.UseVisualStyleBackColor = true;
            this.rbtn_notsync.CheckedChanged += new System.EventHandler(this.rbtn_notsync_CheckedChanged);
            // 
            // btn_ASyncFiles
            // 
            this.btn_ASyncFiles.Location = new System.Drawing.Point(219, 18);
            this.btn_ASyncFiles.Name = "btn_ASyncFiles";
            this.btn_ASyncFiles.Size = new System.Drawing.Size(99, 30);
            this.btn_ASyncFiles.TabIndex = 6;
            this.btn_ASyncFiles.Text = "Bắt đầu đồng bộ";
            this.btn_ASyncFiles.UseVisualStyleBackColor = true;
            this.btn_ASyncFiles.Click += new System.EventHandler(this.ASyncFiles_Click);
            // 
            // rbtn_sync
            // 
            this.rbtn_sync.AutoSize = true;
            this.rbtn_sync.Location = new System.Drawing.Point(16, 25);
            this.rbtn_sync.Margin = new System.Windows.Forms.Padding(2);
            this.rbtn_sync.Name = "rbtn_sync";
            this.rbtn_sync.Size = new System.Drawing.Size(81, 17);
            this.rbtn_sync.TabIndex = 0;
            this.rbtn_sync.TabStop = true;
            this.rbtn_sync.Text = "Có đồng bộ";
            this.rbtn_sync.UseVisualStyleBackColor = true;
            this.rbtn_sync.CheckedChanged += new System.EventHandler(this.rbtn_sync_CheckedChanged);
            // 
            // btn_saveConfig
            // 
            this.btn_saveConfig.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_saveConfig.Location = new System.Drawing.Point(189, 0);
            this.btn_saveConfig.Margin = new System.Windows.Forms.Padding(2);
            this.btn_saveConfig.Name = "btn_saveConfig";
            this.btn_saveConfig.Size = new System.Drawing.Size(99, 29);
            this.btn_saveConfig.TabIndex = 3;
            this.btn_saveConfig.Text = "Lưu cấu hình";
            this.btn_saveConfig.UseVisualStyleBackColor = true;
            this.btn_saveConfig.Click += new System.EventHandler(this.btn_saveConfig_Click);
            // 
            // btn_start
            // 
            this.btn_start.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_start.Location = new System.Drawing.Point(0, 0);
            this.btn_start.Margin = new System.Windows.Forms.Padding(2);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(90, 29);
            this.btn_start.TabIndex = 4;
            this.btn_start.Text = "Bắt đầu";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "notifyIcon1";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // btn_stop
            // 
            this.btn_stop.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_stop.Location = new System.Drawing.Point(90, 0);
            this.btn_stop.Margin = new System.Windows.Forms.Padding(2);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(99, 29);
            this.btn_stop.TabIndex = 5;
            this.btn_stop.Text = "Kết thúc";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(847, 528);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Chờ đồng bộ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_saveConfig);
            this.panel1.Controls.Add(this.btn_stop);
            this.panel1.Controls.Add(this.btn_start);
            this.panel1.Location = new System.Drawing.Point(574, 86);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(332, 29);
            this.panel1.TabIndex = 1;
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.ShowNewFolderButton = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(2, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(932, 522);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(924, 496);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Chức năng chính";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.txtPathServer);
            this.tabPage2.Controls.Add(this.btnCreateMapFolderAuto);
            this.tabPage2.Controls.Add(this.btnOpenDialogFolder);
            this.tabPage2.Controls.Add(this.txtPathLocalToMap);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(924, 496);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Map bổ sung";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(166, 53);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(363, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Ví dụ: C:\\Users\\ducnv3\\Desktop\\Phong Thi Cong\\boc chi phi";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(166, 98);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(209, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Ví dụ: Phong Thi Cong\\Boc Chi Phi";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 78);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Đường dẫn đích cần map";
            // 
            // txtPathServer
            // 
            this.txtPathServer.Location = new System.Drawing.Point(169, 76);
            this.txtPathServer.Margin = new System.Windows.Forms.Padding(2);
            this.txtPathServer.Name = "txtPathServer";
            this.txtPathServer.Size = new System.Drawing.Size(392, 20);
            this.txtPathServer.TabIndex = 13;
            // 
            // btnCreateMapFolderAuto
            // 
            this.btnCreateMapFolderAuto.Location = new System.Drawing.Point(469, 111);
            this.btnCreateMapFolderAuto.Name = "btnCreateMapFolderAuto";
            this.btnCreateMapFolderAuto.Size = new System.Drawing.Size(92, 29);
            this.btnCreateMapFolderAuto.TabIndex = 12;
            this.btnCreateMapFolderAuto.Text = "Thực hiện";
            this.btnCreateMapFolderAuto.UseVisualStyleBackColor = true;
            this.btnCreateMapFolderAuto.Click += new System.EventHandler(this.btnCreateMapFolderAuto_Click);
            // 
            // btnOpenDialogFolder
            // 
            this.btnOpenDialogFolder.Location = new System.Drawing.Point(567, 29);
            this.btnOpenDialogFolder.Name = "btnOpenDialogFolder";
            this.btnOpenDialogFolder.Size = new System.Drawing.Size(27, 20);
            this.btnOpenDialogFolder.TabIndex = 11;
            this.btnOpenDialogFolder.Text = "...";
            this.btnOpenDialogFolder.UseVisualStyleBackColor = true;
            this.btnOpenDialogFolder.Click += new System.EventHandler(this.btnOpenDialogFolder_Click);
            // 
            // txtPathLocalToMap
            // 
            this.txtPathLocalToMap.Enabled = false;
            this.txtPathLocalToMap.Location = new System.Drawing.Point(169, 29);
            this.txtPathLocalToMap.Margin = new System.Windows.Forms.Padding(2);
            this.txtPathLocalToMap.Name = "txtPathLocalToMap";
            this.txtPathLocalToMap.Size = new System.Drawing.Size(392, 20);
            this.txtPathLocalToMap.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 32);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Đường dẫn nguồn cần map";
            // 
            // FormClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 548);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormClient";
            this.Text = "Sync And Share";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridviewPath)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox Txt_Username;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView gridviewPath;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbtn_notsync;
        private System.Windows.Forms.RadioButton rbtn_sync;
        private System.Windows.Forms.Button btn_saveConfig;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.TextBox Txt_Password;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Txt_IpServer;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_source;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_destination;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_description;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.Button btn_ASyncFiles;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPathServer;
        private System.Windows.Forms.Button btnCreateMapFolderAuto;
        private System.Windows.Forms.Button btnOpenDialogFolder;
        private System.Windows.Forms.TextBox txtPathLocalToMap;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}

