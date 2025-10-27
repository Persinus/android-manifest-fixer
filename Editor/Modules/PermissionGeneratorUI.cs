using UnityEditor;
using UnityEngine;
using System.IO;


public static class PermissionGeneratorUI
{
    private static string[] lastRequested = new string[0];
    public static void Draw()
    {
        GUILayout.Label("🔐 Sinh script xin quyền runtime cho Unity", EditorStyles.boldLabel);
        GUILayout.Space(6);
        GUILayout.Label("Tool sẽ tạo 1 script C# (PermissionRequester.cs) trong Assets/Plugins/AndroidManifestFixer/ để gọi request runtime khi cần.");
        if (GUILayout.Button("Chọn quyền mẫu: AdMob (INTERNET, ACCESS_NETWORK_STATE)")) CreatePermissionRequester(new[] { "android.permission.INTERNET", "android.permission.ACCESS_NETWORK_STATE" });
        if (GUILayout.Button("Chọn quyền mẫu: Storage (READ/WRITE)", GUILayout.Height(26))) CreatePermissionRequester(new[] { "android.permission.READ_EXTERNAL_STORAGE", "android.permission.WRITE_EXTERNAL_STORAGE" });
        if (GUILayout.Button("Tùy chọn quyền...")) { var w = PermissionPickerWindow.ShowWindow(); }
    }


    public static void CreatePermissionRequester(string[] perms)
    {
        var folder = Path.Combine(Application.dataPath, "Plugins", "AndroidManifestFixer");
        if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);
        var path = Path.Combine(folder, "PermissionRequester.cs");
        var code = GenerateCode(perms);
        File.WriteAllText(path, code);
        AssetDatabase.Refresh();
        EditorUtility.DisplayDialog("OK", "Đã tạo PermissionRequester.cs tại: Assets/Plugins/AndroidManifestFixer/", "OK");
    }


    private static string GenerateCode(string[] perms)
    {
        var listInit = string.Join(", ", System.Array.ConvertAll(perms, p => "\"" + p + "\""));
        return $@"using UnityEngine;


public class PermissionRequester : MonoBehaviour
{{
private string[] req = new string[] {{
{listInit}
}};

void Start()
{{
foreach (var p in req)
{{
if (!UnityEngine.Android.Permission.HasUserAuthorizedPermission(p))
{{
UnityEngine.Android.Permission.RequestUserPermission(p);
}}
}}
}}
";
    }
}