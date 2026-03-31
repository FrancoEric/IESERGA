using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FoodItem : MonoBehaviour
{
    [SerializeField] string itemName;
    [SerializeField] int servingSize;
    [SerializeField] float gramMultiplier = 1; //all food items are 100 grams, multiply 100 to fit a serving size of that food
    [SerializeField] Image foodPic;
    [SerializeField] SpriteRenderer foodSprite;
    [SerializeField] TextMeshPro foodNameText;
    [SerializeField] TextMeshPro descriptionText;
    [SerializeField] TextMeshPro servingsText;
    [SerializeField] TextMeshPro servingSizeText;
    [SerializeField] TextMeshPro caloriesText;
    [SerializeField] TextMeshPro fatText;
    [SerializeField] TextMeshPro carbsText;
    [SerializeField] TextMeshPro proteinsText;
    Clickable_Item clickableComp;
    Item item;

    void Start()
    {
        clickableComp = GetComponentInChildren<Clickable_Item>();

        item = ItemLibrary.Instance.getItemByName(itemName);
        if(!item)
        {
            Debug.Log(itemName + " is not a valid name for object " + gameObject.name);
        }

        foodPic.sprite = item.sprite;
        foodSprite.sprite = item.sprite;

        //item.calories = (item.fat * 9 + item.carbs * 4 + item.protein * 4) * gramMultiplier;
        caloriesText.text = item.calories().ToString();

        foodNameText.text = item.Name;
        descriptionText.text = item.desc;
        servingsText.text = servingSize.ToString();
        servingSizeText.text = (item.weight * gramMultiplier).ToString() + "g";

        proteinsText.text = (item.protein * gramMultiplier).ToString() + "g";
        fatText.text = (item.fat * gramMultiplier).ToString() + "g";
        carbsText.text = (item.carbs * gramMultiplier).ToString() + "g";
    }

    void Update()
    {
        if(clickableComp.isClicked)
        {
            //clickableComp.isClicked = false;

            bool success = BackpackManager.Instance.addItem(item, servingSize);
            if(!success)
            {
                Debug.Log("Backpack full! Could not add " + item.Name);
                return;
            }

            //Debug.Log("Ate " + foodName + ". Protein: " + PlayerData.protein + ", Carbs: " + PlayerData.carbs + ", Fats: " + PlayerData.fats);

            EventBroadcaster.Instance.PostEvent(EventNames.PICKED_UP_ITEM);
            gameObject.SetActive(false);
        }
    }
}