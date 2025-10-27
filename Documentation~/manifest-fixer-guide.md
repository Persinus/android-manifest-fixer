# Android Manifest Fixer — Hướng dẫn sử dụng

## 🎯 Mục tiêu
Công cụ giúp bạn:
- Phát hiện lỗi `Duplicate class` từ log Gradle.
- Xác định plugin gây xung đột.
- Chèn hoặc gợi ý thêm quyền (`permissions`) vào AndroidManifest.xml.
- Sinh sẵn script xin quyền runtime trong `Samples~/ExamplePermissionRequester`.

---

## ⚙️ Cách mở công cụ
**Menu:**  
`Tools → Android → Manifest Fixer`

Cửa sổ gồm 3 tab chính:
1. **Phát hiện Plugin:** chọn log `Gradle` và phân tích lỗi `Duplicate class`.
2. **Chèn Quyền:** tick chọn quyền cần thêm, tool sẽ tự cập nhật `AndroidManifest.xml`.
3. **Preview Diff:** hiển thị thay đổi trước khi lưu, bạn có thể confirm hoặc rollback.

---

## 🧠 Gợi ý thêm quyền tự động
Một số ví dụ:
| Mục đích | Permission | Ghi chú |
|-----------|-------------|---------|
| AdMob / Ads | `android.permission.INTERNET` | Bắt buộc |
| Ghi file | `android.permission.WRITE_EXTERNAL_STORAGE` | Android < 10 |
| Chụp ảnh | `android.permission.CAMERA` | Cần xin runtime |
| Kết nối WiFi | `android.permission.ACCESS_WIFI_STATE` | Tự động thêm nếu chọn module WiFi |

---

## 💡 Ví dụ runtime permission
Tham khảo trong `Samples~/ExamplePermissionRequester/PermissionRequester.cs`.

---

## 🧰 Tự động sửa Manifest
Khi chọn “Thêm quyền”, tool sẽ:
- Đọc file `AndroidManifest.xml` trong `Plugins/Android/`.
- Tự thêm `<uses-permission>` nếu chưa có.
- Cho phép xem **preview diff** trước khi ghi.

---

## 🧩 Ghi chú thêm
- Tool này không can thiệp build pipeline.
- Có thể tích hợp thêm module kiểm tra SDK/Gradle trong tương lai.
