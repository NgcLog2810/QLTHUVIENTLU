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
                "Initial Catalog=heThongThuVienTLU;" +
                "Integrated Security=True";
        SqlConnection conn = null;

        private void LoadData()
        {
            string sql = "Select\n" +
                    "row_number() over (order by hanTra desc) as STT," +
                    "maPhieuMuon as N'Mã phiếu mượn',\n" +
                    "maDocGia as N'Mã độc giả',\n" +
                    "tenDocGia as N'Tên độc giả',\n" +
                    "maSach as N'Mã sách',\n" +
                    "tenSach as N'Tên sách',\n" +
                    "ngayMuon as N'Ngày mượn',\n" +
                    "hanTra as N'Hạn trả',\n" +
                    "datediff(day, hanTra, getdate()) as N'Số ngày quá hạn',\n" +
                    "datediff(day, hanTra, getdate()) *400 as N'Tiền phạt',\n" +
                    "trangThai as N'Trạng thái'\n" +
                    "from phieuMuon\n" +
                    "where datediff(day, hanTra, getdate()) > 0;";
            SqlDataAdapter daQLQH = new SqlDataAdapter(sql, conn);
            DataTable dtQLQH = new DataTable();
            daQLQH.Fill(dtQLQH);
            dgvQuanLyQuaHan.DataSource = dtQLQH;
            dgvQuanLyQuaHan.Columns["Trạng thái"].Visible = false;
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
                    "row_number() over (order by hanTra desc) as STT," +
                    "maPhieuMuon as N'Mã phiếu mượn',\n" +
                    "maDocGia as N'Mã độc giả',\n" +
                    "tenDocGia as N'Tên độc giả',\n" +
                    "maSach as N'Mã sách',\n" +
                    "tenSach as N'Tên sách',\n" +
                    "ngayMuon as N'Ngày mượn',\n" +
                    "hanTra as N'Hạn trả',\n" +
                    "datediff(day, hanTra, getdate()) as N'Số ngày quá hạn',\n" +
                    "datediff(day, hanTra, getdate()) * 400 as N'Tiền phạt',\n" +
                    "trangThai as N'Trạng thái'\n" +
                    "from phieuMuon\n" +
                    "where (maDocGia like N'%" + tbTimKiem.Text + "%' or " +
                    "maSach like N'%" + tbTimKiem.Text + "%' or " +
                    "tenDocGia like N'%" + tbTimKiem.Text + "%') " +
                    "and datediff(day, hanTra, getdate()) > 0;"; 
            SqlDataAdapter daQLQH = new SqlDataAdapter(sql, conn);
            DataTable dtQLQH=new DataTable();  
            daQLQH.Fill(dtQLQH);
            dgvQuanLyQuaHan.DataSource= dtQLQH;
            dgvQuanLyQuaHan.Columns["Trạng thái"].Visible = false;
            }
                
        }

        private void timTheoSoNgayQuaHan_ValueChanged(object sender, EventArgs e)
        {
            string sql = "select " +
                "row_number() over (order by hanTra desc) as STT," +
                "maPhieuMuon as N'Mã phiếu mượn',\n" +
                "maDocGia as N'Mã độc giả',\n" +
                "tenDocGia as N'Tên độc giả',\n" +
                "maSach as N'Mã sách',\n" +
                "tenSach as N'Tên sách',\n" +
                "ngayMuon as N'Ngày mượn',\n" +
                "hanTra as N'Hạn trả',\n" +
                "datediff(day,hanTra,getdate()) as N'Số ngày quá hạn',\n" +
                "datediff(day,hanTra,getdate()) * 400 as N'Tiền phạt',\n" +
                "trangThai as N'Trạng thái'\n" +
                "from phieuMuon\n" +
                "where datediff(day,hanTra,getdate()) = " + nudSoNgayQuaHan.Value + ";";
            SqlDataAdapter daQLQH = new SqlDataAdapter(sql, conn);
            DataTable dtQLQH = new DataTable();
            daQLQH.Fill(dtQLQH);
            dgvQuanLyQuaHan.DataSource = dtQLQH;
            dgvQuanLyQuaHan.Columns["Trạng thái"].Visible = false;
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
            string maPhieuMuon = dgvQuanLyQuaHan.CurrentRow.Cells["Mã phiếu mượn"].Value.ToString();
            DialogResult dialogResult = MessageBox.Show("Phiếu mượn "+maPhieuMuon+"\nĐã thu tiền phạt ?",
                                        "Xác nhận",
                                        MessageBoxButtons.YesNoCancel,
                                        MessageBoxIcon.Question);
            if (dialogResult==DialogResult.Yes)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "delete from phieuMuon where maPhieuMuon = '" +
                    maPhieuMuon + "';";
                cmd.ExecuteNonQuery();
                LoadData();
            }
        }

        private void btXacNhanThuPhat_Click(object sender, EventArgs e)
        {
            string tienPhat = Convert.ToString(Convert.ToInt32(dgvQuanLyQuaHan.CurrentRow.Cells["Số ngày quá hạn"].Value.ToString()) * 400);
            string tenDocGia = dgvQuanLyQuaHan.CurrentRow.Cells["Tên độc giả"].Value.ToString();
            string maDocGia = dgvQuanLyQuaHan.CurrentRow.Cells["Mã độc giả"].Value.ToString();
            string maPhieuMuon = dgvQuanLyQuaHan.CurrentRow.Cells["Mã phiếu mượn"].Value.ToString();
            MessageBox.Show("Đã thu " + tienPhat
                + " của độc giả " + tenDocGia +
                " có mã độc giả " + maDocGia, "Thông báo", MessageBoxButtons.OKCancel);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "update docGia set tienNo = tienNo + " +
                Convert.ToInt32(dgvQuanLyQuaHan.CurrentRow.Cells["Số ngày quá hạn"].Value.ToString()) * 400 +
                " where maDocGia = '" + maDocGia+ "';\n" +
                "upDate phieuMuon set trangThai = N'Đã thu phạt' where maPhieuMuon = '"+
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
