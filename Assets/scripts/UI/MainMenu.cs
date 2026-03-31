using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] string levelSelectSceneName;
    [SerializeField] string tutorialSceneName;
    [SerializeField] GameObject credits;

    void Awake()
    {
        credits.SetActive(false);
    }

    public void startGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(levelSelectSceneName);
    }

    public void tutorial()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(tutorialSceneName);
    }

    public void toggleCredits()
    {
        credits.SetActive(!credits.activeSelf);
    }
}