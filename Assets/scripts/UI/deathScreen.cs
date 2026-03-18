using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DeathScreen : MonoBehaviour
{
    [SerializeField] GameObject deathScreen;
    [SerializeField] string levelSelectSceneName;
    bool first = true;

    void Awake()
    {
        deathScreen.SetActive(false);
    }

    void Update()
    {
        if(PlayerData.currentHealth <= 0 && first)
        {
            first = false;
            StartCoroutine(deathSequence());
        }
    }

    IEnumerator deathSequence()
    {
        EventBroadcaster.Instance.PostEvent(EventNames.FADE_TO_BLACK);
        yield return new WaitForSeconds(PlayerData.blackScreenFadeTime);
        deathScreen.SetActive(true);
        EventBroadcaster.Instance.PostEvent(EventNames.PLAYER_STOP_MOVEMENT);
    }

    public void returnToLevelSelect()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(levelSelectSceneName);
    }
}