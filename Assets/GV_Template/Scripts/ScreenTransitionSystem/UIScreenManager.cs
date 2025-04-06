using UnityEngine;
using System.Collections.Generic;

public class UIScreenManager : MonoBehaviour
{
    public static UIScreenManager Instance;

    [Header("Screens")]
    public List<UIScreen> screens;

    private UIScreen currentScreen;

    private void Awake()
    {
        Instance = this;
        foreach (var screen in screens)
            screen.gameObject.SetActive(false);

        OpenScreen(screens[0]);
    }

    public void OpenScreen(string screenName)
    {
        var next = screens.Find(s => s.name == screenName);
        if (next == null)
        {
            Debug.LogWarning($"Screen {screenName} not found.");
            return;
        }

        if (currentScreen == next)
            return;

        currentScreen?.Hide();
        currentScreen = next;
        currentScreen.Show();
    }

    public void OpenScreen(UIScreen screen)
    {
        if (screen == null || screen == currentScreen)
            return;

        currentScreen?.Hide();
        currentScreen = screen;
        currentScreen.Show();
    }
}
