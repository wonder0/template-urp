using System.Collections.Generic;
using UnityEngine;

public class TabSystemGroup : MonoBehaviour
{
    public List<TabSystemButton> tabButtons;
    public List<UITabPage> tabPages;
    public int defaultTab = 0;

    private int currentIndex = -1;

    private void Start()
    {
        for (int i = 0; i < tabButtons.Count; i++)
        {
            int index = i;
            tabButtons[i].Init(this, index);
        }

        SelectTab(defaultTab);
    }

    public void SelectTab(int index)
    {
        if (index == currentIndex) return;

        // Deselect previous
        if (currentIndex >= 0)
        {
            tabButtons[currentIndex].SetSelected(false);
            tabPages[currentIndex].Hide();
        }

        // Select new
        currentIndex = index;
        tabButtons[currentIndex].SetSelected(true);
        tabPages[currentIndex].Show();
    }
}
