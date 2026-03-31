using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System.Collections;

public class EatingScreen : MonoBehaviour
{
    [SerializeField] GameObject gridParent;
    [SerializeField] GameObject slotPrefab;
    [SerializeField] Image foodImg;
    [SerializeField] TextMeshProUGUI currentFoodText;
    [SerializeField] TextMeshProUGUI foodDescText;
    [SerializeField] TextMeshProUGUI currentAmountText;
    [SerializeField] TextMeshProUGUI servingsText;
    [SerializeField] TextMeshProUGUI servingSizeText;
    [SerializeField] TextMeshProUGUI caloriesText;
    [SerializeField] TextMeshProUGUI fatText;
    [SerializeField] TextMeshProUGUI carbsText;
    [SerializeField] TextMeshProUGUI proteinText;
    [SerializeField] TextMeshProUGUI proteinStat;
    [SerializeField] TextMeshProUGUI carbStat;
    [SerializeField] TextMeshProUGUI fatStat;
    [SerializeField] TextMeshProUGUI strengthStat;
    [SerializeField] TextMeshProUGUI vitalityStat;
    [SerializeField] TextMeshProUGUI woundrecStat;
    [SerializeField] TextMeshProUGUI mobilityStat;
    [SerializeField] TextMeshProUGUI maxstamStat;
    [SerializeField] TextMeshProUGUI initstamStat;
    [SerializeField] TextMeshProUGUI stamregenStat;
    [SerializeField] TextMeshProUGUI calorieGoalNumberText;
    [SerializeField] bool needsCalorieReq = true; //for debugging 
    BackpackManager backpackManager;
    LevelManager levelManager;
    List<BackpackData> oglocalBackpack = new List<BackpackData>();
    EatingSlot[] slots = new EatingSlot[PlayerData.baseBackpackSize];
    BackpackData currentData;
    int amount = 0;
    
    void Awake()
    {
        Time.timeScale = 0f;
        backpackManager = BackpackManager.Instance;

        foreach(BackpackData data in backpackManager.backpackData)
        {
            oglocalBackpack.Add(new BackpackData(data.itemType, data.amount));
        }
        intData();

        for(int i = 0; i < PlayerData.baseBackpackSize; i++)
        {
            GameObject slot = Instantiate(slotPrefab, gridParent.transform);
            int index = i;
            slot.GetComponentInChildren<Button>().onClick.AddListener(() => selectItem(index));
            slots[i] = slot.GetComponent<EatingSlot>();
        }

        EventBroadcaster.Instance.PostEvent(EventNames.START_BREAKFAST);
    }

    void Start()
    {
        currentData = new BackpackData(ItemLibrary.Instance.getItemByName("None"),0);
        levelManager = GameObject.FindWithTag("Level Manager").GetComponent<LevelManager>();
        selectItem(0);
    }

    void updateSlotData()
    {
        for(int i = 0; i < PlayerData.baseBackpackSize; i++)
        {
            if(i < backpackManager.localBackpack.Count)
                slots[i].addData(backpackManager.localBackpack[i]);
            else
                slots[i].addData(new BackpackData(ItemLibrary.Instance.getItemByName("None"),0));
        }
    }

    void updateText()
    {
        foodImg.sprite = currentData.itemType.sprite;
        currentFoodText.text = currentData.itemType.Name;
        foodDescText.text = currentData.itemType.desc;
        currentAmountText.text = amount.ToString();
        servingsText.text = currentData.amount.ToString();
        servingSizeText.text = currentData.itemType.weight.ToString() + "g";
        caloriesText.text = currentData.itemType.calories().ToString();
        fatText.text = currentData.itemType.fat.ToString() + "g";
        carbsText.text = currentData.itemType.carbs.ToString() + "g";
        proteinText.text = currentData.itemType.protein.ToString() + "g";
    }

    void emptyText()
    {
        foodImg.sprite = null;
        currentFoodText.text = "";
        foodDescText.text = "";
        currentAmountText.text = "";
        servingsText.text = "";
        servingSizeText.text = "";
        caloriesText.text = "";
        fatText.text = "";
        carbsText.text = "";
        proteinText.text = "";
    }

