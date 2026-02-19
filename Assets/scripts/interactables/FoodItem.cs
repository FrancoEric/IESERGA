using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FoodItem : MonoBehaviour
{
    [SerializeField] string foodName;
    [SerializeField] string description;
    [SerializeField] int servingSize = 0;
    [SerializeField] int weightPerServing = 0;
    [SerializeField] int proteinAmount = 0;
    [SerializeField] int carbAmount = 0;
    [SerializeField] int fatAmount = 0;
    [SerializeField] Sprite foodSprite;
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
    int calories;

    void Awake()
    {
        clickableComp = GetComponentInChildren<Clickable_Item>();

        foodPic.sprite = foodSprite;

        calories = fatAmount * 9 + carbAmount * 4 + proteinAmount * 4;
        caloriesText.text = calories.ToString();

        foodNameText.text = foodName;
        descriptionText.text = description;
        servingSizeText.text = servingSize.ToString();
        servingsText.text = weightPerServing.ToString() + "g";

        proteinsText.text = proteinAmount.ToString() + "g";
        fatText.text = fatAmount.ToString() + "g";
        carbsText.text = carbAmount.ToString() + "g";

        //no amount balancing yet, just show the stat increase if there is any
        if(proteinAmount > 0)
        {
            strengthText.text = "Strength ↑";
            maxhpText.text = "Max HP ↑";
            speedText.text = "Speed ↑";
        }

        if(carbAmount > 0)
        {
            maxstamText.text = "Max Stamina ↑";
            initstamText.text = "Initial Stamina ↑";
        }

        if(fatAmount > 0)
        {
            hpregenText.text = "HP Regen ↑";
            stamregenText.text = "Stamina Regen ↑";
            maxstamText.text = "Max Stamina ↑";
        }
    }

    void Update()
    {
        if(clickableComp.isClicked)
        {
            //clickableComp.isClicked = false;

            PlayerData.protein += proteinAmount * servingSize;
            PlayerData.carbs += carbAmount * servingSize; 
            PlayerData.fats += fatAmount * servingSize;
            PlayerData.currentBackpackWeight += weightPerServing * servingSize;

            //Debug.Log("Ate " + foodName + ". Protein: " + PlayerData.protein + ", Carbs: " + PlayerData.carbs + ", Fats: " + PlayerData.fats);

            gameObject.SetActive(false);
        }
    }
}