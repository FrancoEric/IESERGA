using UnityEngine;

public class PlayerNutrients : MonoBehaviour
{
    [SerializeField] float proteinToStrengthMultiplier = 1.0f;
    [SerializeField] float proteinToHealthMultiplier = 1.0f;
    [SerializeField] float fatToHealthRegenMultiplier = 1.0f;
    [SerializeField] float carbToStaminaMultiplier = 1.0f;
    [SerializeField] float fatToStaminaMultiplier = 1.0f;
    [SerializeField] float proteinToStaminaMultiplier = 1.0f;
    [SerializeField] float carbToInitialStaminaMultiplier = 1.0f;
    [SerializeField] float fatToStaminaRegenMultiplier = 1.0f;
    [SerializeField] float proteinToSpeedMultiplier = 1.0f;

    public void updateNutrients()
    {
        PlayerData.currentStrength = PlayerData.baseStrength + (PlayerData.protein * proteinToStrengthMultiplier);

        PlayerData.currentMaxHealth = PlayerData.baseMaxHealth + (PlayerData.protein * proteinToHealthMultiplier);
        PlayerData.currentHealthRegenSpeed = PlayerData.baseHealthRegenSpeed + (PlayerData.fats * fatToHealthRegenMultiplier);
        PlayerData.currentHealthRegenAmount = PlayerData.baseMaxHealthRegenAmount + (PlayerData.fats * fatToHealthRegenMultiplier);

        PlayerData.currentMaxStamina = PlayerData.baseStamina + (PlayerData.carbs * carbToStaminaMultiplier) + (PlayerData.fats * fatToStaminaMultiplier) + (PlayerData.protein * proteinToStaminaMultiplier);
        PlayerData.currentInitialStaminaRatio = PlayerData.baseInitialStaminaRatio + (PlayerData.carbs * carbToInitialStaminaMultiplier);
        PlayerData.currentStaminaRegen = PlayerData.baseStaminaRegen + (PlayerData.fats * fatToStaminaRegenMultiplier);

        PlayerData.currentRunSpeed = PlayerData.baseRunSpeed + (PlayerData.protein * proteinToSpeedMultiplier);
        PlayerData.currentWalkSpeed = PlayerData.baseWalkSpeed + (PlayerData.protein * proteinToSpeedMultiplier);
    }
}