namespace DongTien.ServerApp
{
    partial class ServerForm
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
            this.gridViewPath = new System.Windows.Forms.DataGridView();
            this.col_source = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_destination = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_save_config = new System.Windows.Forms.Button();
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_stop = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbtn_not_sync = new System.Windows.Forms.RadioButton();
            this.rbtn_sync = new System.Windows.Forms.RadioButton();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gridAllowPath = new System.Windows.Forms.DataGridView();
            this.col_directory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_save_allow_path = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPath)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAllowPath)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridViewPath
            // 
            this.gridViewPath.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridViewPath.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_source,
            this.col_destination});
            this.gridViewPath.Location = new System.Drawing.Point(6, 21);
            this.gridViewPath.Name = "gridViewPath";
            this.gridViewPath.RowTemplate.Height = 24;
            this.gridViewPath.Size = new System.Drawing.Size(772, 313);
            this.gridViewPath.TabIndex = 0;
            // 
            // col_source
            // 
            this.col_source.HeaderText = "Nguồn";
            this.col_source.Name = "col_source";
            this.col_source.Width = 300;
            // 
            // col_destination
            // 
            this.col_destination.HeaderText = "Đích";
            this.col_destination.Name = "col_destination";
            this.col_destination.Width = 300;
            // 
            // btn_save_config
            // 
            this.btn_save_config.Location = new System.Drawing.Point(74, 472);
            this.btn_save_config.Name = "btn_save_config";
            this.btn_save_config.Size = new System.Drawing.Size(126, 29);
            this.btn_save_config.TabIndex = 1;
            this.btn_save_config.Text = "Lưu cấu hình";
            this.btn_save_config.UseVisualStyleBackColor = true;
            this.btn_save_config.Click += new System.EventHandler(this.btn_save_config_Click);
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(248, 473);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(115, 28);
            this.btn_start.TabIndex = 2;
            this.btn_start.Text = "Bắt đầu";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // btn_stop
            // 
            this.btn_stop.Location = new System.Drawing.Point(418, 473);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(102, 28);
            this.btn_stop.TabIndex = 3;
            this.btn_stop.Text = "Kết thúc";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gridViewPath);
            this.groupBox1.Location = new System.Drawing.Point(3, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(784, 343);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cấu hình đường dẫn";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbtn_not_sync);
            this.groupBox2.Controls.Add(this.rbtn_sync);
            this.groupBox2.Location = new System.Drawing.Point(9, 378);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(778, 57);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cấu hình đồng bộ";
            // 
            // rbtn_not_sync
            // 
            this.rbtn_not_sync.AutoSize = true;
            this.rbtn_not_sync.Location = new System.Drawing.Point(203, 22);
            this.rbtn_not_sync.Name = "rbtn_not_sync";
            this.rbtn_not_sync.Size = new System.Drawing.Size(126, 21);
            this.rbtn_not_sync.TabIndex = 1;
            this.rbtn_not_sync.TabStop = true;
            this.rbtn_not_sync.Text = "Không đồng bộ";
            this.rbtn_not_sync.UseVisualStyleBackColor = true;
            // 
            // rbtn_sync
            // 
            this.rbtn_sync.AutoSize = true;
            this.rbtn_sync.Location = new System.Drawing.Point(20, 22);
            this.rbtn_sync.Name = "rbtn_sync";
            this.rbtn_sync.Size = new System.Drawing.Size(83, 21);
            this.rbtn_sync.TabIndex = 0;
            this.rbtn_sync.TabStop = true;
            this.rbtn_sync.Text = "Đồng bộ";
            this.rbtn_sync.UseVisualStyleBackColor = true;
            // 
            // notifyIcon
            // 
            this.notifyIcon.Text = "notifyIcon1";
            this.notifyIcon.Visible = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(817, 543);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.btn_save_config);
            this.tabPage1.Controls.Add(this.btn_start);
            this.tabPage1.Controls.Add(this.btn_stop);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(809, 514);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Cầu hình đường dẫn";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btn_save_allow_path);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(809, 514);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Các đường dẫn cho phép";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // gridAllowPath
            // 
            this.gridAllowPath.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAllowPath.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_directory});
            this.gridAllowPath.Location = new System.Drawing.Point(6, 30);
            this.gridAllowPath.Name = "gridAllowPath";
            this.gridAllowPath.RowTemplate.Height = 24;
            this.gridAllowPath.Size = new System.Drawing.Size(785, 381);
            this.gridAllowPath.TabIndex = 0;
            // 
            // col_directory
            // 
            this.col_directory.HeaderText = "Danh sách các đường dẫn";
            this.col_directory.Name = "col_directory";
            this.col_directory.Width = 400;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.gridAllowPath);
            this.groupBox3.Location = new System.Drawing.Point(6, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(797, 429);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Cấu hình đường dẫn";
            // 
            // btn_save_allow_path
            // 
            this.btn_save_allow_path.Location = new System.Drawing.Point(64, 464);
            this.btn_save_allow_path.Name = "btn_save_allow_path";
            this.btn_save_allow_path.Size = new System.Drawing.Size(160, 29);
            this.btn_save_allow_path.TabIndex = 2;
            this.btn_save_allow_path.Text = "Save ";
            this.btn_save_allow_path.UseVisualStyleBackColor = true;
            this.btn_save_allow_path.Click += new System.EventHandler(this.btn_save_allow_path_Click);
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 560);
            this.Controls.Add(this.tabControl1);
            this.Name = "ServerForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPath)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAllowPath)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridViewPath;
        private System.Windows.Forms.Button btn_save_config;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbtn_not_sync;
        private System.Windows.Forms.RadioButton rbtn_sync;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_source;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_destination;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView gridAllowPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_directory;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_save_allow_path;
    }
}

