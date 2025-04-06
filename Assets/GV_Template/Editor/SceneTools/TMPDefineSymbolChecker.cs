#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public static class TMPDefineSymbolChecker
{
    static TMPDefineSymbolChecker()
    {
        const string symbol = "TMP_PRESENT";
        string symbols = PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone);

        if (!symbols.Contains(symbol))
        {
            PlayerSettings.SetScriptingDefineSymbolsForGroup(
                BuildTargetGroup.Standalone,
                symbols + ";" + symbol
            );
            Debug.Log("✅ TMP_PRESENT define symbol added automatically.");
        }
    }
}
#endif
