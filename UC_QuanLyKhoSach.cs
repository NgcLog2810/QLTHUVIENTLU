using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;

namespace QUANLYTHUVIENTLU
{
    public partial class UC_QuanLyKhoSach : UserControl
    {
        public UC_QuanLyKhoSach()
        {
            InitializeComponent();
            
        }

        private void UC_QuanLyKhoSach_Load(object sender, EventArgs e)
        {
            // Load ComboBox trạng thái
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.AddRange(new string[] { "Mới", "Cũ", "Hỏng / Mất" });
            cboTrangThai.SelectedIndex = 0;

            TaiDuLieuLenGrid();
        }

        public void TaiDuLieuLenGrid()
        {
            try
            {
                dgvSach.SelectionChanged -= dgvSach_SelectionChanged; // tạm tắt event

                string sql = @"
                    SELECT 
                        maSach, nhanDe, chuDe, khoa, nganh, tacGia, 
                        namXuatBan, nhaXuatBan, soLuong, trangThaiSach, viTri,
                        ISNULL((
                            SELECT COUNT(*) FROM MuonTra 
                            WHERE maSach = s.maSach AND trangThai IN (N'Đang mượn', N'Quá hạn')
                        ), 0) AS DangMuon,
                        soLuong - ISNULL((
                            SELECT COUNT(*) FROM MuonTra 
                            WHERE maSach = s.maSach AND trangThai IN (N'Đang mượn', N'Quá hạn')
                        ), 0) AS HienCo
                    FROM Sach s
                    ORDER BY maSach";

                DataTable dt = DataAccess.ExecuteQuery(sql);
                dgvSach.DataSource = dt;

               
                dgvSach.Columns["maSach"].HeaderText = "Mã sách";
                dgvSach.Columns["nhanDe"].HeaderText = "Nhan đề";
                dgvSach.Columns["chuDe"].HeaderText = "Chủ đề";
                dgvSach.Columns["khoa"].HeaderText = "Khoa";
                dgvSach.Columns["nganh"].HeaderText = "Ngành";
                dgvSach.Columns["tacGia"].HeaderText = "Tác giả";
                dgvSach.Columns["namXuatBan"].HeaderText = "Năm XB";
                dgvSach.Columns["nhaXuatBan"].HeaderText = "Nhà XB";
                dgvSach.Columns["soLuong"].HeaderText = "Số lượng";
                dgvSach.Columns["trangThaiSach"].HeaderText = "Trạng thái";
                dgvSach.Columns["viTri"].HeaderText = "Vị trí";
                dgvSach.Columns["DangMuon"].HeaderText = "Đang mượn";
                dgvSach.Columns["HienCo"].HeaderText = "Hiện có";

                dgvSach.Columns["DangMuon"].DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
                dgvSach.Columns["HienCo"].DefaultCellStyle.ForeColor = System.Drawing.Color.DarkGreen;
                dgvSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvSach.ReadOnly = true;
                dgvSach.AllowUserToAddRows = false;
                dgvSach.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                dgvSach.ClearSelection();
                dgvSach.SelectionChanged += dgvSach_SelectionChanged; // bật lại event
            }

            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách sách:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvSach_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSach.SelectedRows.Count == 0) return;

            var row = dgvSach.SelectedRows[0];

            txtMaSach.Text = row.Cells["maSach"].Value?.ToString() ?? "";
            txtNhanDe.Text = row.Cells["nhanDe"].Value?.ToString() ?? "";
            txtChuDe.Text = row.Cells["chuDe"].Value?.ToString() ?? "";
            txtKhoa.Text = row.Cells["khoa"].Value?.ToString() ?? "";
            txtNganh.Text = row.Cells["nganh"].Value?.ToString() ?? "";
            txtTacGia.Text = row.Cells["tacGia"].Value?.ToString() ?? "";
            txtNamXB.Text = row.Cells["namXuatBan"].Value?.ToString() ?? "";
            txtNhaXB.Text = row.Cells["nhaXuatBan"].Value?.ToString() ?? "";
            nudSoLuong.Value = Convert.ToDecimal(row.Cells["soLuong"].Value ?? 0);
            cboTrangThai.SelectedItem = row.Cells["trangThaiSach"].Value?.ToString() ?? "Mới";
            txtViTri.Text = row.Cells["viTri"].Value?.ToString() ?? "";