    void updateStats()
    {
        proteinStat.text = "Protein: " + PlayerData.protein.ToString();
        carbStat.text = "Carbs: " + PlayerData.carbs.ToString();
        fatStat.text = "Fats: " + PlayerData.fats.ToString();
        strengthStat.text = "Strength: " + PlayerData.localStrength.ToString();
        vitalityStat.text = "Vitality: " + PlayerData.localMaxHealth.ToString();
        woundrecStat.text = "Wound Recovery: " + PlayerData.localMaxHealthRegenAmount.ToString();
        mobilityStat.text = "Mobility: " + PlayerData.localRunSpeed.ToString();
        maxstamStat.text = "Max Stamina: " + PlayerData.localMaxStamina.ToString();
        initstamStat.text = "Initial Stamina: " + PlayerData.localInitialStaminaRatio.ToString();
        stamregenStat.text = "Stamina Regen: " + PlayerData.localStaminaRegen.ToString();
    }

    void updateCalorieText()
    {
        calorieGoalNumberText.text = PlayerData.calories.ToString() + " / " + levelManager.calorieGoal.ToString();
    }

    public void selectItem(int index)
    {
        if(index >= backpackManager.localBackpack.Count)
            return;

        currentData = backpackManager.localBackpack[index];
        if(currentData.itemType.itemType == BackpackItemType.None)
        {
            emptyText();
            return;
        }

        amount = 1;
        updateText();
        //Debug.Log("Clicked " + index + ", item: " + backpackManager.localBackpack[index].itemType.itemType + ", amount: " + backpackManager.localBackpack[index].amount);
    }

    void intData()
    {
        //Debug.Log("int data");

        PlayerData.protein = 0;
        PlayerData.carbs = 0;
        PlayerData.fats = 0;
        PlayerData.calories = 0;

        backpackManager.localBackpack.Clear();
        foreach(BackpackData data in oglocalBackpack)
            backpackManager.localBackpack.Add(new BackpackData(data.itemType, data.amount));;

        if(backpackManager.localBackpack.Count == 0)
        {
            emptyText();
            return;
        }

        currentData = backpackManager.localBackpack[0];
        if(currentData.itemType.itemType == BackpackItemType.None)
        {
            emptyText();
            return;
        }

        amount = 1;
        updateText();
    }

    public void decreaseAmountButton()
    {
        if(currentData.itemType.itemType != BackpackItemType.None && amount > 1 && currentData.amount > 1 )
        {
            amount--;
            updateText();
        }
    }

    public void increaseAmountButton()
    {
        if(currentData.itemType.itemType != BackpackItemType.None && amount < currentData.amount)
        {
            amount++;
            updateText();
        }
    }

    public void eatButton()
    {
        if(currentData.itemType.itemType == BackpackItemType.None)
            return;

        if(PlayerData.calories >= levelManager.calorieGoal)
            return;

        PlayerData.carbs += currentData.itemType.carbs * amount;
        PlayerData.protein += currentData.itemType.protein * amount;
        PlayerData.fats += currentData.itemType.fat * amount;
        PlayerData.calories += currentData.itemType.calories() * amount;
        //NutrientManager.Instance.updateLocalNutrients();
        backpackManager.removeItem(currentData.itemType, amount);

        if(backpackManager.localBackpack.Count == 0)
        {
            emptyText();
            return;
        }

        currentData = backpackManager.localBackpack[0];
        if(currentData.itemType.itemType == BackpackItemType.None)
        {
            emptyText();
            return;
        }

        amount = 1;
        updateText();
    }

    public void resetButton()
    {
        intData();
        //PlayerData.currentToLocal();
    }

    public void finishEatingButton()
    {
        if(PlayerData.calories >= levelManager.calorieGoal || !needsCalorieReq)
            StartCoroutine(exit());
    }

    IEnumerator exit()
    {
        Time.timeScale = 1f;
        EventBroadcaster.Instance.PostEvent(EventNames.FADE_TO_BLACK);
        EventBroadcaster.Instance.PostEvent(EventNames.FINISHED_BREAKFAST);
        yield return new WaitForSeconds(PlayerData.blackScreenFadeTime); 

        gameObject.SetActive(false);
        EventBroadcaster.Instance.PostEvent(EventNames.FADE_FROM_BLACK);
    }

    void Update()
    {
        updateStats();
        updateSlotData();
        updateCalorieText();
    }
}
