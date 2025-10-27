# Android Manifest Fixer (UPM)

Công cụ Unity Editor (UPM) giúp phát hiện và khắc phục lỗi Android Manifest một cách trực quan.

## 🔧 Tính năng chính
- **Dò plugin/AAR/JAR gây lỗi** (ví dụ: Duplicate class) bằng cách scan các file `classes.jar` trong AAR/JAR và so khớp tên class từ log Gradle.
- **Tự động chèn quyền hoặc đoạn manifest** (`uses-permission`, `provider`, `meta-data`, ...) vào `AndroidManifest.xml`. Công cụ tự động **backup trước khi ghi**.
- **Sinh script xin quyền runtime** (`PermissionRequester.cs`) cho các quyền cần xin trong Android (sử dụng `UnityEngine.Android.Permission` API).
- **Hoàn toàn bằng GUI (IMGUI)**, hỗ trợ tiếng Việt, dễ dùng cho mọi dev Unity.
- **Không sử dụng jadx** — nhẹ, thuần Unity C#.
- **Preview diff trước khi ghi file** (xem thay đổi trước khi lưu).

---

## 📦 Cài đặt

### Cách 1: Thêm trực tiếp vào project
1. Clone hoặc tải thư mục package này về:
   ```bash
   git clone https://github.com/<yourname>/android-manifest-fixer.git
   ```
2. Copy folder `com.manhtool.androidmanifestfixer` vào thư mục `Packages/` trong project Unity của bạn.

### Cách 2: Add từ Unity Package Manager
1. Mở Unity → `Window → Package Manager`  
2. Chọn menu `+` → **Add package from disk...**  
3. Chọn file `package.json` trong thư mục `com.persinus.androidmanifestfixer`

---

## 🚀 Cách sử dụng

### Mở công cụ
Vào Unity menu:
```
Tools → Android Manifest Fixer
```

### Dò lỗi Duplicate class
1. Trong tab **Phát hiện lỗi**, dán log lỗi từ Gradle Console (ví dụ: `Duplicate class com.google.android.gms.ads.AdListener...`)
2. Tool sẽ tự trích tên class (`com.google.android.gms.ads.AdListener`) và quét các file `.aar` hoặc `.jar` trong thư mục `Assets/Plugins/Android` để xác định plugin gây lỗi.

### Sửa Manifest tự động
1. Chọn tab **Sửa Manifest**
2. Bấm **Tải AndroidManifest.xml**
3. Chọn quyền (VD: `android.permission.ACCESS_NETWORK_STATE`, `android.permission.INTERNET`, `com.google.android.gms.ads.APPLICATION_ID`, ...)
4. Bấm **Thêm quyền**
5. Tool sẽ hiển thị **preview diff** để xác nhận trước khi lưu.

### Xin quyền runtime
1. Tool có thể sinh file ví dụ `Samples~/ExamplePermissionRequester/PermissionRequester.cs`
2. Dùng script này trong code game để xin quyền khi cần.

---

## 📁 Cấu trúc thư mục

```
com.manhtool.androidmanifestfixer/
│
├─ Editor/
│  ├─ AndroidManifestFixerWindow.cs
│  ├─ ManifestUtils.cs
│  ├─ GradleErrorAnalyzer.cs
│  └─ ManifestAutoFixer.cs
│
├─ Resources/
│  ├─ icon.png
│  └─ hero.png
│
├─ Samples~/
│  ├─ ExamplePermissionRequester/
│  │  └─ PermissionRequester.cs
│  └─ ExampleManifest/
│     └─ AndroidManifest.xml
│
└─ Documentation~/
   └─ manifest-fixer-guide.md
```

---

## 🧩 Kế hoạch nâng cấp
- [ ] Tự động rollback nếu sửa lỗi sai
- [ ] Hệ thống plugin rule (mỗi SDK có rule riêng)
- [ ] Hỗ trợ multi-variant (debug/release)
- [ ] UI Toolkit (USS) theme đẹp như Photon
- [ ] Diff editor trực quan hơn

---

**Tác giả:** Nguyễn Văn Mạnh  
**Phiên bản:** 0.1.0  
**Giấy phép:** MIT
