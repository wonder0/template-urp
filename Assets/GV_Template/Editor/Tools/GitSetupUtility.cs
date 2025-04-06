using UnityEditor;
using UnityEngine;
using System.Diagnostics;
using System.IO;

public class GitSetupUtility : EditorWindow
{
    [MenuItem("Tools/Git/Initialize Git Repository")]
    public static void InitializeGitRepository()
    {
        string projectRoot = Directory.GetParent(Application.dataPath).FullName;

        ProcessStartInfo startInfo = new ProcessStartInfo("/bin/bash", "-c \"git init\"")
        {
            WorkingDirectory = projectRoot,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            CreateNoWindow = true,
            UseShellExecute = false
        };

        Process process = Process.Start(startInfo);

        string output = process.StandardOutput.ReadToEnd();
        string error = process.StandardError.ReadToEnd();

        process.WaitForExit();

        if (process.ExitCode != 0)
        {
            EditorUtility.DisplayDialog("Error", $"Failed to initialize git repository: {error}", "OK");
            return;
        }

        EditorUtility.DisplayDialog("Success", "Git repository initialized", "OK");
    }

    [MenuItem("Tools/Git/Place .gitignore in Project Root")]
    public static void PlaceGitignore()
    {
        string editorScriptPath = GetEditorScriptPath();
        if (editorScriptPath == null)
        {
            UnityEngine.Debug.LogError("Failed to find script path.");
            return;
        }

        string sourcePath = Path.Combine(editorScriptPath, ".gitignore");
        string destPath = Path.Combine(Directory.GetParent(Application.dataPath).FullName, ".gitignore");

        if (!File.Exists(sourcePath))
        {
            EditorUtility.DisplayDialog("Error", ".gitignore file not found next to the script.", "OK");
            return;
        }

        if (File.Exists(destPath))
        {
            bool overwrite = EditorUtility.DisplayDialog(
                ".gitignore Exists",
                "A .gitignore already exists at the root. Overwrite it?",
                "Yes", "No"
            );

            if (!overwrite) return;
        }

        File.Copy(sourcePath, destPath, true);
        AssetDatabase.Refresh();
        EditorUtility.DisplayDialog("Success", ".gitignore file placed in project root.", "OK");
    }

    private static string GetEditorScriptPath()
    {
        string[] guids = AssetDatabase.FindAssets("GitSetupUtility t:Script");
        if (guids.Length == 0) return null;

        string assetPath = AssetDatabase.GUIDToAssetPath(guids[0]);
        string fullPath = Path.GetFullPath(assetPath);
        return Path.GetDirectoryName(fullPath);
    }
}

