using UnityEngine;
using System.Collections;
using TMPro;

public class finishTrigger : Clickable_Item
{
    [SerializeField] bool needsCalorieReq = true; //for debugging
    LevelManager levelManager;
    TextMeshProUGUI hoverText;

    void Start()
    {
        levelManager = GameObject.FindWithTag("Level Manager").GetComponent<LevelManager>();
        hoverText = hoverObj.GetComponentInChildren<TextMeshProUGUI>();
    }

    void Update()
    {
        if (isClicked)
        {
            if(needsCalorieReq && levelManager.getCurrentCalories() < levelManager.nextCalorieGoal)
            {
                isClicked = false;
                return;
            }

            StartCoroutine(finish());
            isClicked = false;
        }

        if(!needsCalorieReq || levelManager.getCurrentCalories() >= levelManager.nextCalorieGoal)
            setHoverText("Left Click to end the day");
        else
            setHoverText("Not Enough Calories in the backpack!");
    }

    IEnumerator finish()
    {
        EventBroadcaster.Instance.PostEvent(EventNames.FADE_TO_BLACK);
        yield return new WaitForSeconds(PlayerData.blackScreenFadeTime);
        EventBroadcaster.Instance.PostEvent(EventNames.FINISH_TRIGGER);
    }

    void setHoverText(string text)
    {
        hoverText.text = text;
    }
}