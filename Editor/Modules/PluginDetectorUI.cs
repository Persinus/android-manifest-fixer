using UnityEditor;
using UnityEngine;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
using System.Linq;


public static class PluginDetectorUI
{
    private static string scanFolder = "";
    private static Vector2 scroll;
    private static List<PluginMatch> matches = new List<PluginMatch>();
    private static string searchClass = "";


    public static void Draw()
    {
        GUILayout.Label("🔎 Phát hiện plugin/AAR gây lỗi (Duplicate class/Conflict)", EditorStyles.boldLabel);
        GUILayout.Space(6);


        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Thư mục quét:", GUILayout.Width(90));
        scanFolder = EditorGUILayout.TextField(scanFolder);
        if (GUILayout.Button("Chọn", GUILayout.Width(80))) { var p = EditorUtility.OpenFolderPanel("Chọn thư mục để quét", Application.dataPath, ""); if (!string.IsNullOrEmpty(p)) scanFolder = p; }
        if (GUILayout.Button("Quét mặc định Plugins/Android", GUILayout.Width(200))) { scanFolder = Path.Combine(Directory.GetParent(Application.dataPath).FullName, "Assets", "Plugins", "Android"); }
        EditorGUILayout.EndHorizontal();


        GUILayout.Space(6);
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Tên class tìm (ví dụ com/google/ads/AdRequest)", GUILayout.Width(300));
        searchClass = EditorGUILayout.TextField(searchClass);
        if (GUILayout.Button("Tìm trong AAR/JAR", GUILayout.Width(140))) { RunScan(); }
        EditorGUILayout.EndHorizontal();


        GUILayout.Space(8);
        scroll = EditorGUILayout.BeginScrollView(scroll);
        foreach (var m in matches)
        {
            EditorGUILayout.BeginVertical("box");
            EditorGUILayout.LabelField(m.filePath, EditorStyles.boldLabel);
            EditorGUILayout.LabelField($"Loại: {m.kind} Số class tìm thấy: {m.found.Count}");
            if (m.found.Count > 0)
            {
                foreach (var f in m.found) EditorGUILayout.LabelField(" - " + f);
                if (GUILayout.Button("Mở vị trí file")) { EditorUtility.RevealInFinder(m.filePath); }
                if (GUILayout.Button("Gợi ý chèn quyền / manifest")) { OfferSuggestionsFor(m); }
            }
            EditorGUILayout.EndVertical();
            GUILayout.Space(4);
        }
        EditorGUILayout.EndScrollView();
    }


    private static void RunScan()
    {
        matches.Clear();
        if (string.IsNullOrEmpty(scanFolder) || !Directory.Exists(scanFolder)) { EditorUtility.DisplayDialog("Lỗi", "Thư mục quét không hợp lệ.", "OK"); return; }
    }
}