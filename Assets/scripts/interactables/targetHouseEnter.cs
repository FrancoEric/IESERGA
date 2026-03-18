using UnityEngine;
using System.Collections;

public class targetHouseEnter : Clickable_Item
{
    [SerializeField] Transform tpLocation;
    targetHouseExit doorScript;
    Transform player;

    override protected void Awake()
    {
        base.Awake();
        doorScript = GameObject.FindGameObjectWithTag("Target Door").GetComponent<targetHouseExit>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if(!doorScript)
        {
            Debug.LogError("targetHouseEnter: No targetHouseExit script found on targetDoor");
        }
    }

    void Update()
    {
        if (isClicked)
        {
            StartCoroutine(enter());
            isClicked = false;
        }
    }

    public void tpPlayer()
    {
        player.position = tpLocation.position;
    }

    IEnumerator enter()
    {
        EventBroadcaster.Instance.PostEvent(EventNames.FADE_TO_BLACK);
        yield return new WaitForSeconds(PlayerData.blackScreenFadeTime);

        EventBroadcaster.Instance.PostEvent(EventNames.FADE_FROM_BLACK);
        doorScript.tpPlayer();
    }
}