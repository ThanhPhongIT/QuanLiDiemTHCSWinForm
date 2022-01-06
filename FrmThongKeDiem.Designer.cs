
namespace QuanLiDiemHocSinhTHCS
{
    partial class FrmThongKeDiem
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
            this.tab = new System.Windows.Forms.TabControl();
            this.tbMon = new System.Windows.Forms.TabPage();
            this.dgvDiem = new System.Windows.Forms.DataGridView();
            this.cboMon = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabHS = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.comboBox8 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbohk = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboNamHoc = new System.Windows.Forms.ComboBox();
            this.cboLop = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.MaHS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiemMieng = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Diemmieng2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Diem15p1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Diem15p2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diem45p = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diemhk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiemTB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tab.SuspendLayout();
            this.tbMon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiem)).BeginInit();
            this.tabHS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 23.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(352, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(446, 37);
            this.label1.TabIndex = 5;
            this.label1.Text = "THỐNG KÊ ĐIỂM HỌC SINH";
            // 
            // tab
            // 
            this.tab.AccessibleName = "";
            this.tab.Controls.Add(this.tbMon);
            this.tab.Controls.Add(this.tabHS);
            this.tab.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab.Location = new System.Drawing.Point(10, 172);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(1291, 482);
            this.tab.TabIndex = 6;
            // 
            // tbMon
            // 
            this.tbMon.Controls.Add(this.dgvDiem);
            this.tbMon.Controls.Add(this.cboMon);
            this.tbMon.Controls.Add(this.label4);
            this.tbMon.Location = new System.Drawing.Point(4, 24);
            this.tbMon.Name = "tbMon";
            this.tbMon.Padding = new System.Windows.Forms.Padding(3);
            this.tbMon.Size = new System.Drawing.Size(1283, 454);
            this.tbMon.TabIndex = 0;
            this.tbMon.Text = "Xem theo môn";
            this.tbMon.UseVisualStyleBackColor = true;
            // 
            // dgvDiem
            // 
            this.dgvDiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDiem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaHS,
            this.HoTen,
            this.DiemMieng,
            this.Diemmieng2,
            this.Diem15p1,
            this.Diem15p2,
            this.diem45p,
            this.diemhk,
            this.DiemTB});
            this.dgvDiem.Location = new System.Drawing.Point(15, 65);
            this.dgvDiem.Name = "dgvDiem";
            this.dgvDiem.Size = new System.Drawing.Size(1262, 364);
            this.dgvDiem.TabIndex = 6;
            // 
            // cboMon
            // 
            this.cboMon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMon.FormattingEnabled = true;
            this.cboMon.Location = new System.Drawing.Point(115, 18);
            this.cboMon.Name = "cboMon";
            this.cboMon.Size = new System.Drawing.Size(136, 23);
            this.cboMon.TabIndex = 5;
            this.cboMon.SelectedIndexChanged += new System.EventHandler(this.cboMon_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Chọn môn";
            // 
            // tabHS
            // 
            this.tabHS.Controls.Add(this.dataGridView2);
            this.tabHS.Controls.Add(this.comboBox8);
            this.tabHS.Controls.Add(this.label9);
            this.tabHS.Location = new System.Drawing.Point(4, 24);
            this.tabHS.Name = "tabHS";
            this.tabHS.Padding = new System.Windows.Forms.Padding(3);
            this.tabHS.Size = new System.Drawing.Size(1283, 454);
            this.tabHS.TabIndex = 1;
            this.tabHS.Text = "Xem theo học sinh";
            this.tabHS.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(15, 63);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(1216, 367);
            this.dataGridView2.TabIndex = 17;
            // 
            // comboBox8
            // 
            this.comboBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox8.FormattingEnabled = true;
            this.comboBox8.Location = new System.Drawing.Point(115, 16);
            this.comboBox8.Name = "comboBox8";
            this.comboBox8.Size = new System.Drawing.Size(136, 23);
            this.comboBox8.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 15);
            this.label9.TabIndex = 15;
            this.label9.Text = "Chọn học sinh";
            // 
            // cbohk
            // 
            this.cbohk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbohk.FormattingEnabled = true;
            this.cbohk.Location = new System.Drawing.Point(116, 130);
            this.cbohk.Name = "cbohk";
            this.cbohk.Size = new System.Drawing.Size(136, 23);
            this.cbohk.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "Chọn học kì";
            // 
            // cboNamHoc
            // 
            this.cboNamHoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNamHoc.FormattingEnabled = true;
            this.cboNamHoc.Location = new System.Drawing.Point(116, 92);
            this.cboNamHoc.Name = "cboNamHoc";
            this.cboNamHoc.Size = new System.Drawing.Size(136, 23);
            this.cboNamHoc.TabIndex = 12;
            // 
            // cboLop
            // 
            this.cboLop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLop.FormattingEnabled = true;
            this.cboLop.Location = new System.Drawing.Point(116, 53);
            this.cboLop.Name = "cboLop";
            this.cboLop.Size = new System.Drawing.Size(136, 23);
            this.cboLop.TabIndex = 11;
            this.cboLop.SelectedIndexChanged += new System.EventHandler(this.cboLop_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "Chọn năm học";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Chọn lớp";
            // 
            // MaHS
            // 
            this.MaHS.FillWeight = 130F;
            this.MaHS.HeaderText = "Mã học sinh";
            this.MaHS.Name = "MaHS";
            // 
            // HoTen
            // 
            this.HoTen.HeaderText = "Tên học sinh";
            this.HoTen.Name = "HoTen";
            this.HoTen.Width = 200;
            // 
            // DiemMieng
            // 
            this.DiemMieng.HeaderText = "Điểm miệng 1";
            this.DiemMieng.Name = "DiemMieng";
            this.DiemMieng.Width = 130;
            // 
            // Diemmieng2
            // 
            this.Diemmieng2.HeaderText = "Điểm miệng 2";
            this.Diemmieng2.Name = "Diemmieng2";
            this.Diemmieng2.Width = 130;
            // 
            // Diem15p1
            // 
            this.Diem15p1.HeaderText = "Điểm 15p 1";
            this.Diem15p1.Name = "Diem15p1";
            this.Diem15p1.Width = 130;
            // 
            // Diem15p2
            // 
            this.Diem15p2.HeaderText = "Điểm 15p 2";
            this.Diem15p2.Name = "Diem15p2";
            this.Diem15p2.Width = 130;
            // 
            // diem45p
            // 
            this.diem45p.HeaderText = "Điểm giữa kỳ";
            this.diem45p.Name = "diem45p";
            this.diem45p.Width = 130;
            // 
            // diemhk
            // 
            this.diemhk.HeaderText = "Điểm cuối kỳ";
            this.diemhk.Name = "diemhk";
            this.diemhk.Width = 130;
            // 
            // DiemTB
            // 
            this.DiemTB.HeaderText = "Điểm TB học kỳ";
            this.DiemTB.Name = "DiemTB";
            this.DiemTB.Width = 150;
            // 
            // FrmThongKeDiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1313, 666);
            this.Controls.Add(this.cbohk);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboNamHoc);
            this.Controls.Add(this.cboLop);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tab);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmThongKeDiem";
            this.Text = "FrmThongKeDiem";
            this.Load += new System.EventHandler(this.FrmThongKeDiem_Load);
            this.tab.ResumeLayout(false);
            this.tbMon.ResumeLayout(false);
            this.tbMon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiem)).EndInit();
            this.tabHS.ResumeLayout(false);
            this.tabHS.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tab;
        private System.Windows.Forms.TabPage tbMon;
        private System.Windows.Forms.DataGridView dgvDiem;
        private System.Windows.Forms.ComboBox cboMon;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabHS;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.ComboBox comboBox8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbohk;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboNamHoc;
        private System.Windows.Forms.ComboBox cboLop;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHS;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiemMieng;
        private System.Windows.Forms.DataGridViewTextBoxColumn Diemmieng2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Diem15p1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Diem15p2;
        private System.Windows.Forms.DataGridViewTextBoxColumn diem45p;
        private System.Windows.Forms.DataGridViewTextBoxColumn diemhk;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiemTB;
    }
}