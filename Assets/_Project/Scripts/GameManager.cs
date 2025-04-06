using UnityEngine;

public class GameManager : MonoBehaviour
{


    public void PauseGame()
    {
        GameStateManager.Instance.ChangeState(GameState.GameOver);
    }
}
