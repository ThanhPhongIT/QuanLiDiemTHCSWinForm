
namespace QuanLiDiemHocSinhTHCS
{
    partial class FrmNhapDiem
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
            this.btnLuu = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.txtHocKy = new System.Windows.Forms.TextBox();
            this.txtTenMon = new System.Windows.Forms.TextBox();
            this.txtTenLop = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvNhapDiem = new System.Windows.Forms.DataGridView();
            this.Mahs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hoten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diemmieng = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diemmiengl2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diem15p = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diem15pl2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diem45p = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diemhk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhapDiem)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLuu
            // 
            this.btnLuu.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnLuu.Location = new System.Drawing.Point(85, 19);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(79, 29);
            this.btnLuu.TabIndex = 6;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnThoat);
            this.groupBox2.Controls.Add(this.btnLuu);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.groupBox2.Location = new System.Drawing.Point(280, 530);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(469, 59);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " Chức năng";
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnThoat.Location = new System.Drawing.Point(297, 19);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(79, 29);
            this.btnThoat.TabIndex = 8;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click_1);
            // 
            // txtHocKy
            // 
            this.txtHocKy.Enabled = false;
            this.txtHocKy.Location = new System.Drawing.Point(159, 84);
            this.txtHocKy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtHocKy.Name = "txtHocKy";
            this.txtHocKy.Size = new System.Drawing.Size(154, 26);
            this.txtHocKy.TabIndex = 38;
            // 
            // txtTenMon
            // 
            this.txtTenMon.Enabled = false;
            this.txtTenMon.Location = new System.Drawing.Point(159, 54);
            this.txtTenMon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTenMon.Name = "txtTenMon";
            this.txtTenMon.Size = new System.Drawing.Size(154, 26);
            this.txtTenMon.TabIndex = 37;
            // 
            // txtTenLop
            // 
            this.txtTenLop.Enabled = false;
            this.txtTenLop.Location = new System.Drawing.Point(159, 23);
            this.txtTenLop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTenLop.Name = "txtTenLop";
            this.txtTenLop.Size = new System.Drawing.Size(154, 26);
            this.txtTenLop.TabIndex = 36;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label11.Location = new System.Drawing.Point(71, 55);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(91, 19);
            this.label11.TabIndex = 25;
            this.label11.Text = "Tên môn học:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label6.Location = new System.Drawing.Point(71, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 19);
            this.label6.TabIndex = 18;
            this.label6.Text = "Học kỳ:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label7.Location = new System.Drawing.Point(71, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 19);
            this.label7.TabIndex = 17;
            this.label7.Text = "Tên lớp:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtHocKy);
            this.groupBox3.Controls.Add(this.txtTenMon);
            this.groupBox3.Controls.Add(this.txtTenLop);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.groupBox3.Location = new System.Drawing.Point(25, 10);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(404, 125);
            this.groupBox3.TabIndex = 35;
            this.groupBox3.TabStop = false;
            // 
            // dgvNhapDiem
            // 
            this.dgvNhapDiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNhapDiem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Mahs,
            this.hoten,
            this.nh,
            this.diemmieng,
            this.diemmiengl2,
            this.diem15p,
            this.diem15pl2,
            this.diem45p,
            this.diemhk});
            this.dgvNhapDiem.Location = new System.Drawing.Point(25, 169);
            this.dgvNhapDiem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvNhapDiem.Name = "dgvNhapDiem";
            this.dgvNhapDiem.RowHeadersWidth = 51;
            this.dgvNhapDiem.RowTemplate.Height = 29;
            this.dgvNhapDiem.Size = new System.Drawing.Size(1178, 341);
            this.dgvNhapDiem.TabIndex = 34;
            this.dgvNhapDiem.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNhapDiem_CellClick);
            this.dgvNhapDiem.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNhapDiem_CellContentClick);
            // 
            // Mahs
            // 
            this.Mahs.DataPropertyName = "MaHS";
            this.Mahs.HeaderText = "Mã học sinh";
            this.Mahs.MinimumWidth = 6;
            this.Mahs.Name = "Mahs";
            this.Mahs.ReadOnly = true;
            this.Mahs.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Mahs.Width = 125;
            // 
            // hoten
            // 
            this.hoten.DataPropertyName = "HoTen";
            this.hoten.HeaderText = "Họ tên";
            this.hoten.MinimumWidth = 6;
            this.hoten.Name = "hoten";
            this.hoten.ReadOnly = true;
            this.hoten.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.hoten.Width = 125;
            // 
            // nh
            // 
            this.nh.DataPropertyName = "NamHoc";
            this.nh.HeaderText = "Năm học";
            this.nh.MinimumWidth = 6;
            this.nh.Name = "nh";
            this.nh.ReadOnly = true;
            this.nh.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.nh.Width = 125;
            // 
            // diemmieng
            // 
            this.diemmieng.DataPropertyName = "DiemMieng";
            this.diemmieng.HeaderText = "Điểm miệng";
            this.diemmieng.MinimumWidth = 6;
            this.diemmieng.Name = "diemmieng";
            this.diemmieng.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.diemmieng.Width = 125;
            // 
            // diemmiengl2
            // 
            this.diemmiengl2.DataPropertyName = "DiemMiengl2";
            this.diemmiengl2.HeaderText = "Điểm Miêng 2";
            this.diemmiengl2.MinimumWidth = 6;
            this.diemmiengl2.Name = "diemmiengl2";
            this.diemmiengl2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.diemmiengl2.Width = 125;
            // 
            // diem15p
            // 
            this.diem15p.DataPropertyName = "Diem15phut";
            this.diem15p.HeaderText = "Điểm 15phút";
            this.diem15p.MinimumWidth = 6;
            this.diem15p.Name = "diem15p";
            this.diem15p.Width = 125;
            // 
            // diem15pl2
            // 
            this.diem15pl2.DataPropertyName = "Diem15phutl2";
            this.diem15pl2.HeaderText = "Điểm 15phút";
            this.diem15pl2.MinimumWidth = 6;
            this.diem15pl2.Name = "diem15pl2";
            this.diem15pl2.Width = 125;
            // 
            // diem45p
            // 
            this.diem45p.DataPropertyName = "Diem45phut";
            this.diem45p.HeaderText = "Điểm giữa hk";
            this.diem45p.MinimumWidth = 6;
            this.diem45p.Name = "diem45p";
            this.diem45p.Width = 125;
            // 
            // diemhk
            // 
            this.diemhk.DataPropertyName = "DiemHocKy";
            this.diemhk.HeaderText = "Điểm học kỳ";
            this.diemhk.MinimumWidth = 6;
            this.diemhk.Name = "diemhk";
            this.diemhk.Width = 125;
            // 
            // FrmNhapDiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1231, 622);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.dgvNhapDiem);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmNhapDiem";
            this.Text = "Nhập điểm";
            this.Load += new System.EventHandler(this.FrmNhapDiem_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhapDiem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.TextBox txtHocKy;
        private System.Windows.Forms.TextBox txtTenMon;
        private System.Windows.Forms.TextBox txtTenLop;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvNhapDiem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mahs;
        private System.Windows.Forms.DataGridViewTextBoxColumn hoten;
        private System.Windows.Forms.DataGridViewTextBoxColumn nh;
        private System.Windows.Forms.DataGridViewTextBoxColumn diemmieng;
        private System.Windows.Forms.DataGridViewTextBoxColumn diemmiengl2;
        private System.Windows.Forms.DataGridViewTextBoxColumn diem15p;
        private System.Windows.Forms.DataGridViewTextBoxColumn diem15pl2;
        private System.Windows.Forms.DataGridViewTextBoxColumn diem45p;
        private System.Windows.Forms.DataGridViewTextBoxColumn diemhk;
    }
}