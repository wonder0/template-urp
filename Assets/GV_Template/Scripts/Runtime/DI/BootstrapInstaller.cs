using UnityEngine;

public class BootstrapInstaller : MonoBehaviour
{
    // Mention your services here
    // [SerializeField] private ScoreSystem scoreSystem;
    // [SerializeField] private GameManager gameManager;

    private void Awake()
    {
        ServiceLocator.Clear(); // In case of scene reloads

        // And register them here. 
        // ServiceLocator.Register<ScoreSystem>(scoreSystem);
        // ServiceLocator.Register<GameManager>(gameManager);
    }
}


/// And we inject the ScoreSystem into Gamemanager such as this:
/// private ScoreSystem scoreSystem;

// private void Start()
// {
//     scoreSystem = ServiceLocator.Get<ScoreSystem>();

//     // Now we can use it
//     scoreSystem.AddPoints(100);
// }