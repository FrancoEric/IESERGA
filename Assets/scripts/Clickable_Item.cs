using UnityEngine;

public class Clickable_Item : Clickable
{
    [SerializeField] GameObject hoverObj;

    void Awake()
    {
        hoverObj.SetActive(false);
    }

    public override void hoverStart()
    {
        //Debug.Log("Hover start");
        hoverObj.SetActive(true);
    }

    public override void hoverEnd()
    {
        //Debug.Log("Hover end");
        hoverObj.SetActive(false);
    }

    public override void clicked()
    {
        Debug.Log("Clicked " + gameObject.name);
    }
}