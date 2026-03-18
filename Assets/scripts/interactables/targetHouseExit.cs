using UnityEngine;
using System.Collections;

public class targetHouseExit : Clickable_Item
{
    [SerializeField] Transform tpLocation;
    targetHouseEnter doorScript;
    Transform player;

    override protected void Awake()
    {
        base.Awake();
        doorScript = GameObject.FindGameObjectWithTag("Target House").GetComponent<targetHouseEnter>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if(!doorScript)
        {
            Debug.LogError("targetHouseExit: No targetHouseEnter script found on targetDoor");
        }
    }

    void Update()
    {
        if (isClicked)
        {
            StartCoroutine(exit());
            isClicked = false;
        }
    }

    public void tpPlayer()
    {
        player.position = tpLocation.position;
    }

    IEnumerator exit()
    {
        EventBroadcaster.Instance.PostEvent(EventNames.FADE_TO_BLACK);
        yield return new WaitForSeconds(PlayerData.blackScreenFadeTime);

        EventBroadcaster.Instance.PostEvent(EventNames.FADE_FROM_BLACK);
        doorScript.tpPlayer();
    }
}