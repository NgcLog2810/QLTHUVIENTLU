namespace WindowsFormsQLQH
{
    partial class ucQUanLyQuaHan
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tlpQuanLyQuaHan = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvQuanLyQuaHan = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbTimKiem = new System.Windows.Forms.TextBox();
            this.nudSoNgayQuaHan = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.btXuatDS = new System.Windows.Forms.Button();
            this.btXacNhanThuPhat = new System.Windows.Forms.Button();
            this.btXacNhanTraSach = new System.Windows.Forms.Button();
            this.tlpTimKiem = new System.Windows.Forms.TableLayoutPanel();
            this.tlpBangDL = new System.Windows.Forms.TableLayoutPanel();
            this.tlpTieuDeQLQH = new System.Windows.Forms.TableLayoutPanel();
            this.tlpQuanLyQuaHan.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuanLyQuaHan)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoNgayQuaHan)).BeginInit();
            this.tlpTimKiem.SuspendLayout();
            this.tlpBangDL.SuspendLayout();
            this.tlpTieuDeQLQH.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpQuanLyQuaHan
            // 
            this.tlpQuanLyQuaHan.ColumnCount = 1;
            this.tlpQuanLyQuaHan.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpQuanLyQuaHan.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpQuanLyQuaHan.Controls.Add(this.tlpTimKiem, 0, 2);
            this.tlpQuanLyQuaHan.Controls.Add(this.tlpBangDL, 0, 3);
            this.tlpQuanLyQuaHan.Controls.Add(this.panel3, 0, 0);
            this.tlpQuanLyQuaHan.Controls.Add(this.tlpTieuDeQLQH, 0, 1);
            this.tlpQuanLyQuaHan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpQuanLyQuaHan.Location = new System.Drawing.Point(0, 0);
            this.tlpQuanLyQuaHan.Name = "tlpQuanLyQuaHan";
            this.tlpQuanLyQuaHan.RowCount = 4;
            this.tlpQuanLyQuaHan.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.3F));
            this.tlpQuanLyQuaHan.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.1F));
            this.tlpQuanLyQuaHan.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.7F));
            this.tlpQuanLyQuaHan.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 67.9F));
            this.tlpQuanLyQuaHan.Size = new System.Drawing.Size(1500, 1000);
            this.tlpQuanLyQuaHan.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(49, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1442, 99);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.btXacNhanTraSach);
            this.panel2.Controls.Add(this.btXacNhanThuPhat);
            this.panel2.Controls.Add(this.btXuatDS);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.nudSoNgayQuaHan);
            this.panel2.Controls.Add(this.tbTimKiem);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(49, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1442, 115);
            this.panel2.TabIndex = 1;
            // 
            // dgvQuanLyQuaHan
            // 
            this.dgvQuanLyQuaHan.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvQuanLyQuaHan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvQuanLyQuaHan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvQuanLyQuaHan.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvQuanLyQuaHan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvQuanLyQuaHan.GridColor = System.Drawing.SystemColors.Control;
            this.dgvQuanLyQuaHan.Location = new System.Drawing.Point(49, 3);
            this.dgvQuanLyQuaHan.Name = "dgvQuanLyQuaHan";
            this.dgvQuanLyQuaHan.ReadOnly = true;
            this.dgvQuanLyQuaHan.RowHeadersWidth = 62;
            this.dgvQuanLyQuaHan.RowTemplate.Height = 28;
            this.dgvQuanLyQuaHan.Size = new System.Drawing.Size(1442, 667);
            this.dgvQuanLyQuaHan.TabIndex = 2;
            this.dgvQuanLyQuaHan.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.phanLoaiBangMau_DataBindingComplete);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(23, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(360, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "QUẢN LÝ THƯ VIỆN - THỦ THƯ";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1494, 77);
            this.panel3.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(1, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(307, 36);
            this.label2.TabIndex = 0;
            this.label2.Text = "QUẢN LÝ QUÁ HẠN";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label3.Location = new System.Drawing.Point(3, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(224, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Theo dõi và xử lý sách quá hạn";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Tìm kiếm";
            // 
            // tbTimKiem
            // 
            this.tbTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTimKiem.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.tbTimKiem.Location = new System.Drawing.Point(25, 48);
            this.tbTimKiem.Name = "tbTimKiem";
            this.tbTimKiem.Size = new System.Drawing.Size(388, 35);
            this.tbTimKiem.TabIndex = 1;
            this.tbTimKiem.Text = "Mã độc giả/Tên độc giả/Mã sách";
            this.tbTimKiem.TextChanged += new System.EventHandler(this.timKiem_TextChanged);
            this.tbTimKiem.Enter += new System.EventHandler(this.tbTimKiem_Enter);
            this.tbTimKiem.Leave += new System.EventHandler(this.tbTimKiem_Leave);
            // 
            // nudSoNgayQuaHan
            // 
            this.nudSoNgayQuaHan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSoNgayQuaHan.Location = new System.Drawing.Point(443, 49);
            this.nudSoNgayQuaHan.Name = "nudSoNgayQuaHan";
            this.nudSoNgayQuaHan.Size = new System.Drawing.Size(102, 35);
            this.nudSoNgayQuaHan.TabIndex = 2;
            this.nudSoNgayQuaHan.ValueChanged += new System.EventHandler(this.timTheoSoNgayQuaHan_ValueChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(439, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "Số ngày quá hạn";
            // 
            // btXuatDS
            // 
            this.btXuatDS.BackColor = System.Drawing.Color.DodgerBlue;
            this.btXuatDS.ForeColor = System.Drawing.Color.White;
            this.btXuatDS.Location = new System.Drawing.Point(595, 41);
            this.btXuatDS.Name = "btXuatDS";
            this.btXuatDS.Size = new System.Drawing.Size(156, 54);
            this.btXuatDS.TabIndex = 4;
            this.btXuatDS.Text = "Xuất danh sách";
            this.btXuatDS.UseVisualStyleBackColor = false;
            this.btXuatDS.Click += new System.EventHandler(this.btXuatDS_Click);
            // 
            // btXacNhanThuPhat
            // 
            this.btXacNhanThuPhat.BackColor = System.Drawing.Color.LimeGreen;
            this.btXacNhanThuPhat.ForeColor = System.Drawing.Color.White;
            this.btXacNhanThuPhat.Location = new System.Drawing.Point(786, 41);
            this.btXacNhanThuPhat.Name = "btXacNhanThuPhat";
            this.btXacNhanThuPhat.Size = new System.Drawing.Size(156, 54);
            this.btXacNhanThuPhat.TabIndex = 5;
            this.btXacNhanThuPhat.Text = "Xác nhận thu phạt";
            this.btXacNhanThuPhat.UseVisualStyleBackColor = false;
            this.btXacNhanThuPhat.Click += new System.EventHandler(this.btXacNhanThuPhat_Click);
            // 
            // btXacNhanTraSach
            // 
            this.btXacNhanTraSach.BackColor = System.Drawing.Color.Orange;
            this.btXacNhanTraSach.ForeColor = System.Drawing.Color.White;
            this.btXacNhanTraSach.Location = new System.Drawing.Point(977, 41);
            this.btXacNhanTraSach.Name = "btXacNhanTraSach";
            this.btXacNhanTraSach.Size = new System.Drawing.Size(156, 54);
            this.btXacNhanTraSach.TabIndex = 6;
            this.btXacNhanTraSach.Text = "Xác nhận trả sách";
            this.btXacNhanTraSach.UseVisualStyleBackColor = false;
            this.btXacNhanTraSach.Click += new System.EventHandler(this.btXacNhanTraSach_Click);
            // 
            // tlpTimKiem
            // 
            this.tlpTimKiem.ColumnCount = 2;
            this.tlpTimKiem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.099511F));
            this.tlpTimKiem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 96.90049F));
            this.tlpTimKiem.Controls.Add(this.panel2, 1, 0);
            this.tlpTimKiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTimKiem.Location = new System.Drawing.Point(3, 197);
            this.tlpTimKiem.Name = "tlpTimKiem";
            this.tlpTimKiem.RowCount = 1;
            this.tlpTimKiem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTimKiem.Size = new System.Drawing.Size(1494, 121);
            this.tlpTimKiem.TabIndex = 4;
            // 
            // tlpBangDL
            // 
            this.tlpBangDL.ColumnCount = 2;
            this.tlpBangDL.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.099511F));
            this.tlpBangDL.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 96.90049F));
            this.tlpBangDL.Controls.Add(this.dgvQuanLyQuaHan, 1, 0);
            this.tlpBangDL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpBangDL.Location = new System.Drawing.Point(3, 324);
            this.tlpBangDL.Name = "tlpBangDL";
            this.tlpBangDL.RowCount = 1;
            this.tlpBangDL.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpBangDL.Size = new System.Drawing.Size(1494, 673);
            this.tlpBangDL.TabIndex = 5;
            // 
            // tlpTieuDeQLQH
            // 
            this.tlpTieuDeQLQH.ColumnCount = 2;
            this.tlpTieuDeQLQH.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.078983F));
            this.tlpTieuDeQLQH.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 96.92102F));
            this.tlpTieuDeQLQH.Controls.Add(this.panel1, 1, 0);
            this.tlpTieuDeQLQH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTieuDeQLQH.Location = new System.Drawing.Point(3, 86);
            this.tlpTieuDeQLQH.Name = "tlpTieuDeQLQH";
            this.tlpTieuDeQLQH.RowCount = 1;
            this.tlpTieuDeQLQH.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTieuDeQLQH.Size = new System.Drawing.Size(1494, 105);
            this.tlpTieuDeQLQH.TabIndex = 6;
            // 
            // ucQUanLyQuaHan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpQuanLyQuaHan);
            this.Name = "ucQUanLyQuaHan";
            this.Size = new System.Drawing.Size(1500, 1000);
            this.Load += new System.EventHandler(this.ucQuanLyQuaHan_Load);
            this.tlpQuanLyQuaHan.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuanLyQuaHan)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoNgayQuaHan)).EndInit();
            this.tlpTimKiem.ResumeLayout(false);
            this.tlpBangDL.ResumeLayout(false);
            this.tlpTieuDeQLQH.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpQuanLyQuaHan;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvQuanLyQuaHan;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbTimKiem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btXacNhanTraSach;
        private System.Windows.Forms.Button btXacNhanThuPhat;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudSoNgayQuaHan;
        public System.Windows.Forms.Button btXuatDS;
        private System.Windows.Forms.TableLayoutPanel tlpTimKiem;
        private System.Windows.Forms.TableLayoutPanel tlpBangDL;
        private System.Windows.Forms.TableLayoutPanel tlpTieuDeQLQH;
    }
}
