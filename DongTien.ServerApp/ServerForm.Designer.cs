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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerForm));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gridViewPath = new System.Windows.Forms.DataGridView();
            this.col_source = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_destination = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rbtn_not_sync = new System.Windows.Forms.RadioButton();
            this.rbtn_sync = new System.Windows.Forms.RadioButton();
            this.btn_save_config = new System.Windows.Forms.Button();
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_stop = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPath)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "notifyIcon1";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gridViewPath);
            this.groupBox1.Location = new System.Drawing.Point(9, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(770, 353);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cấu hình đường dẫn";
            // 
            // gridViewPath
            // 
            this.gridViewPath.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridViewPath.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_source,
            this.col_destination,
            this.col_note});
            this.gridViewPath.Location = new System.Drawing.Point(4, 17);
            this.gridViewPath.Margin = new System.Windows.Forms.Padding(2);
            this.gridViewPath.Name = "gridViewPath";
            this.gridViewPath.RowTemplate.Height = 24;
            this.gridViewPath.Size = new System.Drawing.Size(758, 321);
            this.gridViewPath.TabIndex = 0;
            // 
            // col_source
            // 
            this.col_source.HeaderText = "Nguồn";
            this.col_source.Name = "col_source";
            this.col_source.Width = 400;
            // 
            // col_destination
            // 
            this.col_destination.HeaderText = "Đích";
            this.col_destination.Name = "col_destination";
            this.col_destination.Width = 400;
            // 
            // col_note
            // 
            this.col_note.HeaderText = "Ghi chú";
            this.col_note.Name = "col_note";
            this.col_note.Width = 400;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Controls.Add(this.rbtn_not_sync);
            this.groupBox2.Controls.Add(this.rbtn_sync);
            this.groupBox2.Location = new System.Drawing.Point(9, 367);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(765, 70);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cấu hình đồng bộ";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dataGridView1.Location = new System.Drawing.Point(-4, -252);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(579, 247);
            this.dataGridView1.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Nguồn";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 300;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Đích";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 300;
            // 
            // rbtn_not_sync
            // 
            this.rbtn_not_sync.AutoSize = true;
            this.rbtn_not_sync.Location = new System.Drawing.Point(149, 27);
            this.rbtn_not_sync.Margin = new System.Windows.Forms.Padding(2);
            this.rbtn_not_sync.Name = "rbtn_not_sync";
            this.rbtn_not_sync.Size = new System.Drawing.Size(99, 17);
            this.rbtn_not_sync.TabIndex = 1;
            this.rbtn_not_sync.TabStop = true;
            this.rbtn_not_sync.Text = "Không đồng bộ";
            this.rbtn_not_sync.UseVisualStyleBackColor = true;
            // 
            // rbtn_sync
            // 
            this.rbtn_sync.AutoSize = true;
            this.rbtn_sync.Location = new System.Drawing.Point(12, 27);
            this.rbtn_sync.Margin = new System.Windows.Forms.Padding(2);
            this.rbtn_sync.Name = "rbtn_sync";
            this.rbtn_sync.Size = new System.Drawing.Size(66, 17);
            this.rbtn_sync.TabIndex = 0;
            this.rbtn_sync.TabStop = true;
            this.rbtn_sync.Text = "Đồng bộ";
            this.rbtn_sync.UseVisualStyleBackColor = true;
            // 
            // btn_save_config
            // 
            this.btn_save_config.Location = new System.Drawing.Point(466, 441);
            this.btn_save_config.Margin = new System.Windows.Forms.Padding(2);
            this.btn_save_config.Name = "btn_save_config";
            this.btn_save_config.Size = new System.Drawing.Size(99, 30);
            this.btn_save_config.TabIndex = 7;
            this.btn_save_config.Text = "Lưu cấu hình";
            this.btn_save_config.UseVisualStyleBackColor = true;
            this.btn_save_config.Click += new System.EventHandler(this.btn_save_config_Click);
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(569, 441);
            this.btn_start.Margin = new System.Windows.Forms.Padding(2);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(99, 30);
            this.btn_start.TabIndex = 8;
            this.btn_start.Text = "Bắt đầu";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // btn_stop
            // 
            this.btn_stop.Location = new System.Drawing.Point(672, 441);
            this.btn_stop.Margin = new System.Windows.Forms.Padding(2);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(99, 30);
            this.btn_stop.TabIndex = 9;
            this.btn_stop.Text = "Kết thúc";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 483);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btn_save_config);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.btn_stop);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ServerForm";
            this.Text = "Cấu hình đồng bộ";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPath)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView gridViewPath;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.RadioButton rbtn_not_sync;
        private System.Windows.Forms.RadioButton rbtn_sync;
        private System.Windows.Forms.Button btn_save_config;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_source;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_destination;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_note;
    }
}

