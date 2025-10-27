using UnityEditor;
using UnityEngine;


public class AndroidManifestFixerWindow : EditorWindow
{
    private int tab = 0;
    private readonly string[] tabs = new[] { "Phát hiện plugin", "Manifest", "Xin quyền runtime", "Cài đặt" };


    [MenuItem("Tools/Android Manifest Fixer")]
    public static void ShowWindow() { GetWindow<AndroidManifestFixerWindow>("Manifest Fixer"); }


    private void OnEnable() { FixerSettings.Load(); }


    private void OnGUI()
    {
        GUILayout.Space(8);
        tab = GUILayout.Toolbar(tab, tabs);
        GUILayout.Space(8);
        switch (tab)
        {
            case 0: PluginDetectorUI.Draw(); break;
            case 1: ManifestModifierUI.Draw(); break;
            case 2: PermissionGeneratorUI.Draw(); break;
            case 3: SettingsUI.Draw(); break;
        }
    }
}