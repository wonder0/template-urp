using UnityEngine;
using System;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance { get; private set; }

    public GameState CurrentState { get; private set; }

    public event Action<GameState> OnStateChanged;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        // Set default state
        ChangeState(GameState.MainMenu);
    }

    public void ChangeState(GameState newState)
    {
        if (newState == CurrentState) return;

        Debug.Log($"Game State Changed: {CurrentState} → {newState}");

        CurrentState = newState;
        OnStateChanged?.Invoke(CurrentState);
    }

    public bool IsState(GameState state) => CurrentState == state;
}
