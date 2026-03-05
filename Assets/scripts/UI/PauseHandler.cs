using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseHandler : MonoBehaviour
{
    [SerializeField] GameObject pauseParent;
    [SerializeField] string levelSelectionSceneName = "level selection";
    bool prevBool = false;
    bool isPaused = false;

    void Awake()
    {
        pauseParent.SetActive(false);

        EventBroadcaster.Instance.AddObserver(EventNames.PAUSE_START, pauseStart);
        EventBroadcaster.Instance.AddObserver(EventNames.PAUSE_END, stopPause);
    }

    void pauseStart()
    {
        pauseParent.SetActive(true);
        Time.timeScale = 0;
    }

    void stopPause()
    {
        pauseParent.SetActive(false);
        Time.timeScale = 1;
    }

    void Update()
    {
        bool currentBool = PlayerInputHandler.Instance.pause;
        if(currentBool != prevBool && currentBool)
        {
            isPaused = !isPaused;
            if(isPaused)
            {
                EventBroadcaster.Instance.PostEvent(EventNames.PAUSE_START);
            }
            else
            {
                EventBroadcaster.Instance.PostEvent(EventNames.PAUSE_END);
            }
        }

        prevBool = currentBool;
    }

    public void goToLevelSelection()
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(levelSelectionSceneName);
    }
}