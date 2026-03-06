using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EatingSlot : MonoBehaviour
{
    Image foodImg;
    TextMeshProUGUI amountText;
    BackpackData currentData;

    void Awake()
    {
        foodImg = transform.GetChild(0).GetComponent<Image>();
        amountText = GetComponentInChildren<TextMeshProUGUI>();

        currentData = new BackpackData(ItemLibrary.Instance.getItemByName("None"),0);
    }

    public void addData(BackpackData data)
    {
        currentData = data;
    }

    void Update()
    {
        if(currentData.itemType.itemType == BackpackItemType.None)
        {
            setImgAlpha(0);
            setTextAlpha(0);
        }
        else
        {
            setImgAlpha(1);
            setTextAlpha(1);
            foodImg.sprite = currentData.itemType.sprite;
            amountText.text = currentData.amount.ToString();
        }
    }

    void setImgAlpha(float a)
    {
        Color temp = Color.white;
        temp.a = a;
        foodImg.color = temp;
    }

    void setTextAlpha(float a)
    {
        Color temp = Color.black;
        temp.a = a;
        amountText.color = temp;
    }
}