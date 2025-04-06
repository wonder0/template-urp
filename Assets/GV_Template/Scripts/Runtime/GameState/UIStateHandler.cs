using UnityEngine;

public class UIStateHandler : MonoBehaviour
{
    private void OnEnable()
    {
        GameStateManager.Instance.OnStateChanged += OnGameStateChanged;
    }

    private void OnDisable()
    {
        GameStateManager.Instance.OnStateChanged -= OnGameStateChanged;
    }

    private void OnGameStateChanged(GameState newState)
    {
        switch (newState)
        {
            case GameState.MainMenu:
                Debug.Log("Show Main Menu");
                break;
            case GameState.Playing:
                Debug.Log("Hide Menus. Show HUD.");
                break;
            case GameState.Paused:
                Debug.Log("Show Pause Menu");
                break;
            case GameState.GameOver:
                Debug.Log("Show Game Over Screen");
                break;
        }
    }
}
