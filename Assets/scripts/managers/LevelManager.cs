using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float calorieGoal;
    [SerializeField] TextMeshProUGUI calorieGoalText;
    [SerializeField] TextMeshProUGUI currentCaloriesText;
    BackpackManager backpackManagerInstance;

    void Awake()
    {
        
    }

    void Start()
    {
        backpackManagerInstance = BackpackManager.Instance;
    }

    void Update()
    {
        calorieGoalText.text = "Calorie Goal: " + calorieGoal.ToString();
        currentCaloriesText.text = getCurrentCalories().ToString();
    }

    float getCurrentCalories()
    {
        float calories = 0;
        foreach(BackpackData data in backpackManagerInstance.localBackpack)
            calories += data.itemType.calories * data.amount;

        return calories;
    }
}
