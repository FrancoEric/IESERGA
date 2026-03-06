using UnityEngine;

public class HUDstart : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(false);

        EventBroadcaster.Instance.AddObserver(EventNames.FINISHED_BREAKFAST, start);
    }

    void start()
    {
        gameObject.SetActive(true);
    }
}