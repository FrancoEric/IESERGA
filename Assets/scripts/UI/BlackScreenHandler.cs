using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BlackScreenHandler : MonoBehaviour
{
    [SerializeField] float fadeTime = 1f;
    Image img;

    void Awake()
    {
        img = GetComponent<Image>();

        EventBroadcaster.Instance.AddObserver(EventNames.FADE_TO_BLACK, fadeToBlack);
        EventBroadcaster.Instance.AddObserver(EventNames.FADE_FROM_BLACK, fadeFromBlack);
    }

    void Start()
    {
        img.CrossFadeAlpha(1, 0, false);
        fadeFromBlack();
    }

    void fadeToBlack()
    {
        img.CrossFadeAlpha(1, fadeTime, false);
    }

    void fadeFromBlack()
    {
        img.CrossFadeAlpha(0, fadeTime, false);
    }
}
