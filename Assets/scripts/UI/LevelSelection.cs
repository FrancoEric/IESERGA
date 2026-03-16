using UnityEngine;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    [SerializeField] string mainMenuSceneName;
    [SerializeField] string[] levelSceneNames;

    public void startLevel(int index)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(levelSceneNames[index]);
    }

    public void back()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(mainMenuSceneName);
    }
}