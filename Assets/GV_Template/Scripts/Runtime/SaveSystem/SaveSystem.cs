using System.IO;
using UnityEngine;

public static class SaveSystem
{
    private static readonly string SaveFilePath = Path.Combine(Application.persistentDataPath, "savegame.json");

    public static void SaveGame(SaveData data)
    {
        string json = JsonUtility.ToJson(data, prettyPrint: true);
        File.WriteAllText(SaveFilePath, json);
        Debug.Log($"Game saved to {SaveFilePath}");
    }

    public static SaveData LoadGame()
    {
        if (!File.Exists(SaveFilePath))
        {
            Debug.LogWarning("No save file found. Returning new SaveData.");
            return new SaveData();
        }

        string json = File.ReadAllText(SaveFilePath);
        SaveData data = JsonUtility.FromJson<SaveData>(json);
        Debug.Log("Game loaded.");
        return data;
    }

    public static void DeleteSave()
    {
        if (File.Exists(SaveFilePath))
        {
            File.Delete(SaveFilePath);
            Debug.Log("Save file deleted.");
        }
    }
}
