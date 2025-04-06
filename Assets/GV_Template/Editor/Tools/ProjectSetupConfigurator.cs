#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using UnityEditor.Build;
using UnityEditor.Rendering;
using System.IO;
using System;

public static class ProjectSetupConfigurator
{
    private const string COMPANY_NAME = "Ghost Vision";

    [MenuItem("Tools/Setup/Apply Project Settings")]
    public static void ApplySettings()
    {
        // Set Company Name
        PlayerSettings.companyName = COMPANY_NAME;

        // Try getting the root namespace from EditorSettings

        string projectPath = Directory.GetParent(Application.dataPath).FullName;
        string projectName = new DirectoryInfo(projectPath).Name;
        PlayerSettings.productName = projectName;

        string bundleIdentifier = $"com.{COMPANY_NAME.Replace(" ", "")}.{projectName.Replace(" ", "")}";
        PlayerSettings.SetApplicationIdentifier(BuildTargetGroup.Standalone, bundleIdentifier);
        PlayerSettings.SetApplicationIdentifier(BuildTargetGroup.Android, bundleIdentifier);
        PlayerSettings.SetApplicationIdentifier(BuildTargetGroup.iOS, bundleIdentifier);


        Debug.Log($"✅ Project settings configured. Company: {COMPANY_NAME}, Product: {projectName}");

        // Graphics → Color Space
        PlayerSettings.colorSpace = ColorSpace.Linear;

        // Build → Scripting Backend
        PlayerSettings.SetScriptingBackend(BuildTargetGroup.Standalone, ScriptingImplementation.IL2CPP);

        // Build → API Compatibility Level
        PlayerSettings.SetApiCompatibilityLevel(BuildTargetGroup.Standalone, ApiCompatibilityLevel.NET_4_6);

        // Orientation
        PlayerSettings.defaultInterfaceOrientation = UIOrientation.LandscapeLeft;

        // Auto Graphics API


        // FPS & VSync
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;

        AssetDatabase.SaveAssets();
    }
}
#endif
