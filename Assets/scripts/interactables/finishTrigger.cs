using UnityEngine;
using System.Collections;

public class finishTrigger : Clickable_Item
{
    void Update()
    {
        if (isClicked)
        {
            StartCoroutine(finish());
        }
    }

    IEnumerator finish()
    {
        EventBroadcaster.Instance.PostEvent(EventNames.FADE_TO_BLACK);
        yield return new WaitForSeconds(PlayerData.blackScreenFadeTime);
        EventBroadcaster.Instance.PostEvent(EventNames.FINISH_TRIGGER);
    }
}