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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Txt_Password = new System.Windows.Forms.TextBox();
            this.Txt_Username = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gridviewPath = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbtn_notsync = new System.Windows.Forms.RadioButton();
            this.rbtn_sync = new System.Windows.Forms.RadioButton();
            this.btn_saveConfig = new System.Windows.Forms.Button();
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_stop = new System.Windows.Forms.Button();
            this.col_source = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_destination = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridviewPath)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Txt_Password);
            this.groupBox1.Controls.Add(this.Txt_Username);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(752, 102);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tài khoản xác thực";
            // 
            // Txt_Password
            // 
            this.Txt_Password.Location = new System.Drawing.Point(142, 64);
            this.Txt_Password.Name = "Txt_Password";
            this.Txt_Password.Size = new System.Drawing.Size(565, 22);
            this.Txt_Password.TabIndex = 3;
            // 
            // Txt_Username
            // 
            this.Txt_Username.Location = new System.Drawing.Point(142, 31);
            this.Txt_Username.Name = "Txt_Username";
            this.Txt_Username.Size = new System.Drawing.Size(565, 22);
            this.Txt_Username.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mật khẩu";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên tài khoản";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gridviewPath);
            this.groupBox2.Location = new System.Drawing.Point(13, 125);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(751, 269);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cấu hình đường dẫn";
            // 
            // gridviewPath
            // 
            this.gridviewPath.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridviewPath.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_source,
            this.col_destination});
            this.gridviewPath.Location = new System.Drawing.Point(10, 21);
            this.gridviewPath.Name = "gridviewPath";
            this.gridviewPath.RowTemplate.Height = 24;
            this.gridviewPath.Size = new System.Drawing.Size(735, 233);
            this.gridviewPath.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbtn_notsync);
            this.groupBox3.Controls.Add(this.rbtn_sync);
            this.groupBox3.Location = new System.Drawing.Point(13, 409);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(751, 66);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Cấu hình đồng bộ";
            // 
            // rbtn_notsync
            // 
            this.rbtn_notsync.AutoSize = true;
            this.rbtn_notsync.Location = new System.Drawing.Point(237, 31);
            this.rbtn_notsync.Name = "rbtn_notsync";
            this.rbtn_notsync.Size = new System.Drawing.Size(126, 21);
            this.rbtn_notsync.TabIndex = 1;
            this.rbtn_notsync.TabStop = true;
            this.rbtn_notsync.Text = "Không đồng bộ";
            this.rbtn_notsync.UseVisualStyleBackColor = true;
            // 
            // rbtn_sync
            // 
            this.rbtn_sync.AutoSize = true;
            this.rbtn_sync.Location = new System.Drawing.Point(21, 31);
            this.rbtn_sync.Name = "rbtn_sync";
            this.rbtn_sync.Size = new System.Drawing.Size(102, 21);
            this.rbtn_sync.TabIndex = 0;
            this.rbtn_sync.TabStop = true;
            this.rbtn_sync.Text = "Có đồng bộ";
            this.rbtn_sync.UseVisualStyleBackColor = true;
            // 
            // btn_saveConfig
            // 
            this.btn_saveConfig.Location = new System.Drawing.Point(244, 491);
            this.btn_saveConfig.Name = "btn_saveConfig";
            this.btn_saveConfig.Size = new System.Drawing.Size(132, 26);
            this.btn_saveConfig.TabIndex = 3;
            this.btn_saveConfig.Text = "Lưu cấu hình";
            this.btn_saveConfig.UseVisualStyleBackColor = true;
            this.btn_saveConfig.Click += new System.EventHandler(this.btn_saveConfig_Click);
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(402, 491);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(98, 26);
            this.btn_start.TabIndex = 4;
            this.btn_start.Text = "Bắt đầu";
            this.btn_start.UseVisualStyleBackColor = true;
            // 
            // btn_stop
            // 
            this.btn_stop.Location = new System.Drawing.Point(522, 491);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(99, 26);
            this.btn_stop.TabIndex = 5;
            this.btn_stop.Text = "Kết thúc";
            this.btn_stop.UseVisualStyleBackColor = true;
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
            // FormClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 542);
            this.Controls.Add(this.btn_stop);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.btn_saveConfig);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormClient";
            this.Text = "Sync And Share";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridviewPath)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox Txt_Password;
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
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_source;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_destination;
    }
}

