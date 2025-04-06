#if UNITY_EDITOR && TMP_PRESENT
using UnityEditor;
using UnityEngine;
using UnityEditor.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.IO;

public static class TMPSceneCreator
{
    private static readonly string scenePath = "Assets/_Project/Scenes/";

    public static void CreateScenesWithTMP()
    {
        if (!Directory.Exists(scenePath))
            Directory.CreateDirectory(scenePath);

        CreateInitScene();
        CreateMainMenuScene();
        CreateGameScene();
        CreateLoadingScene();
        CreateDevSandboxScene();

        AssetDatabase.Refresh();
        Debug.Log("✅ All TMP base scenes created.");
    }

    private static void CreateInitScene()
    {
        CreateScene("Init", () =>
        {
            new GameObject("Bootstrapper");
        });
    }

    private static void CreateMainMenuScene()
    {
        CreateScene("MainMenu", () =>
        {
            var canvas = CreateUICanvas("MainMenuCanvas");
            CreateTMPText(canvas.transform, "Main Menu");
        });
    }

    private static void CreateGameScene()
    {
        CreateScene("Game", () =>
        {
            new GameObject("GameManager");

            var light = new GameObject("Directional Light", typeof(Light));
            light.GetComponent<Light>().type = LightType.Directional;
        });
    }

    private static void CreateLoadingScene()
    {
        CreateScene("Loading", () =>
        {
            var canvas = CreateUICanvas("LoadingCanvas");
            CreateTMPText(canvas.transform, "Loading...");
        });
    }

    private static void CreateDevSandboxScene()
    {
        CreateScene("DevSandbox", () =>
        {
            new GameObject("DevTools");
        });
    }

    private static void CreateScene(string name, System.Action setup)
    {
        var scene = EditorSceneManager.NewScene(NewSceneSetup.DefaultGameObjects, NewSceneMode.Single);
        setup.Invoke();
        EditorSceneManager.SaveScene(scene, scenePath + name + ".unity");
    }

    private static Canvas CreateUICanvas(string name)
    {
        var canvasGO = new GameObject(name, typeof(Canvas), typeof(CanvasScaler), typeof(GraphicRaycaster));
        var canvas = canvasGO.GetComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvasGO.GetComponent<CanvasScaler>().uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;

        // Add EventSystem if needed
        if (Object.FindObjectOfType<EventSystem>() == null)
        {
            new GameObject("EventSystem", typeof(EventSystem), typeof(StandaloneInputModule));
        }

        return canvas;
    }

    private static void CreateTMPText(Transform parent, string content)
    {
        var textGO = new GameObject("TMP_Text", typeof(TextMeshProUGUI));
        textGO.transform.SetParent(parent, false);

        var text = textGO.GetComponent<TextMeshProUGUI>();
        text.text = content;
        text.fontSize = 48;
        text.alignment = TextAlignmentOptions.Center;
        text.rectTransform.anchoredPosition = Vector2.zero;
        text.rectTransform.sizeDelta = new Vector2(600, 200);
    }
}
#endif
