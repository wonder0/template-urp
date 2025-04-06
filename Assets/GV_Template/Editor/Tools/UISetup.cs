#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public static class UISetup
{
    [MenuItem("Tools/Setup/Setup UI Canvas")]
    public static void SetupUICanvas()
    {
        if (UnityEngine.Object.FindObjectOfType<Canvas>() != null)
        {
            Debug.LogWarning("A Canvas already exists in the scene.");
            return;
        }

        // Create Canvas
        GameObject canvasGO = new GameObject("MainCanvas", typeof(Canvas), typeof(CanvasScaler), typeof(GraphicRaycaster));
        Canvas canvas = canvasGO.GetComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvasGO.GetComponent<CanvasScaler>().uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        canvasGO.GetComponent<CanvasScaler>().referenceResolution = new Vector2(1920, 1080);


        // Create EventSystem if it doesn't exist
        if (UnityEngine.Object.FindObjectOfType<EventSystem>() == null)
        {
            new GameObject("EventSystem", typeof(EventSystem), typeof(StandaloneInputModule));
        }

        // Create Sample UI - Main Menu Button
        CreateUIButton(canvasGO.transform, "Start Game", () => Debug.Log("Start Game Button Clicked"));

        // Setup TextMeshPro if not installed
        SetupTextMeshPro();

        Debug.Log("✅ UI Canvas setup complete.");
    }

    private static void CreateUIButton(Transform parent, string buttonText, System.Action onClickAction)
    {
        GameObject buttonGO = new GameObject(buttonText, typeof(Button), typeof(RectTransform), typeof(TextMeshProUGUI));
        buttonGO.transform.SetParent(parent);

        Button button = buttonGO.GetComponent<Button>();
        TextMeshProUGUI text = buttonGO.GetComponentInChildren<TextMeshProUGUI>();
        text.text = buttonText;
        text.fontSize = 36;
        text.alignment = TMPro.TextAlignmentOptions.Center;

        button.onClick.AddListener(() => onClickAction.Invoke());

        RectTransform rectTransform = buttonGO.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(400, 100);
        rectTransform.anchoredPosition = Vector2.zero;
    }

    private static void SetupTextMeshPro()
    {
        if (Type.GetType("TMPro.TextMeshProUGUI, Unity.TextMeshPro") == null)
        {
            Debug.LogWarning("TextMeshPro is not installed. Please install it via the Package Manager.");
            return;
        }

        // Example: Create TMP text object
        GameObject tmpTextGO = new GameObject("TMP_Text", typeof(TextMeshProUGUI));
        tmpTextGO.transform.SetParent(GameObject.Find("MainCanvas").transform, false);
        TextMeshProUGUI tmpText = tmpTextGO.GetComponent<TextMeshProUGUI>();
        tmpText.text = "Welcome to the Game!";
        tmpText.fontSize = 48;
        tmpText.alignment = TMPro.TextAlignmentOptions.Center;
        tmpText.rectTransform.anchoredPosition = new Vector2(0, 200);
        tmpText.rectTransform.sizeDelta = new Vector2(600, 200);
    }
}
#endif
