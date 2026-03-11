# QLTHUVIENTLU

📚 Hướng dẫn làm việc với Project (GitHub)
1. Clone project về máy

Vào repository GitHub → bấm Code → Copy link

Sau đó mở Terminal / Git Bash / CMD và chạy:

git clone https://github.com/NgcLog2810/QLTHUVIENTLU.git

Sau khi clone xong:

cd QLTHUVIENTLU
2. Mỗi thành viên làm việc trong thư mục của mình

Ví dụ:

QUANLYTHUVIENTLU/
│
├── thanhvien_A/
├── thanhvien_B/
├── thanhvien_C/

Mỗi người chỉ sửa phần của mình để tránh xung đột code.

3. Trước khi code nên cập nhật project mới nhất
git pull origin main

Lệnh này giúp lấy code mới nhất từ GitHub về máy.

4. Sau khi code xong

Kiểm tra file đã thay đổi:

git status
5. Thêm file vào Git

Nếu muốn thêm toàn bộ thay đổi:

git add .

Hoặc chỉ thêm thư mục cá nhân:

git add ten_thu_muc_cua_ban
6. Commit code
git commit -m "Cập nhật chức năng ..."

Ví dụ:

git commit -m "Thêm chức năng quản lý sách"
7. Đồng bộ code trước khi push

Để tránh xung đột:

git pull origin main
8. Push code lên GitHub
git push origin main
⚠️ Một số lỗi thường gặp
1. Push bị từ chối (rejected)

Do có người khác đã push code.

Chạy:

git pull origin main
git push origin main
2. Conflict (xung đột code)

Xảy ra khi 2 người sửa cùng 1 file.

Cách tốt nhất:

Mỗi người làm thư mục riêng

Hoặc làm file riêng

📌 Quy trình làm việc chuẩn

Mỗi lần code xong chỉ cần chạy:

git add .
git commit -m "noi dung cap nhat"
git pull origin main
git push origin main
