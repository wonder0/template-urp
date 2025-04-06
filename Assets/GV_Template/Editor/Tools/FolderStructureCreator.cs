using UnityEngine;
using UnityEditor;
using System.IO;

public class FolderStructureCreator : EditorWindow
{
    [MenuItem("Tools/Create Folder Structure")]
    public static void ShowWindow()
    {
        CreateFolders();
    }

    private static void CreateFolders()
    {
        string[] folders = new string[]
        {
            "Assets/_Project",
            "Assets/_Project/Art",
            "Assets/_Project/Art/Animations",
            "Assets/_Project/Art/Materials",
            "Assets/_Project/Art/Models",
            "Assets/_Project/Art/Textures",
            "Assets/_Project/Art/UI",
            "Assets/_Project/Audio",
            "Assets/_Project/Audio/Music",
            "Assets/_Project/Audio/SFX",
            "Assets/_Project/Audio/Voice",
            "Assets/_Project/Prefabs",
            "Assets/_Project/Scenes",
            "Assets/_Project/Scripts",
            "Assets/_Project/Scripts/Managers",
            "Assets/_Project/Scripts/Characters",
            "Assets/_Project/Scripts/UI",
            "Assets/_Project/Scripts/Utilities",
            "Assets/_Project/Resources",
            "Assets/_Project/Shaders",
            "Assets/_Project/Plugins",
            "Assets/Editor",
            "Assets/ThirdParty",
            "Assets/ThirdParty/Assets",
            "Assets/ThirdParty/Plugins",
            "Assets/Tests",
            "Assets/Tests/EditMode",
            "Assets/Tests/PlayMode",
            "Assets/Settings"
        };

        foreach (string folder in folders)
        {
            if (!AssetDatabase.IsValidFolder(folder))
            {
                Directory.CreateDirectory(folder);
            }

            string keepFilePath = Path.Combine(folder, ".keep");
            if (!File.Exists(keepFilePath))
            {
                File.Create(keepFilePath).Dispose();
            }
        }

        AssetDatabase.Refresh();
    }
}
