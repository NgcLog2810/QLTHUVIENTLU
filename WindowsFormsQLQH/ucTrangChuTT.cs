using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsQLQH
{
    public partial class ucTrangChuTT : UserControl
    {
        
        public ucTrangChuTT()
        {
            InitializeComponent();
        }
        string chuoiKetNoi = "Data source='DESKTOP-65MR51H\\SQLEXPRESS';"+
            "Initial Catalog=QLTV;" +
            "Integrated Security=True";
        SqlConnection conn = null;

        private string soLuongSach()
        {
            conn = new SqlConnection(chuoiKetNoi);
            conn.Open();
            string soLuongSach;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;  
            cmd.CommandText = "select count(*) from Sach";
            soLuongSach=cmd.ExecuteScalar().ToString();
            return soLuongSach;
        }
        private string soLuongSachChoMuon()
        {
            conn = new SqlConnection(chuoiKetNoi);
            conn.Open();
            string soLuongSachChoMuon;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select count(*) from MuonTra " +
                "where trangThai=N'Đang mượn'";
            soLuongSachChoMuon = cmd.ExecuteScalar().ToString();
            return soLuongSachChoMuon;
        }
        private string soPhieuQuaHan()
        {
            conn = new SqlConnection(chuoiKetNoi);
            conn.Open();
            string soPhieuQuaHan;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select count(*) from MuonTra " +
                "where datediff(day, ngayHenTra, getdate())>0" +
                " and trangThai=N'Đang mượn';";
            soPhieuQuaHan=cmd.ExecuteScalar().ToString();
            return soPhieuQuaHan;
        }
        private string soLuongDocGia()
        {
            conn = new SqlConnection(chuoiKetNoi);
            conn.Open();
            string soLuongDocGia;
            SqlCommand cmd=new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select count(*) from TaiKhoan";
            soLuongDocGia=cmd.ExecuteScalar().ToString();
            return soLuongDocGia;
        }
        private void ucTrangChuTT_Load(object sender, EventArgs e)
        {
            lbTongSoSach.Text = soLuongSach();
            lbSoSachDangMuon.Text = soLuongSachChoMuon();
            lbSachQuaHan.Text = soPhieuQuaHan();
            lbSoLuongDocGia.Text = soLuongDocGia();
            conn = new SqlConnection(chuoiKetNoi);
            conn.Open();
            string sql = "select " +
                "maPhieu as 'Mã phiếu'," +
                "tenNguoiDung as 'Tên độc giả'," +
                "tenSach as 'Tên sách'," +
                "ngayMuon as 'Ngày mượn'," +
                "ngayHenTra as 'Hạn trả'," +
                "trangThai as 'Trạng thái'" +
                "from MuonTra " +
                "where trangThai!=N'Đã thu phạt'";
            SqlDataAdapter daTT=new SqlDataAdapter(sql,conn);
            DataTable dtTT = new DataTable();
            daTT.Fill(dtTT);
            dgvLichSuMuonTra.DataSource = dtTT;
            dgvLichSuMuonTra.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLichSuMuonTra.Columns["Tên sách"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvLichSuMuonTra.Columns["Mã phiếu"].Width = 100;
            dgvLichSuMuonTra.Columns["Ngày mượn"].Width = 100;
            dgvLichSuMuonTra.Columns["Hạn trả"].Width = 100;
        }
    }
}
