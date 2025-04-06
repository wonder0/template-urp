using UnityEngine;

public class SaveGameExample : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            var data = new SaveData
            {
                playerScore = 1234,
                currentLevel = "Level_02",
                playerPosition = new float[] { 1.5f, 0.0f, -3.2f }
            };

            SaveSystem.SaveGame(data);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            SaveData loaded = SaveSystem.LoadGame();
            Debug.Log($"Loaded Score: {loaded.playerScore}, Level: {loaded.currentLevel}");
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            SaveSystem.DeleteSave();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SaveData loaded = SaveSystem.LoadGame();
            loaded.playerScore += 10;
            SaveSystem.SaveGame(loaded);
            Debug.Log($"Updated Score: {loaded.playerScore}");
        }

    }


}
