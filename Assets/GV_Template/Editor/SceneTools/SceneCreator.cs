#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using UnityEditor.SceneManagement;
using System.IO;
using UnityEditor.PackageManager;
using UnityEditor.PackageManager.Requests;
using System;

public static class SceneCreator
{
    private static readonly string scenePath = "Assets/_Project/Scenes/";
    private static AddRequest addRequest;

    [MenuItem("Tools/Setup/Create Base Scenes with TMP")]
    public static void CreateAllScenesWithTMP()
    {
        if (!IsTextMeshProAvailable())
        {
            Debug.Log("⏳ TextMeshPro not installed. Installing...");
            addRequest = Client.Add("com.unity.textmeshpro");
            EditorApplication.update += WaitForTMPInstall;
            return;
        }

#if TMP_PRESENT
        TMPSceneCreator.CreateScenesWithTMP();
#else
        Debug.LogWarning("✅ TMP is installed, but the TMPSceneCreator is not compiled yet. Please recompile.");
#endif
    }

    private static void WaitForTMPInstall()
    {
        if (addRequest.IsCompleted)
        {
            EditorApplication.update -= WaitForTMPInstall;

            if (addRequest.Status == StatusCode.Success)
            {
                Debug.Log("✅ TMP installed. Please recompile and run the menu again.");
            }
            else
            {
                Debug.LogError("❌ TMP install failed: " + addRequest.Error.message);
            }

            addRequest = null;
        }
    }

    private static bool IsTextMeshProAvailable()
    {
        return Type.GetType("TMPro.TextMeshProUGUI, Unity.TextMeshPro") != null;
    }
}
#endif
