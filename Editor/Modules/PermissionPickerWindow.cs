using UnityEditor;
using UnityEngine;


public class PermissionPickerWindow : EditorWindow
{
    private string permsText = "android.permission.INTERNET,android.permission.ACCESS_NETWORK_STATE";
    public static PermissionPickerWindow ShowWindow() { var w = GetWindow<PermissionPickerWindow>("Permission Picker"); w.minSize = new Vector2(400, 140); return w; }
    void OnGUI()
    {
        GUILayout.Label("Nhập danh sách quyền cách nhau bởi dấu phẩy", EditorStyles.boldLabel);
        permsText = EditorGUILayout.TextField(permsText);
        if (GUILayout.Button("Tạo PermissionRequester")) { var arr = permsText.Split(','); PermissionGeneratorUI.CreatePermissionRequester(arr); Close(); }
    }
}

