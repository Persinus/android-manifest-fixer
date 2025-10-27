using System.IO;
using UnityEngine;


public static class GradleHelpers
{
    public static string FindAnyManifest()
    {
        var root = Directory.GetParent(Application.dataPath).FullName;
        var cand = Directory.GetFiles(root, "AndroidManifest.xml", SearchOption.AllDirectories);
        if (cand.Length > 0) return cand[0];
        return null;
    }
}