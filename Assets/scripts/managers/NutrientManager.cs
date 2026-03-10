using UnityEngine;

//not fully optimized
//like not enough specific multipliers and not stat balanced
public class NutrientManager : MonoBehaviour
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
    public static NutrientManager Instance {get; private set; }

    void Awake()
    {
        if(Instance != null && Instance != this) 
        {
            Destroy(this.gameObject);
        } 
        else 
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void updateLocalNutrients()
    {
        PlayerData.localStrength = PlayerData.currentStrength + (PlayerData.protein * proteinToStrengthMultiplier);
        PlayerData.localPushForce = PlayerData.currentPushForce + (PlayerData.protein * proteinToStrengthMultiplier);

        PlayerData.localMaxHealth = PlayerData.currentMaxHealth + (PlayerData.protein * proteinToHealthMultiplier);
        PlayerData.localHealthRegenSpeed = PlayerData.currentHealthRegenSpeed + (PlayerData.fats * fatToHealthRegenMultiplier);
        PlayerData.localHealthRegenAmount = PlayerData.currentHealthRegenAmount + (PlayerData.fats * fatToHealthRegenMultiplier);

        PlayerData.localMaxStamina = PlayerData.currentStamina + (PlayerData.carbs * carbToStaminaMultiplier) + (PlayerData.fats * fatToStaminaMultiplier) + (PlayerData.protein * proteinToStaminaMultiplier);
        PlayerData.localInitialStaminaRatio = PlayerData.currentInitialStaminaRatio + (PlayerData.carbs * carbToInitialStaminaMultiplier);
        PlayerData.localStaminaRegen = PlayerData.currentStaminaRegen + (PlayerData.fats * fatToStaminaRegenMultiplier);

        PlayerData.localRunSpeed = PlayerData.currentRunSpeed + (PlayerData.protein * proteinToSpeedMultiplier);
        PlayerData.localWalkSpeed = PlayerData.currentWalkSpeed + (PlayerData.protein * proteinToSpeedMultiplier);
    }
}