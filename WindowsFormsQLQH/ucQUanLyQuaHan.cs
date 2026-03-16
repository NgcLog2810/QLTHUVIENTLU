using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsQLQH
{
    public partial class ucQUanLyQuaHan : UserControl
    {
        public ucQUanLyQuaHan()
        {
            InitializeComponent();
        }
        string chuoiKetNoi = "Data Source =DESKTOP-65MR51H\\SQLEXPRESS;" +
                "Initial Catalog=QLTV;" +
                "Integrated Security=True";
        SqlConnection conn = null;

        private void LoadData()
        {
            string sql = "Select\n" +
                    "maPhieu as N'Mã phiếu',\n" +
                    "maNguoiDung as N'Mã độc giả',\n" +
                    "tenNguoiDung as N'Tên độc giả',\n" +
                    "maSach as N'Mã sách',\n" +
                    "tenSach as N'Tên sách',\n" +
                    "ngayMuon as N'Ngày mượn',\n" +
                    "ngayHenTra as N'Hạn trả',\n" +
                    "ngayTraThucTe as N'Ngày trả thực tế',\n"+
                    "datediff(day, ngayHenTra, getdate()) as N'Số ngày quá hạn',\n" +
                    "datediff(day, ngayHenTra, getdate()) *400 as N'Tiền phạt',\n" +
                    "trangThai as N'Trạng thái'\n" +
                    "from MuonTra\n" +
                    "where datediff(day, ngayHenTra, getdate()) > 0" +
                    " and trangThai!=N'Đã trả';";
            SqlDataAdapter daQLQH = new SqlDataAdapter(sql, conn);
            DataTable dtQLQH = new DataTable();
            daQLQH.Fill(dtQLQH);
            dgvQuanLyQuaHan.DataSource = dtQLQH;
            dgvQuanLyQuaHan.Columns["Trạng thái"].Visible = false;
            dgvQuanLyQuaHan.Columns["Ngày trả thực tế"].Visible = false;
            dgvQuanLyQuaHan.Columns["Mã sách"].Visible = false;
            dgvQuanLyQuaHan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void ucQuanLyQuaHan_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(chuoiKetNoi);
            conn.Open();
            LoadData();
            
        }

        private void timKiem_TextChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            string sql;
            if (tbTimKiem.Text.Trim() == "Mã độc giả/Tên độc giả/Mã sách")
            {
                sql = "select * from quanLyQUanHan;";
            }
            else
            {
                sql = "Select\n" +
                    "maPhieu as N'Mã phiếu',\n" +
                    "maNguoiDung as N'Mã độc giả',\n" +
                    "tenNguoiDung as N'Tên độc giả',\n" +
                    "maSach as N'Mã sách',\n" +
                    "tenSach as N'Tên sách',\n" +
                    "ngayMuon as N'Ngày mượn',\n" +
                    "ngayHenTra as N'Hạn trả',\n" +
                    "ngayTraThucTe as N'Ngày trả thực tế',\n" +
                    "datediff(day, ngayHenTra, getdate()) as N'Số ngày quá hạn',\n" +
                    "datediff(day, ngayHenTra, getdate()) *400 as N'Tiền phạt',\n" +
                    "trangThai as N'Trạng thái'\n" +
                    "from MuonTra\n" +
                    "where (maNguoiDung like N'%" + tbTimKiem.Text + "%' or " +
                    "maSach like N'%" + tbTimKiem.Text + "%' or " +
                    "tenNguoiDung like N'%" + tbTimKiem.Text + "%') " +
                    "and datediff(day, ngayHenTra, getdate()) > 0" +
                    " and trangThai!=N'Đã trả';"; 
            SqlDataAdapter daQLQH = new SqlDataAdapter(sql, conn);
            DataTable dtQLQH=new DataTable();  
            daQLQH.Fill(dtQLQH);
            dgvQuanLyQuaHan.DataSource= dtQLQH;
            dgvQuanLyQuaHan.Columns["Trạng thái"].Visible = false;
            dgvQuanLyQuaHan.Columns["Ngày trả thực tế"].Visible = false;
            dgvQuanLyQuaHan.Columns["Mã sách"].Visible = false;
            dgvQuanLyQuaHan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
                
        }

        private void timTheoSoNgayQuaHan_ValueChanged(object sender, EventArgs e)
        {
            string sql = "Select\n" +
                "maPhieu as N'Mã phiếu',\n" +
                "maNguoiDung as N'Mã độc giả',\n" +
                "tenNguoiDung as N'Tên độc giả',\n" +
                "maSach as N'Mã sách',\n" +
                "tenSach as N'Tên sách',\n" +
                "ngayMuon as N'Ngày mượn',\n" +
                "ngayHenTra as N'Hạn trả',\n" +
                "ngayTraThucTe as N'Ngày trả thực tế',\n" +
                "datediff(day, ngayHenTra, getdate()) as N'Số ngày quá hạn',\n" +
                "datediff(day, ngayHenTra, getdate()) *400 as N'Tiền phạt',\n" +
                "trangThai as N'Trạng thái'\n" +
                "from MuonTra\n" +
                "where datediff(day,ngayHenTra,getdate()) = " + nudSoNgayQuaHan.Value + 
                " and trangThai!=N'Đã trả';";
            SqlDataAdapter daQLQH = new SqlDataAdapter(sql, conn);
            DataTable dtQLQH = new DataTable();
            daQLQH.Fill(dtQLQH);
            dgvQuanLyQuaHan.DataSource = dtQLQH;
            dgvQuanLyQuaHan.Columns["Trạng thái"].Visible = false;
            dgvQuanLyQuaHan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void tbTimKiem_Enter(object sender, EventArgs e)
        {
            if(tbTimKiem.Text == "Mã độc giả/Tên độc giả/Mã sách")
            {
                tbTimKiem.Text = "";
                tbTimKiem.ForeColor = SystemColors.ControlText;
            }
        }

        private void tbTimKiem_Leave(object sender, EventArgs e)
        {
            if (tbTimKiem.Text == "")
            {
                tbTimKiem.ForeColor = SystemColors.ActiveCaption;
                tbTimKiem.Text = "Mã độc giả/Tên độc giả/Mã sách";
            }
        }

        private void btXacNhanTraSach_Click(object sender, EventArgs e)
        {
            string maPhieuMuon = dgvQuanLyQuaHan.CurrentRow.Cells["Mã phiếu"].Value.ToString();
            string maSach = dgvQuanLyQuaHan.CurrentRow.Cells["Mã sách"].Value.ToString();
            DialogResult dialogResult = MessageBox.Show("Phiếu mượn "+maPhieuMuon+"\nĐã thu tiền phạt ?",
                                        "Xác nhận",
                                        MessageBoxButtons.YesNoCancel,
                                        MessageBoxIcon.Question);
            if (dialogResult==DialogResult.Yes)
            {
                dgvQuanLyQuaHan.Rows.RemoveAt(dgvQuanLyQuaHan.CurrentRow.Index);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "upDate MuonTra set trangThai = N'Đã trả'," +
                    " ngayTraThucTe = getdate() where maPhieu = '" +
                    maPhieuMuon + "';\n" +
                    "upDate Sach set soLuong+=1 where maSach = '" +maSach + "';"; // cap nhat sl sach sau khi tra
                cmd.ExecuteNonQuery();
                LoadData();
            }
        }

        private void btXacNhanThuPhat_Click(object sender, EventArgs e)
        {
            string tienPhat = Convert.ToString(Convert.ToInt32(dgvQuanLyQuaHan.CurrentRow.Cells["Số ngày quá hạn"].Value.ToString()) * 400);
            string tenDocGia = dgvQuanLyQuaHan.CurrentRow.Cells["Tên độc giả"].Value.ToString();
            string maDocGia = dgvQuanLyQuaHan.CurrentRow.Cells["Mã độc giả"].Value.ToString();
            string maPhieuMuon = dgvQuanLyQuaHan.CurrentRow.Cells["Mã phiếu"].Value.ToString();
            MessageBox.Show("Đã thu " + tienPhat
                + " của độc giả " + tenDocGia +
                " có mã độc giả " + maDocGia, "Thông báo", MessageBoxButtons.OKCancel);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "update TaiKhoan set tienNo = tienNo + " +
                Convert.ToInt32(dgvQuanLyQuaHan.CurrentRow.Cells["Số ngày quá hạn"].Value.ToString()) * 400 +
                " where maNguoiDung = '" + maDocGia+ "';\n" +
                "upDate MuonTra set trangThai = N'Đã thu phạt' where maPhieu = '"+
                maPhieuMuon +"';";
            cmd.ExecuteNonQuery();
            LoadData();
        }

        //DataBindingComplete sk duoc chay sau khi dataGrigView da nhan dl va hien thi xog
        private void phanLoaiBangMau_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvQuanLyQuaHan.Rows)
            {
                if (row.IsNewRow)
                    continue;
                int soNgayQuaHan = Convert.ToInt32(row.Cells["Số ngày quá hạn"].Value);
                string trangThai = row.Cells["Trạng thái"].Value.ToString();
                if(trangThai=="Đã thu phạt")
                {
                    row.DefaultCellStyle.BackColor = Color.GreenYellow;
                }
                else if (soNgayQuaHan > 5)
                {
                     row.DefaultCellStyle.BackColor = Color.OrangeRed;
                }
                else if (soNgayQuaHan >= 3 && soNgayQuaHan <= 5)
                {
                     row.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                }
            }
        }
        private void xuatDS()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel file(*.csv)|*.csv";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
                {
                    //ghi tieu de collumn
                    for (int i = 0; i < dgvQuanLyQuaHan.Columns.Count; i++)
                    {
                        if (dgvQuanLyQuaHan.Columns[i].HeaderText == "Ngày trả thực tế") continue;
                        sw.Write(dgvQuanLyQuaHan.Columns[i].HeaderText);
                        if (i < dgvQuanLyQuaHan.Columns.Count - 1)
                        {
                            sw.Write(";");
                        }
                    }
                    sw.WriteLine();
                    // ghi dl row
                    foreach (DataGridViewRow row in dgvQuanLyQuaHan.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            for (int i = 0; i < dgvQuanLyQuaHan.Columns.Count; i++)
                            {
                                if (dgvQuanLyQuaHan.Columns[i].HeaderText == "Ngày trả thực tế") continue;
                                sw.Write(row.Cells[i].Value);
                                if (i < dgvQuanLyQuaHan.Columns.Count - 1)
                                {
                                    sw.Write(";");
                                }
                            }
                            sw.WriteLine();
                        }
                    }
                    sw.Close();
                    MessageBox.Show("Xuất dữ liệu thành công!", "Thông báo");
                }

            }
        }

        private void btXuatDS_Click(object sender, EventArgs e)
        {
            xuatDS();
        }
    }
}
