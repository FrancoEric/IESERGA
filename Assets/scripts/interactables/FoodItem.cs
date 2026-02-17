using UnityEngine;
using TMPro;

public class FoodItem : MonoBehaviour
{
    [SerializeField] string foodName;
    [SerializeField] string description;
    [SerializeField] float proteinAmount = 0f;
    [SerializeField] float carbAmount = 0f;
    [SerializeField] float fatAmount = 0f;
    [SerializeField] TextMeshPro foodNameText;
    [SerializeField] TextMeshPro descriptionText;
    [SerializeField] TextMeshPro strengthText;
    [SerializeField] TextMeshPro maxhpText;
    [SerializeField] TextMeshPro hpregenText;
    [SerializeField] TextMeshPro maxstamText;
    [SerializeField] TextMeshPro initstamText;
    [SerializeField] TextMeshPro stamregenText;
    [SerializeField] TextMeshPro speedText;
    Clickable_Item clickableComp;

    void Awake()
    {
        clickableComp = GetComponentInChildren<Clickable_Item>();

        foodNameText.text = foodName;
        descriptionText.text = description;

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

            PlayerData.protein += proteinAmount;
            PlayerData.carbs += carbAmount; 
            PlayerData.fats += fatAmount;

            Debug.Log("Ate " + foodName + ". Protein: " + PlayerData.protein + ", Carbs: " + PlayerData.carbs + ", Fats: " + PlayerData.fats);

            gameObject.SetActive(false);
        }
    }
}