# Android Manifest Fixer (UPM)


Công cụ Unity Editor (UPM) để:
- Dò plugin/AAR/JAR gây lỗi (ví dụ Duplicate class) bằng cách scan file `classes.jar` trong AAR/JAR.
- Tự động chèn `uses-permission` hoặc đoạn manifest (provider/meta-data) vào AndroidManifest.xml (có backup trước khi ghi).
- Sinh file C# helper (PermissionRequester.cs) để xin quyền runtime trong Unity (sử dụng UnityEngine.Android.Permission API) cho các quyền cần runtime.
- Giao diện tiếng Việt, thao tác bằng GUI, không sử dụng jadx.


## Cài đặt
- Copy folder `com.manhtool.androidmanifestfixer` vào `Packages/` của project Unity hoặc Add package from disk trong Package Manager.
- Mở `Tools -> Android Manifest Fixer` trong Unity.
