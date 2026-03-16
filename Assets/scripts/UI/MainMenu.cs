using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] string levelSelectSceneName;
    [SerializeField] string tutorialSceneName;

    public void startGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(levelSelectSceneName);
    }

    public void tutorial()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(tutorialSceneName);
    }
}