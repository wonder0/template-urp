#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

public static class SetRootNamespace
{
    [MenuItem("Tools/Set Root Namespace")]
    public static void SetNamespace()
    {
        string companyName = "GhostVision";
        string projectName = Application.productName.Replace(" ", ""); // optional: sanitize
        string rootNamespace = $"{companyName}.{projectName}";

        EditorSettings.projectGenerationRootNamespace = rootNamespace;
        Debug.Log($"✅ Root Namespace set to: {rootNamespace}");
    }
}
#endif