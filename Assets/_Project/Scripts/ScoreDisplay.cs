using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    public IntEventChannelSO onScoreChanged;

    private void OnEnable()
    {
        onScoreChanged.RegisterListener(UpdateScoreUI);
    }

    private void OnDisable()
    {
        onScoreChanged.UnregisterListener(UpdateScoreUI);
    }

    private void UpdateScoreUI(int newScore)
    {
        Debug.Log($"[Listener] Score Updated: {newScore}");
        // Update UI here
    }
}
