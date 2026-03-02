using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FoodItem : MonoBehaviour
{
    [SerializeField] string itemName;
    [SerializeField] int servingSize;
    [SerializeField] Image foodPic;
    [SerializeField] TextMeshPro foodNameText;
    [SerializeField] TextMeshPro descriptionText;
    [SerializeField] TextMeshPro strengthText;
    [SerializeField] TextMeshPro maxhpText;
    [SerializeField] TextMeshPro hpregenText;
    [SerializeField] TextMeshPro maxstamText;
    [SerializeField] TextMeshPro initstamText;
    [SerializeField] TextMeshPro stamregenText;
    [SerializeField] TextMeshPro speedText;
    [SerializeField] TextMeshPro servingsText;
    [SerializeField] TextMeshPro servingSizeText;
    [SerializeField] TextMeshPro caloriesText;
    [SerializeField] TextMeshPro fatText;
    [SerializeField] TextMeshPro carbsText;
    [SerializeField] TextMeshPro proteinsText;
    Clickable_Item clickableComp;
    Item item;
    float calories;

    void Start()
    {
        clickableComp = GetComponentInChildren<Clickable_Item>();

        item = ItemLibrary.Instance.getItemByName(itemName);
        if(!item)
        {
            Debug.Log(itemName + " is not a valid name for object " + gameObject.name);
        }

        foodPic.sprite = item.sprite;

        calories = item.fat * 9 + item.carbs * 4 + item.protein * 4;
        caloriesText.text = calories.ToString();

        foodNameText.text = item.Name;
        descriptionText.text = item.desc;
        servingsText.text = servingSize.ToString();
        servingSizeText.text = item.weight.ToString() + "g";

        proteinsText.text = item.protein.ToString() + "g";
        fatText.text = item.fat.ToString() + "g";
        carbsText.text = item.carbs.ToString() + "g";

        //no amount balancing yet, just show the stat increase if there is any
        if(item.protein > 0)
        {
            strengthText.text = "Strength ↑";
            maxhpText.text = "Vitality ↑";
            speedText.text = "Mobility ↑";
        }

        if(item.carbs > 0)
        {
            maxstamText.text = "Max Stamina ↑";
            initstamText.text = "Initial Stamina ↑";
        }

        if(item.fat > 0)
        {
            hpregenText.text = "Wound Recovery ↑";
            stamregenText.text = "Stamina Regen ↑";
            maxstamText.text = "Max Stamina ↑";
        }
    }

    void Update()
    {
        if(clickableComp.isClicked)
        {
            //clickableComp.isClicked = false;

            BackpackManager.Instance.addItem(item, servingSize);

            //Debug.Log("Ate " + foodName + ". Protein: " + PlayerData.protein + ", Carbs: " + PlayerData.carbs + ", Fats: " + PlayerData.fats);

            gameObject.SetActive(false);
        }
    }
}