            txtMaSach.ReadOnly = true;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaSach.Clear();
            txtNhanDe.Clear();
            txtChuDe.Clear();
            txtKhoa.Clear();
            txtNganh.Clear();
            txtTacGia.Clear();
            txtNamXB.Clear();
            txtNhaXB.Clear();
            txtViTri.Clear();
            nudSoLuong.Value = 0;
            cboTrangThai.SelectedIndex = 0;

            txtMaSach.ReadOnly = false;
            txtMaSach.Focus();

            dgvSach.SelectionChanged -= dgvSach_SelectionChanged;

            TaiDuLieuLenGrid();

            dgvSach.ClearSelection();

            dgvSach.SelectionChanged += dgvSach_SelectionChanged;

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieu()) return;

            string ma = txtMaSach.Text.Trim();

            string sqlCheck = "SELECT COUNT(*) FROM Sach WHERE maSach = @ma";
            int tonTai = Convert.ToInt32(DataAccess.ExecuteScalar(sqlCheck, new Dictionary<string, object> { { "@ma", ma } }));
            if (tonTai > 0)
            {
                MessageBox.Show("Mã sách đã tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sqlInsert = @"
                INSERT INTO Sach (maSach, nhanDe, chuDe, khoa, nganh, tacGia, namXuatBan, nhaXuatBan, soLuong, trangThaiSach, viTri)
                VALUES (@ma, @nd, @cd, @khoa, @nganh, @tg, @nxb, @nxbt, @sl, @tt, @vt)";

            var param = new Dictionary<string, object>
            {
                { "@ma", ma },
                { "@nd", txtNhanDe.Text.Trim() },
                { "@cd", txtChuDe.Text.Trim() },
                { "@khoa", txtKhoa.Text.Trim() },
                { "@nganh", txtNganh.Text.Trim() },
                { "@tg", txtTacGia.Text.Trim() },
                { "@nxb", int.TryParse(txtNamXB.Text, out int nam) ? nam : (object)DBNull.Value },
                { "@nxbt", txtNhaXB.Text.Trim() },
                { "@sl", (int)nudSoLuong.Value },
                { "@tt", cboTrangThai.SelectedItem?.ToString() ?? "Mới" },
                { "@vt", txtViTri.Text.Trim() }
            };

            try
            {
                DataAccess.ExecuteNonQuery(sqlInsert, param);
                MessageBox.Show("Thêm sách thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TaiDuLieuLenGrid();
                btnLamMoi.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm sách:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSach.Text))
            {
                MessageBox.Show("Vui lòng chọn sách từ bảng để sửa!", "Cảnh báo");
                return;
            }

            if (!KiemTraDuLieu()) return;

            if (MessageBox.Show("Xác nhận cập nhật thông tin sách?", "Xác nhận", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            string sqlUpdate = @"
                UPDATE Sach SET 
                    nhanDe = @nd, chuDe = @cd, khoa = @khoa, nganh = @nganh,
                    tacGia = @tg, namXuatBan = @nxb, nhaXuatBan = @nxbt,
                    soLuong = @sl, trangThaiSach = @tt, viTri = @vt
                WHERE maSach = @ma";

            var param = new Dictionary<string, object>
            {
                { "@ma", txtMaSach.Text.Trim() },
                { "@nd", txtNhanDe.Text.Trim() },
                { "@cd", txtChuDe.Text.Trim() },
                { "@khoa", txtKhoa.Text.Trim() },
                { "@nganh", txtNganh.Text.Trim() },
                { "@tg", txtTacGia.Text.Trim() },
                { "@nxb", int.TryParse(txtNamXB.Text, out int nam) ? nam : (object)DBNull.Value },
                { "@nxbt", txtNhaXB.Text.Trim() },
                { "@sl", (int)nudSoLuong.Value },
                { "@tt", cboTrangThai.SelectedItem?.ToString() ?? "Mới" },
                { "@vt", txtViTri.Text.Trim() }
            };

            try
            {
                DataAccess.ExecuteNonQuery(sqlUpdate, param);
                MessageBox.Show("Cập nhật thành công!", "Thành công");
                TaiDuLieuLenGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật:\n" + ex.Message, "Lỗi");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSach.Text))
            {
                MessageBox.Show("Vui lòng chọn sách từ bảng để xóa!", "Cảnh báo");
                return;
            }

            string ma = txtMaSach.Text.Trim();
            string ten = txtNhanDe.Text.Trim();

            string sqlCheck = "SELECT COUNT(*) FROM MuonTra WHERE maSach = @ma AND trangThai IN (N'Đang mượn', N'Quá hạn')";
            int dangMuon = Convert.ToInt32(DataAccess.ExecuteScalar(sqlCheck, new Dictionary<string, object> { { "@ma", ma } }));

            if (dangMuon > 0)
            {
                MessageBox.Show($"Không thể xóa! Sách này đang có {dangMuon} phiếu mượn chưa trả.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Xác nhận xóa sách '{ten}' (Mã: {ma})?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                string sqlDelete = "DELETE FROM Sach WHERE maSach = @ma";
                DataAccess.ExecuteNonQuery(sqlDelete, new Dictionary<string, object> { { "@ma", ma } });
                MessageBox.Show("Xóa thành công!", "Thành công");
                TaiDuLieuLenGrid();
                btnLamMoi.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa sách:\n" + ex.Message, "Lỗi");
            }
        }

        private bool KiemTraDuLieu()
        {
            if (string.IsNullOrWhiteSpace(txtMaSach.Text))
            {
                MessageBox.Show("Mã sách không được để trống!", "Cảnh báo");
                txtMaSach.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtNhanDe.Text))
            {
                MessageBox.Show("Nhan đề không được để trống!", "Cảnh báo");
                txtNhanDe.Focus();
                return false;
            }
            return true;
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();

            if (string.IsNullOrEmpty(tuKhoa))
            {
                TaiDuLieuLenGrid();
                return;
            }

            try
            {
                string sql = @"
            SELECT 
                maSach, nhanDe, chuDe, khoa, nganh, tacGia, 
                namXuatBan, nhaXuatBan, soLuong, trangThaiSach, viTri,
                ISNULL((SELECT COUNT(*) FROM MuonTra 
                        WHERE maSach = s.maSach 
                        AND trangThai IN (N'Đang mượn', N'Quá hạn')), 0) AS DangMuon,
                soLuong - ISNULL((SELECT COUNT(*) FROM MuonTra 
                                  WHERE maSach = s.maSach 
                                  AND trangThai IN (N'Đang mượn', N'Quá hạn')), 0) AS HienCo
            FROM Sach s
            WHERE 
                maSach COLLATE SQL_Latin1_General_CP1_CI_AI LIKE '%' + @tuKhoa + '%'
                OR nhanDe COLLATE SQL_Latin1_General_CP1_CI_AI LIKE '%' + @tuKhoa + '%'
                OR chuDe COLLATE SQL_Latin1_General_CP1_CI_AI LIKE '%' + @tuKhoa + '%'
                OR khoa COLLATE SQL_Latin1_General_CP1_CI_AI LIKE '%' + @tuKhoa + '%'
                OR nganh COLLATE SQL_Latin1_General_CP1_CI_AI LIKE '%' + @tuKhoa + '%'
                OR tacGia COLLATE SQL_Latin1_General_CP1_CI_AI LIKE '%' + @tuKhoa + '%'
                OR nhaXuatBan COLLATE SQL_Latin1_General_CP1_CI_AI LIKE '%' + @tuKhoa + '%'
                OR trangThaiSach COLLATE SQL_Latin1_General_CP1_CI_AI LIKE '%' + @tuKhoa + '%'
                OR viTri COLLATE SQL_Latin1_General_CP1_CI_AI LIKE '%' + @tuKhoa + '%'
                OR CAST(namXuatBan AS NVARCHAR) LIKE '%' + @tuKhoa + '%'
            ORDER BY maSach";

                var param = new Dictionary<string, object> { { "@tuKhoa", tuKhoa } };
                DataTable dt = DataAccess.ExecuteQuery(sql, param);
                dgvSach.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lọc: " + ex.Message);
            }
        }
    }
}