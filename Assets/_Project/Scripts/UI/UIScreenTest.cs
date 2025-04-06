using UnityEngine;

namespace GhostVision.ProjectTemplateURP
{
    public class UIScreenTest : MonoBehaviour
    {
        public void OpenSettings()
        {
            UIScreenManager.Instance.OpenScreen("Settings");
        }

        public void MainMenu()
        {
            UIScreenManager.Instance.OpenScreen("MainMenu");
        }

        public void GamePlayUI()
        {
            UIScreenManager.Instance.OpenScreen("GameplayUI");
        }
    }
}
