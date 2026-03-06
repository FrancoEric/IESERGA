using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BlackScreenHandler : MonoBehaviour
{
    [SerializeField] float pauseAlpha = 0.3f;
    Image img;

    void Awake()
    {
        img = GetComponent<Image>();

        EventBroadcaster.Instance.AddObserver(EventNames.FADE_TO_BLACK, fadeToBlack);
        EventBroadcaster.Instance.AddObserver(EventNames.FADE_FROM_BLACK, fadeFromBlack);
        EventBroadcaster.Instance.AddObserver(EventNames.PAUSE_START, pause);
        EventBroadcaster.Instance.AddObserver(EventNames.PAUSE_END, unpause);
    }

    void Start()
    {
        img.CrossFadeAlpha(0, 0, false);
    }

    void pause()
    {
        img.CrossFadeAlpha(pauseAlpha, 0, false);
    }

    void unpause()
    {
        img.CrossFadeAlpha(0, 0, false);
    }

    void fadeToBlack()
    {
        img.CrossFadeAlpha(1, PlayerData.blackScreenFadeTime, false);
    }

    void fadeFromBlack()
    {
        img.CrossFadeAlpha(0, PlayerData.blackScreenFadeTime, false);
    }
}
