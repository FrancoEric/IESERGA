using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] string levelSelectSceneName;

    public void startGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(levelSelectSceneName);
    }
}