using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class LoadingScreenManager : MonoBehaviour
{
    public static LoadingScreenManager Instance { get; private set; }

    [Header("UI")]
    public LoadingScreenUI loadingUI;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneRoutine(sceneName));
    }

    private IEnumerator LoadSceneRoutine(string sceneName)
    {
        loadingUI.Show();
        AsyncOperation op = SceneManager.LoadSceneAsync(sceneName);
        op.allowSceneActivation = false;

        while (op.progress < 0.9f)
        {
            loadingUI.SetProgress(op.progress);
            yield return null;
        }

        // Fill to 100% visually before activation
        loadingUI.SetProgress(1f);
        yield return new WaitForSeconds(0.3f); // optional smooth delay

        op.allowSceneActivation = true;

        yield return null;
        loadingUI.Hide();
    }
}
