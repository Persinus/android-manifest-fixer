using UnityEditor;
using UnityEngine;


public static class FixerSettings
{
    const string KEY = "AndroidManifestFixer_Settings";
    public static string LastManifestPath = "";
    public static void Load() { if (EditorPrefs.HasKey(KEY)) { JsonUtility.FromJsonOverwrite(EditorPrefs.GetString(KEY), typeof(FixerSettingsData)); LastManifestPath = JsonUtility.FromJson<FixerSettingsData>(EditorPrefs.GetString(KEY)).lastManifest; } }
    public static void Save() { var d = new FixerSettingsData { lastManifest = LastManifestPath }; EditorPrefs.SetString(KEY, JsonUtility.ToJson(d)); }
    [System.Serializable] private class FixerSettingsData { public string lastManifest; }
}