# 📖 QLTHUVIENTLU
Project quản lý thư viện - môn Lập trình Windows

## 1. Clone project về máy

Vào repository GitHub → bấm **Code → Copy link**

Sau đó mở **Terminal / Git Bash / CMD** và chạy:

```bash
git clone https://github.com/NgcLog2810/QLTHUVIENTLU.git
```

Sau khi clone xong:

```bash
cd QLTHUVIENTLU
```

---

# 2. Mỗi thành viên làm việc trong thư mục của mình

Ví dụ cấu trúc:

```
QUANLYTHUVIENTLU/
│
├── thanhvien_A/
├── thanhvien_B/
├── thanhvien_C/
```

Mỗi người **chỉ sửa phần của mình** để tránh xung đột code.

---

# 3. Trước khi code nên cập nhật project mới nhất

```bash
git pull origin main
```

Lệnh này giúp lấy **code mới nhất từ GitHub về máy**.

---

# 4. Sau khi code xong

Kiểm tra file đã thay đổi:

```bash
git status
```

---

# 5. Thêm file vào Git

Nếu muốn thêm toàn bộ thay đổi:

```bash
git add .
```

Hoặc chỉ thêm thư mục cá nhân:

```bash
git add ten_thu_muc_cua_ban
```

---

# 6. Commit code

```bash
git commit -m "Cap nhat chuc nang ..."
```

Ví dụ:

```bash
git commit -m "Them chuc nang quan ly sach"
```

---

# 7. Đồng bộ code trước khi push

Để tránh xung đột:

```bash
git pull origin main
```

---

# 8. Push code lên GitHub

```bash
git push origin main
```

---

# ⚠️ Một số lỗi thường gặp

## Push bị từ chối (rejected)

Do có người khác đã push code.

Chạy:

```bash
git pull origin main
git push origin main
```

---

## Conflict (xung đột code)

Xảy ra khi **2 người sửa cùng 1 file**.

Cách tốt nhất:

- Mỗi người làm **thư mục riêng**
- Hoặc làm **file riêng**

---

# 📌 Quy trình làm việc chuẩn

Sau khi code xong chỉ cần chạy:

```bash
git add .
git commit -m "noi dung cap nhat"
git pull origin main
git push origin main
```
