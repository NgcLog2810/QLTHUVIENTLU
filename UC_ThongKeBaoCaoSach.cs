using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QUANLYTHUVIENTLU
{
    public partial class UC_ThongKeBaoCaoSach : UserControl
    {
        public UC_ThongKeBaoCaoSach()
        {
            InitializeComponent();
        }

        private void UC_ThongKeBaoCaoSach_Load(object sender, EventArgs e)
        {
            if (cboLoaiThongKe.Items.Count == 0)
            {
                cboLoaiThongKe.Items.AddRange(new string[]
                {
                    "Chủ đề",
                    "Khoa",
                    "Ngành",
                    "Trạng thái"
                });
            }
            cboLoaiThongKe.SelectedIndex = 0; 

            
            VePieChart();
            VeBarChartMuonTra();
            LoadTop3();
            LoadFullSach();
        }


        private void cboLoaiThongKe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLoaiThongKe.SelectedIndex == -1) return;
            VePieChart();
        }

        private void VePieChart()
        {
            try
            {
                string loai = cboLoaiThongKe.SelectedItem?.ToString() ?? "Chủ đề";
                string cotNhom = "chuDe";

                switch (loai)
                {
                    case "Chủ đề":
                        cotNhom = "chuDe";
                        break;
                    case "Khoa":
                        cotNhom = "khoa";
                        break;
                    case "Ngành":
                        cotNhom = "nganh";
                        break;
                    case "Trạng thái":
                        cotNhom = "trangThaiSach";
                        break;
                    default:
                        cotNhom = "chuDe";
                        break;
                }

                string sql = string.Format(@"
                    SELECT {0} AS Nhom, COUNT(*) AS SoLuong
                    FROM Sach
                    WHERE {0} IS NOT NULL AND LTRIM(RTRIM({0})) <> ''
                    GROUP BY {0}
                    ORDER BY SoLuong DESC", cotNhom);

                DataTable dt = DataAccess.ExecuteQuery(sql);

                // Xóa dữ liệu cũ
                chartSoLuongSach.Series.Clear();
                chartSoLuongSach.Titles.Clear();

                // Tạo series Pie
                Series series = new Series("SoLuong")
                {
                    ChartType = SeriesChartType.Pie,
                    IsValueShownAsLabel = true,
                    Label = "#VALX\n#PERCENT{P0}",
                    LegendText = "#VALX",
                    ["PieLabelStyle"] = "Outside"
                };
                chartSoLuongSach.Series.Add(series);

                // Thêm dữ liệu
                foreach (DataRow row in dt.Rows)
                {
                    string nhom = row["Nhom"]?.ToString()?.Trim();
                    if (string.IsNullOrEmpty(nhom)) nhom = "(Không xác định)";

                    int soLuong = Convert.ToInt32(row["SoLuong"]);
                    series.Points.AddXY(nhom, soLuong);
                }

                // Tiêu đề động
                chartSoLuongSach.Titles.Add(new Title(
                    "Thống kê số lượng sách",
                    Docking.Top,
                    new Font("Segoe UI", 10, FontStyle.Bold),
                    Color.DarkGreen
                ));

                // Bật 3D nhẹ
                var area = chartSoLuongSach.ChartAreas[0];
                area.Area3DStyle.Enable3D = true;
                area.Area3DStyle.Inclination = 35;
                area.Area3DStyle.Rotation = 10;

                chartSoLuongSach.Legends[0].Docking = Docking.Right;
                chartSoLuongSach.Legends[0].Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi vẽ biểu đồ:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void VeBarChartMuonTra()
        {
            try
            {
                // Xóa dữ liệu cũ
                chartTinhHinhMuonTra.Series.Clear();
                chartTinhHinhMuonTra.Titles.Clear();

                Series seriesDangMuon = new Series("Đang mượn")
                {
                    ChartType = SeriesChartType.Column,
                    Color = Color.DodgerBlue,
                    IsValueShownAsLabel = true,          
                    LabelForeColor = Color.White,
                    Font = new Font("Segoe UI", 9, FontStyle.Bold)
                };

                Series seriesQuaHan = new Series("Quá hạn")
                {
                    ChartType = SeriesChartType.Column,
                    Color = Color.OrangeRed,
                    IsValueShownAsLabel = true,
                    LabelForeColor = Color.White,
                    Font = new Font("Segoe UI", 9, FontStyle.Bold)
                };

                chartTinhHinhMuonTra.Series.Add(seriesDangMuon);
                chartTinhHinhMuonTra.Series.Add(seriesQuaHan);

                
                string sql = @"
                SELECT 
                    nd.vaiTro,
                    SUM(CASE WHEN mt.trangThai = N'Đang mượn' THEN 1 ELSE 0 END) AS SoDangMuon,
                    SUM(CASE WHEN mt.trangThai = N'Quá hạn'   THEN 1 ELSE 0 END) AS SoQuaHan
                FROM MuonTra mt
                INNER JOIN TaiKhoan nd ON mt.maNguoiDung = nd.maNguoiDung
                WHERE mt.trangThai IN (N'Đang mượn', N'Quá hạn')
                GROUP BY nd.vaiTro
                ORDER BY nd.vaiTro";

                DataTable dt = DataAccess.ExecuteQuery(sql);

                // Nếu không có dữ liệu → thêm cột 0 cho các vai trò phổ biến (tùy chọn)
                var vaiTroPhobien = new[] { "Sinh viên", "Giảng viên", "Thủ thư" };
                var dataDict = new Dictionary<string, (int dangMuon, int quaHan)>();

                foreach (DataRow row in dt.Rows)
                {
                    string vaiTro = row["vaiTro"]?.ToString()?.Trim() ?? "(Không xác định)";
                    int dangMuon = Convert.ToInt32(row["SoDangMuon"]);
                    int quaHan = Convert.ToInt32(row["SoQuaHan"]);
                    dataDict[vaiTro] = (dangMuon, quaHan);
                }

                // Vẽ cột 
                foreach (var vt in vaiTroPhobien)
                {
                    int dm = dataDict.ContainsKey(vt) ? dataDict[vt].dangMuon : 0;
                    int qh = dataDict.ContainsKey(vt) ? dataDict[vt].quaHan : 0;

                    seriesDangMuon.Points.AddXY(vt, dm);
                    seriesQuaHan.Points.AddXY(vt, qh);
                }

                foreach (var kv in dataDict)
                {
                    if (!vaiTroPhobien.Contains(kv.Key))
                    {
                        seriesDangMuon.Points.AddXY(kv.Key, kv.Value.dangMuon);
                        seriesQuaHan.Points.AddXY(kv.Key, kv.Value.quaHan);
                    }
                }

                // Cấu hình biểu đồ
                var area = chartTinhHinhMuonTra.ChartAreas[0];
                area.AxisX.Title = "Vai trò";
                area.AxisY.Title = "Số lượng sách";
                area.AxisX.Interval = 1;
                area.AxisX.LabelStyle.Angle = 0;
                area.AxisX.LabelStyle.IsEndLabelVisible = true;


                area.AxisX.MajorGrid.Enabled = false;
                area.AxisY.MajorGrid.Enabled = false;
                area.Area3DStyle.Enable3D = false;

                chartTinhHinhMuonTra.Titles.Add(new Title(
                    "Tình hình mượn trả sách",
                    Docking.Top,
                    new Font("Segoe UI", 10, FontStyle.Bold),
                    Color.DarkGreen
                ));

                chartTinhHinhMuonTra.Legends[0].Enabled = true;
                chartTinhHinhMuonTra.Legends[0].Docking = Docking.Right;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi vẽ biểu đồ mượn trả:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTop3()
        {
            try
            {
                string sqlTop3 = @"
            SELECT TOP 3
                ROW_NUMBER() OVER (ORDER BY COUNT(mt.maPhieu) DESC) AS ThuHang,
                s.nhanDe, s.tacGia,
                COUNT(mt.maPhieu) AS SoLanMuon
            FROM Sach s
            LEFT JOIN MuonTra mt ON s.maSach = mt.maSach
            GROUP BY s.maSach, s.nhanDe, s.tacGia
            HAVING COUNT(mt.maPhieu) > 0
            ORDER BY SoLanMuon DESC";

                DataTable dtTop = DataAccess.ExecuteQuery(sqlTop3);
                dgvTopMuon.DataSource = dtTop;

                dgvTopMuon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvTopMuon.RowHeadersVisible = false;

                dgvTopMuon.Columns["ThuHang"].HeaderText = "TOP";
                dgvTopMuon.Columns["nhanDe"].HeaderText = "Nhan đề";
                dgvTopMuon.Columns["tacGia"].HeaderText = "Tác giả";
                dgvTopMuon.Columns["SoLanMuon"].HeaderText = "Lượt mượn";

                dgvTopMuon.Columns["ThuHang"].FillWeight = 60;   
                dgvTopMuon.Columns["nhanDe"].FillWeight = 200;  
                dgvTopMuon.Columns["tacGia"].FillWeight = 120;  
                dgvTopMuon.Columns["SoLanMuon"].FillWeight = 80;

                dgvTopMuon.Columns["ThuHang"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvTopMuon.Columns["SoLanMuon"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvTopMuon.Columns["ThuHang"].SortMode = DataGridViewColumnSortMode.NotSortable;
                dgvTopMuon.Columns["nhanDe"].SortMode = DataGridViewColumnSortMode.NotSortable;
                dgvTopMuon.Columns["tacGia"].SortMode = DataGridViewColumnSortMode.NotSortable;
                dgvTopMuon.Columns["SoLanMuon"].SortMode = DataGridViewColumnSortMode.NotSortable;

                dgvTopMuon.CellFormatting += (s, e) =>
                {
                    if (e.RowIndex >= 0 && e.RowIndex < 3)
                    {
                        if (e.ColumnIndex == dgvTopMuon.Columns["ThuHang"].Index)
                        {
                            e.Value = e.Value;
                            e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                        }

                        if (e.RowIndex == 0)
                            e.CellStyle.BackColor = Color.FromArgb(255, 215, 0); 
                        else if (e.RowIndex == 1)
                            e.CellStyle.BackColor = Color.FromArgb(192, 192, 192); 
                        else if (e.RowIndex == 2)
                            e.CellStyle.BackColor = Color.FromArgb(205, 127, 50); 
                    }
                };

                dgvTopMuon.ClearSelection();
                dgvTopMuon.CurrentCell = null;

                if (dtTop.Rows.Count == 0)
                {
                    dgvTopMuon.Rows.Add("Chưa có dữ liệu mượn sách", "", "", "");
                    dgvTopMuon.Rows[0].DefaultCellStyle.ForeColor = Color.Gray;
                    dgvTopMuon.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load Top 3: " + ex.Message);
            }
        }

        private void btnTimSach_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiemSach.Text.Trim();

            if (string.IsNullOrEmpty(tuKhoa))
            {
                LoadFullSach(); 
                return;
            }

            try
            {
                string sqlTim = @"
                    SELECT 
                        maSach, nhanDe, tacGia, soLuong,
                        ISNULL((SELECT COUNT(*) FROM MuonTra WHERE maSach = s.maSach AND trangThai IN (N'Đang mượn', N'Quá hạn')), 0) AS DangMuon,
                        soLuong - ISNULL((SELECT COUNT(*) FROM MuonTra WHERE maSach = s.maSach AND trangThai IN (N'Đang mượn', N'Quá hạn')), 0) AS HienCo
                    FROM Sach s
                    WHERE 
                        maSach LIKE '%' + @tuKhoa + '%'
                        OR nhanDe LIKE '%' + @tuKhoa + '%'
                        OR tacGia LIKE '%' + @tuKhoa + '%'
                    ORDER BY maSach";

                var param = new Dictionary<string, object> { { "@tuKhoa", tuKhoa } };
                DataTable dt = DataAccess.ExecuteQuery(sqlTim, param);
                dgvThongKeSach.DataSource = dt;

                // Đặt lại header sau khi lọc
                dgvThongKeSach.Columns["maSach"].HeaderText = "Mã sách";
                dgvThongKeSach.Columns["nhanDe"].HeaderText = "Nhan đề";
                dgvThongKeSach.Columns["tacGia"].HeaderText = "Tác giả";
                dgvThongKeSach.Columns["soLuong"].HeaderText = "Tổng SL";
                dgvThongKeSach.Columns["DangMuon"].HeaderText = "Đang mượn";
                dgvThongKeSach.Columns["HienCo"].HeaderText = "Hiện có";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }

        private void dgvThongKeSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (dgvThongKeSach.Columns[e.ColumnIndex].Name == "nhanDe")
            {
                string maSach = dgvThongKeSach.Rows[e.RowIndex].Cells["maSach"].Value?.ToString();
                if (string.IsNullOrEmpty(maSach)) return;

                string sqlSach = "SELECT * FROM Sach WHERE maSach = @ma";
                var paramSach = new Dictionary<string, object> { { "@ma", maSach } };
                DataTable dtSach = DataAccess.ExecuteQuery(sqlSach, paramSach);

                if (dtSach.Rows.Count > 0)
                {
                    var row = dtSach.Rows[0];
                    string infoSach = $@"
Mã sách: {row["maSach"]}
Nhan đề: {row["nhanDe"]}
Chủ đề: {row["chuDe"]}
Khoa: {row["khoa"]}
Ngành: {row["nganh"]}
Tác giả: {row["tacGia"]}
Vị trí: {row["viTri"]}";

                    string sqlMuon = @"
                        SELECT nd.hoTen, nd.vaiTro, mt.ngayMuon
                        FROM MuonTra mt
                        JOIN TaiKhoan nd ON mt.maNguoiDung = nd.maNguoiDung
                        WHERE mt.maSach = @ma
                        ORDER BY mt.ngayMuon DESC";

                    var paramMuon = new Dictionary<string, object> { { "@ma", maSach } };
                    DataTable dtMuon = DataAccess.ExecuteQuery(sqlMuon, paramMuon);

                    string infoMuon = "\nNgười mượn:\n";
                    if (dtMuon.Rows.Count == 0)
                        infoMuon += "Chưa có ai mượn sách này.";
                    else
                    {
                        foreach (DataRow r in dtMuon.Rows)
                        {
                            infoMuon += $"- {r["hoTen"]} ({r["vaiTro"]}) - Ngày mượn: {Convert.ToDateTime(r["ngayMuon"]).ToShortDateString()}\n";
                        }
                    }

                    MessageBox.Show(infoSach + infoMuon, "Chi tiết sách: " + row["nhanDe"], MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void LoadFullSach()
        {
            try
            {
                string sqlFull = @"
                    SELECT 
                        maSach, nhanDe, tacGia, soLuong,
                        ISNULL((SELECT COUNT(*) FROM MuonTra WHERE maSach = s.maSach AND trangThai IN (N'Đang mượn', N'Quá hạn')), 0) AS DangMuon,
                        soLuong - ISNULL((SELECT COUNT(*) FROM MuonTra WHERE maSach = s.maSach AND trangThai IN (N'Đang mượn', N'Quá hạn')), 0) AS HienCo
                    FROM Sach s
                    ORDER BY maSach";

                DataTable dt = DataAccess.ExecuteQuery(sqlFull);
                dgvThongKeSach.DataSource = dt;

                dgvThongKeSach.Columns["maSach"].HeaderText = "Mã sách";
                dgvThongKeSach.Columns["nhanDe"].HeaderText = "Nhan đề";
                dgvThongKeSach.Columns["tacGia"].HeaderText = "Tác giả";
                dgvThongKeSach.Columns["soLuong"].HeaderText = "Tổng SL";
                dgvThongKeSach.Columns["DangMuon"].HeaderText = "Đang mượn";
                dgvThongKeSach.Columns["HienCo"].HeaderText = "Hiện có";

                dgvThongKeSach.Columns["DangMuon"].DefaultCellStyle.ForeColor = Color.Red;
                dgvThongKeSach.Columns["HienCo"].DefaultCellStyle.ForeColor = Color.DarkGreen;

                dgvThongKeSach.Columns["maSach"].FillWeight = 80;    
                dgvThongKeSach.Columns["nhanDe"].FillWeight = 250;  
                dgvThongKeSach.Columns["tacGia"].FillWeight = 150;  
                dgvThongKeSach.Columns["soLuong"].FillWeight = 70;   
                dgvThongKeSach.Columns["DangMuon"].FillWeight = 70;
                dgvThongKeSach.Columns["HienCo"].FillWeight = 70;

                dgvThongKeSach.Columns["soLuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvThongKeSach.Columns["DangMuon"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvThongKeSach.Columns["HienCo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                
                dgvThongKeSach.RowHeadersVisible = false;
                dgvThongKeSach.ReadOnly = true;
                dgvThongKeSach.AllowUserToAddRows = false;
                dgvThongKeSach.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load danh sách sách: " + ex.Message);
            }
        }

        private void btnLamMoiThongKe_Click(object sender, EventArgs e)
        {


            txtTimKiemSach.Clear();

            VePieChart();
            VeBarChartMuonTra();
            LoadTop3();
            LoadFullSach();
        }
    }
}
