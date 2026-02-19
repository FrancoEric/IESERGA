using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DebugStats : MonoBehaviour
{
    [SerializeField] GameObject debugMenuObj;
    [SerializeField] TextMeshProUGUI fatText;
    [SerializeField] TextMeshProUGUI carbsText;
    [SerializeField] TextMeshProUGUI proteinsText;
    [SerializeField] TextMeshProUGUI weightText;
    [SerializeField] TextMeshProUGUI strengthText;
    [SerializeField] TextMeshProUGUI maxhpText;
    [SerializeField] TextMeshProUGUI hpregenSpeedText;
    [SerializeField] TextMeshProUGUI hpregenAmountText;
    [SerializeField] TextMeshProUGUI maxstamText;
    [SerializeField] TextMeshProUGUI initstamText;
    [SerializeField] TextMeshProUGUI stamregenText;
    [SerializeField] TextMeshProUGUI speedwalkText;
    [SerializeField] TextMeshProUGUI speedrunText;

    void Update()
    {
        fatText.text = "Fats: " + PlayerData.fats.ToString();
        proteinsText.text = "Proteins: " + PlayerData.protein.ToString();
        carbsText.text = "Carbs: " + PlayerData.carbs.ToString();
        weightText.text = "Weight: " + PlayerData.currentBackpackWeight.ToString();

        strengthText.text = "Strength: " + PlayerData.currentStrength.ToString();
        maxhpText.text = "Max HP: " + PlayerData.currentMaxHealth.ToString();
        hpregenSpeedText.text = "HP Regen Speed: " + PlayerData.currentHealthRegenSpeed.ToString();
        hpregenAmountText.text = "HP Regen Amount: " + PlayerData.currentHealthRegenAmount.ToString();
        maxstamText.text = "Max Stamina: " + PlayerData.currentMaxStamina.ToString();
        initstamText.text = "Initial Stamina Ratio: " + PlayerData.currentInitialStaminaRatio.ToString();
        stamregenText.text = "Stamina Regen: " + PlayerData.currentStaminaRegen.ToString();
        speedwalkText.text = "Walk Speed: " + PlayerData.currentWalkSpeed.ToString();
        speedrunText.text = "Run Speed: " + PlayerData.currentRunSpeed.ToString();
    }

    public void toggleButton()
    {
        debugMenuObj.SetActive(!debugMenuObj.activeSelf);
    }
}