
namespace QuanLiDiemHocSinhTHCS
{
    partial class FrmTimKiem
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNhap = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.rdbTenHS = new System.Windows.Forms.RadioButton();
            this.rdbMaHS = new System.Windows.Forms.RadioButton();
            this.dgvHs = new System.Windows.Forms.DataGridView();
            this.mahs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hoten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.malop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngaysinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gioitinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quequan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sdt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phuhuynh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dcphuhuynh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sdtphuhuynh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ghichu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHs)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 23.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(362, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(532, 37);
            this.label1.TabIndex = 8;
            this.label1.Text = "TÌM KIẾM THÔNG TIN HỌC SINH";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNhap);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.rdbTenHS);
            this.groupBox1.Controls.Add(this.rdbMaHS);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.groupBox1.Location = new System.Drawing.Point(29, 58);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(861, 205);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Yêu cầu tìm kiếm";
            // 
            // txtNhap
            // 
            this.txtNhap.Location = new System.Drawing.Point(157, 47);
            this.txtNhap.Margin = new System.Windows.Forms.Padding(2);
            this.txtNhap.Name = "txtNhap";
            this.txtNhap.Size = new System.Drawing.Size(372, 26);
            this.txtNhap.TabIndex = 37;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnThoat);
            this.groupBox3.Controls.Add(this.btnTimKiem);
            this.groupBox3.Location = new System.Drawing.Point(157, 98);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(485, 71);
            this.groupBox3.TabIndex = 36;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Chức năng";
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnThoat.Location = new System.Drawing.Point(249, 24);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(79, 32);
            this.btnThoat.TabIndex = 21;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnTimKiem.Location = new System.Drawing.Point(73, 24);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(79, 32);
            this.btnTimKiem.TabIndex = 18;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // rdbTenHS
            // 
            this.rdbTenHS.AutoSize = true;
            this.rdbTenHS.Location = new System.Drawing.Point(406, 19);
            this.rdbTenHS.Margin = new System.Windows.Forms.Padding(2);
            this.rdbTenHS.Name = "rdbTenHS";
            this.rdbTenHS.Size = new System.Drawing.Size(103, 23);
            this.rdbTenHS.TabIndex = 1;
            this.rdbTenHS.TabStop = true;
            this.rdbTenHS.Text = "Tên học sinh";
            this.rdbTenHS.UseVisualStyleBackColor = true;
            // 
            // rdbMaHS
            // 
            this.rdbMaHS.AutoSize = true;
            this.rdbMaHS.Location = new System.Drawing.Point(157, 19);
            this.rdbMaHS.Margin = new System.Windows.Forms.Padding(2);
            this.rdbMaHS.Name = "rdbMaHS";
            this.rdbMaHS.Size = new System.Drawing.Size(101, 23);
            this.rdbMaHS.TabIndex = 0;
            this.rdbMaHS.TabStop = true;
            this.rdbMaHS.Text = "Mã học sinh";
            this.rdbMaHS.UseVisualStyleBackColor = true;
            // 
            // dgvHs
            // 
            this.dgvHs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mahs,
            this.hoten,
            this.malop,
            this.ngaysinh,
            this.gioitinh,
            this.quequan,
            this.sdt,
            this.phuhuynh,
            this.dcphuhuynh,
            this.sdtphuhuynh,
            this.ghichu});
            this.dgvHs.Location = new System.Drawing.Point(29, 278);
            this.dgvHs.Margin = new System.Windows.Forms.Padding(2);
            this.dgvHs.Name = "dgvHs";
            this.dgvHs.RowHeadersWidth = 51;
            this.dgvHs.RowTemplate.Height = 29;
            this.dgvHs.Size = new System.Drawing.Size(1176, 361);
            this.dgvHs.TabIndex = 13;
            this.dgvHs.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // mahs
            // 
            this.mahs.HeaderText = "Mã HS";
            this.mahs.MinimumWidth = 6;
            this.mahs.Name = "mahs";
            this.mahs.Width = 125;
            // 
            // hoten
            // 
            this.hoten.HeaderText = "Họ tên";
            this.hoten.MinimumWidth = 6;
            this.hoten.Name = "hoten";
            this.hoten.Width = 125;
            // 
            // malop
            // 
            this.malop.HeaderText = "Mã lớp";
            this.malop.MinimumWidth = 6;
            this.malop.Name = "malop";
            this.malop.Width = 125;
            // 
            // ngaysinh
            // 
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.ngaysinh.DefaultCellStyle = dataGridViewCellStyle1;
            this.ngaysinh.HeaderText = "Ngày sinh";
            this.ngaysinh.MinimumWidth = 6;
            this.ngaysinh.Name = "ngaysinh";
            this.ngaysinh.Width = 125;
            // 
            // gioitinh
            // 
            this.gioitinh.HeaderText = "Giới tính";
            this.gioitinh.MinimumWidth = 6;
            this.gioitinh.Name = "gioitinh";
            this.gioitinh.Width = 125;
            // 
            // quequan
            // 
            this.quequan.HeaderText = "Quê quán";
            this.quequan.MinimumWidth = 6;
            this.quequan.Name = "quequan";
            this.quequan.Width = 125;
            // 
            // sdt
            // 
            this.sdt.HeaderText = "Số điện thoại";
            this.sdt.MinimumWidth = 6;
            this.sdt.Name = "sdt";
            this.sdt.Width = 125;
            // 
            // phuhuynh
            // 
            this.phuhuynh.HeaderText = "Phụ Huynh";
            this.phuhuynh.MinimumWidth = 6;
            this.phuhuynh.Name = "phuhuynh";
            this.phuhuynh.Width = 125;
            // 
            // dcphuhuynh
            // 
            this.dcphuhuynh.HeaderText = "Địa chỉ phụ huynh";
            this.dcphuhuynh.MinimumWidth = 6;
            this.dcphuhuynh.Name = "dcphuhuynh";
            this.dcphuhuynh.Width = 125;
            // 
            // sdtphuhuynh
            // 
            this.sdtphuhuynh.HeaderText = "SDT phụ huynh";
            this.sdtphuhuynh.MinimumWidth = 6;
            this.sdtphuhuynh.Name = "sdtphuhuynh";
            this.sdtphuhuynh.Width = 125;
            // 
            // ghichu
            // 
            this.ghichu.HeaderText = "Ghi chú";
            this.ghichu.MinimumWidth = 6;
            this.ghichu.Name = "ghichu";
            this.ghichu.Width = 125;
            // 
            // FrmTimKiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1257, 650);
            this.Controls.Add(this.dgvHs);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmTimKiem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmTimKiem";
            this.Load += new System.EventHandler(this.FrmTimKiem_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbTenHS;
        private System.Windows.Forms.RadioButton rdbMaHS;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.DataGridView dgvHs;
        private System.Windows.Forms.TextBox txtNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn mahs;
        private System.Windows.Forms.DataGridViewTextBoxColumn hoten;
        private System.Windows.Forms.DataGridViewTextBoxColumn malop;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngaysinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn gioitinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn quequan;
        private System.Windows.Forms.DataGridViewTextBoxColumn sdt;
        private System.Windows.Forms.DataGridViewTextBoxColumn phuhuynh;
        private System.Windows.Forms.DataGridViewTextBoxColumn dcphuhuynh;
        private System.Windows.Forms.DataGridViewTextBoxColumn sdtphuhuynh;
        private System.Windows.Forms.DataGridViewTextBoxColumn ghichu;
    }
}