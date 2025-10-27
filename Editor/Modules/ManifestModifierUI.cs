using UnityEditor;
using UnityEngine;
using System.IO;
using System.Xml;


public static class ManifestModifierUI
{
    private static string manifestPath = "";
    private static XmlDocument doc = null;
    private static Vector2 scroll;


    public static void Draw()
    {
        GUILayout.Label("📄 Manifest Modifier", EditorStyles.boldLabel);
        GUILayout.Space(6);


        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Manifest (xml):", GUILayout.Width(100));
        manifestPath = EditorGUILayout.TextField(manifestPath);
        if (GUILayout.Button("Tự động tìm (Temp/gradleOut)", GUILayout.Width(220)))
        {
            var p = GradleHelpers.FindAnyManifest();
            if (!string.IsNullOrEmpty(p)) manifestPath = p; else EditorUtility.DisplayDialog("Không tìm thấy", "Hãy chọn tay.", "OK");
        }
        if (GUILayout.Button("Chọn file", GUILayout.Width(90))) { var p = EditorUtility.OpenFilePanel("Chọn AndroidManifest.xml", "", "xml"); if (!string.IsNullOrEmpty(p)) manifestPath = p; }
        EditorGUILayout.EndHorizontal();


        if (GUILayout.Button("Load Manifest", GUILayout.Height(26))) { LoadManifest(); }
        GUILayout.Space(8);


        if (doc != null)
        {
            GUILayout.Label("Quyền hiện có:", EditorStyles.boldLabel);
            scroll = EditorGUILayout.BeginScrollView(scroll, GUILayout.Height(120));
            var perms = doc.GetElementsByTagName("uses-permission");
            for (int i = 0; i < perms.Count; i++) { var a = perms[i].Attributes["android:name"]; if (a != null) EditorGUILayout.LabelField(a.Value); }
            EditorGUILayout.EndScrollView();


            GUILayout.Space(6);
            if (GUILayout.Button("Chèn quyền thủ công", GUILayout.Height(26))) { var p = EditorUtility.DisplayDialogComplex("Chèn quyền", "Chọn nhóm quyền để chèn:", "AdMob", "WiFi", "Hủy"); if (p == 0) InsertPermissionsInteractive(new[] { "android.permission.INTERNET", "android.permission.ACCESS_NETWORK_STATE" }); if (p == 1) InsertPermissionsInteractive(new[] { "android.permission.ACCESS_WIFI_STATE", "android.permission.CHANGE_WIFI_STATE" }); }


            if (GUILayout.Button("Chèn FileProvider mẫu vào <application>", GUILayout.Height(26))) { InsertProviderInteractive(); }
            if (GUILayout.Button("Tạo backup và Lưu manifest", GUILayout.Height(26))) { SaveManifestWithBackup(); }
        }
    }


    public static void LoadManifest()
    {
        if (string.IsNullOrEmpty(manifestPath) || !File.Exists(manifestPath)) { EditorUtility.DisplayDialog("Lỗi", "Manifest không tồn tại.", "OK"); return; }
        doc = new XmlDocument();
        // Android manifest uses namespace android, add namespace manager when needed
    }
}