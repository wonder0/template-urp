using UnityEditor;
using UnityEngine;
using System.IO;

public static class MoveToThirdParty
{
    private const string THIRD_PARTY_ROOT = "Assets/ThirdParty";

    [MenuItem("Assets/Move to ThirdParty/Assets", false, 20)]
    private static void MoveToAssetsFolder()
    {
        MoveSelectedFolder("Assets");
    }

    [MenuItem("Assets/Move to ThirdParty/Plugins", false, 21)]
    private static void MoveToPluginsFolder()
    {
        MoveSelectedFolder("Plugins");
    }

    [MenuItem("Assets/Move to ThirdParty/Assets", true)]
    [MenuItem("Assets/Move to ThirdParty/Plugins", true)]
    private static bool ValidateFolderSelection()
    {
        if (Selection.assetGUIDs.Length != 1)
            return false;

        string path = AssetDatabase.GUIDToAssetPath(Selection.assetGUIDs[0]);
        return AssetDatabase.IsValidFolder(path);
    }

    private static void MoveSelectedFolder(string subfolder)
    {
        string selectedGUID = Selection.assetGUIDs[0];
        string sourcePath = AssetDatabase.GUIDToAssetPath(selectedGUID);
        string folderName = Path.GetFileName(sourcePath);
        string targetPath = Path.Combine(THIRD_PARTY_ROOT, subfolder, folderName).Replace("\\", "/");

        if (AssetDatabase.IsValidFolder(targetPath))
        {
            EditorUtility.DisplayDialog("Move Failed", $"Folder already exists at {targetPath}", "OK");
            return;
        }

        string parentFolder = Path.Combine(THIRD_PARTY_ROOT, subfolder).Replace("\\", "/");
        if (!AssetDatabase.IsValidFolder(parentFolder))
        {
            Directory.CreateDirectory(parentFolder);
            AssetDatabase.Refresh();
        }

        string error = AssetDatabase.MoveAsset(sourcePath, targetPath);
        if (!string.IsNullOrEmpty(error))
        {
            Debug.LogError("Move failed: " + error);
        }
        else
        {
            Debug.Log($"✅ Moved '{folderName}' to {targetPath}");
        }
    }
}
