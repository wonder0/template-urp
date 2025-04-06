using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public IntEventChannelSO onScoreChanged;
    private int score = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddPoints(10);
            onScoreChanged.RaiseEvent(score);
        }
    }

    public void AddPoints(int points)
    {
        score += points;
        Debug.Log($"[ScoreSystem] Score is now {score}");
    }
}
