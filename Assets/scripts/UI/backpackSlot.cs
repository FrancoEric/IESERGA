using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class BackpackSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool isHovered;
    public BackpackData backpackData; 
    Image img;
    TextMeshProUGUI numberText;

    void Awake()
    {
        img = transform.GetChild(0).GetComponent<Image>();
        numberText = transform.GetComponentInChildren<TextMeshProUGUI>();
        
    }

    void Start()
    {
        backpackData = new BackpackData(ItemLibrary.Instance.getItemByName("None"),0);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovered = true;
        //Debug.Log("Mouse entered");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovered = false;
        //Debug.Log("Mouse exited");
    }

    void Update()
    {
        if(backpackData.itemType.itemType == BackpackItemType.None)
        {
            setImgAlpha(0);
            setTextAlpha(0);
        }
        else
        {
            setImgAlpha(1);
            setTextAlpha(1);
            img.sprite = backpackData.itemType.sprite;
            numberText.text = backpackData.amount.ToString();
        }
    }

    void setImgAlpha(float a)
    {
        Color temp = Color.white;
        temp.a = a;
        img.color = temp;
    }

    void setTextAlpha(float a)
    {
        Color temp = Color.black;
        temp.a = a;
        numberText.color = temp;
    }
}