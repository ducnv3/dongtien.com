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
            this.btn_save_config = new System.Windows.Forms.Button();
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_stop = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbtn_not_sync = new System.Windows.Forms.RadioButton();
            this.rbtn_sync = new System.Windows.Forms.RadioButton();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.col_source = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_destination = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPath)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            // btn_save_config
            // 
            this.btn_save_config.Location = new System.Drawing.Point(83, 465);
            this.btn_save_config.Name = "btn_save_config";
            this.btn_save_config.Size = new System.Drawing.Size(126, 29);
            this.btn_save_config.TabIndex = 1;
            this.btn_save_config.Text = "Lưu cấu hình";
            this.btn_save_config.UseVisualStyleBackColor = true;
            this.btn_save_config.Click += new System.EventHandler(this.btn_save_config_Click);
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(257, 466);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(115, 28);
            this.btn_start.TabIndex = 2;
            this.btn_start.Text = "Bắt đầu";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // btn_stop
            // 
            this.btn_stop.Location = new System.Drawing.Point(427, 466);
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
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
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
            this.groupBox2.Location = new System.Drawing.Point(18, 371);
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
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 507);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_stop);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.btn_save_config);
            this.Name = "ServerForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPath)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
    }
}

