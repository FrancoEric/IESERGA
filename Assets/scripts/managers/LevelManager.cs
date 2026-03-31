using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [SerializeField] public float calorieGoal;
    [SerializeField] public float nextCalorieGoal;
    [SerializeField] string levelSelectorSceneName = "level selection";
    [SerializeField] TextMeshProUGUI calorieGoalText;
    [SerializeField] TextMeshProUGUI currentCaloriesText;
    BackpackManager backpackManagerInstance;

    void Awake()
    {
        //PlayerData.currentToLocal();

        EventBroadcaster.Instance.AddObserver(EventNames.FINISH_TRIGGER, backToLevels);
    }

    void Start()
    {
        backpackManagerInstance = BackpackManager.Instance;
    }

    void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveActionAtObserver(EventNames.FINISH_TRIGGER, backToLevels);
    }

    void Update()
    {
        calorieGoalText.text = "Next Calorie Goal: " + nextCalorieGoal.ToString();
        currentCaloriesText.text = getCurrentCalories().ToString();
    }

    public float getCurrentCalories()
    {
        float calories = 0;
        foreach(BackpackData data in backpackManagerInstance.localBackpack)
            calories += data.itemType.calories() * data.amount;

        return calories;
    }

    void backToLevels()
    {
        PlayerData.currentLevelIndexUnlocked++;
        UnityEngine.SceneManagement.SceneManager.LoadScene(levelSelectorSceneName);
    }
}
