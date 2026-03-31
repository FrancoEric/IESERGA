using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseHandler : MonoBehaviour
{
    [SerializeField] GameObject pauseParent;
    [SerializeField] string levelSelectionSceneName = "level selection";
    [SerializeField] Image pauseButtonImg;
    [SerializeField] Sprite pauseSprite;
    [SerializeField] Sprite resumeSprite;
    bool prevBool = false;
    bool isPaused = false;
    bool pauseButton = false;

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

        pauseButtonImg.sprite = resumeSprite;
    }

    void stopPause()
    {
        pauseParent.SetActive(false);
        Time.timeScale = 1;

        pauseButtonImg.sprite = pauseSprite;
    }

    void Update()
    {
        bool currentBool = PlayerInputHandler.Instance.pause;
        if((currentBool != prevBool && currentBool) || pauseButton)
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

            pauseButton = false;
        }

        prevBool = currentBool;
    }

    public void goToLevelSelection()
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(levelSelectionSceneName);
    }

    public void pauseButtonFunc()
    {
        pauseButton = true;
    }
}