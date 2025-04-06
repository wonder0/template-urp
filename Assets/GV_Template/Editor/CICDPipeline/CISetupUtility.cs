using UnityEditor;
using UnityEngine;
using System.IO;

public class CISetupUtility : EditorWindow
{
    [MenuItem("Tools/Git/Setup GitHub CICD")]
    public static void SetupGitHubCI()
    {
        string editorScriptPath = GetEditorScriptPath();
        if (editorScriptPath == null)
        {
            Debug.LogError("Could not find script path.");
            return;
        }

        string sourceCIPath = Path.Combine(editorScriptPath, "main.yml");
        string targetDir = Path.Combine(Directory.GetParent(Application.dataPath).FullName, ".github", "workflows");
        string targetCIPath = Path.Combine(targetDir, "main.yml");

        if (!File.Exists(sourceCIPath))
        {
            EditorUtility.DisplayDialog("Error", "main.yml not found in script folder.", "OK");
            return;
        }

        Directory.CreateDirectory(targetDir);

        if (File.Exists(targetCIPath))
        {
            bool overwrite = EditorUtility.DisplayDialog("CI Workflow Exists", "A CI file already exists. Overwrite?", "Yes", "No");
            if (!overwrite) return;
        }

        File.Copy(sourceCIPath, targetCIPath, true);
        EditorUtility.DisplayDialog("Success", "CI/CD workflow placed in .github/workflows/", "OK");
    }

    private static string GetEditorScriptPath()
    {
        string[] guids = AssetDatabase.FindAssets("CISetupUtility t:Script");
        if (guids.Length == 0) return null;

        string assetPath = AssetDatabase.GUIDToAssetPath(guids[0]);
        string fullPath = Path.GetFullPath(assetPath);
        return Path.GetDirectoryName(fullPath);
    }
}
