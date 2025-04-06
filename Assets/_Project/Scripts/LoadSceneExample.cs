using UnityEngine;


public class SceneLoaderExample : MonoBehaviour
{
    public void LoadGameScene()
    {
        LoadingScreenManager.Instance.LoadScene("Game");
    }
}
