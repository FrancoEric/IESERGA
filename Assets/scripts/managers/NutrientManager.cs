using UnityEngine;

//not fully optimized
//like not enough specific multipliers and not stat balanced
//basically the stat manager 
public class NutrientManager : MonoBehaviour
{
    [SerializeField] float proteinToStrengthMultiplier = 1.0f;
    [SerializeField] float proteinToPushMultiplier = 1.0f;
    [SerializeField] float proteinToHealthMultiplier = 1.0f;
    [SerializeField] float fatToHealthRegenMultiplier = 1.0f;
    [SerializeField] float proteinToHealthRegenAmountMultiplier = 1.0f;
    [SerializeField] float carbToStaminaMultiplier = 1.0f;
    [SerializeField] float fatToStaminaMultiplier = 1.0f;
    [SerializeField] float proteinToStaminaMultiplier = 1.0f;
    [SerializeField] float carbToInitialStaminaMultiplier = 1.0f;
    [SerializeField] float fatToStaminaRegenMultiplier = 1.0f;
    [SerializeField] float proteinToWalkSpeedMultiplier = 1.0f;
    [SerializeField] float proteinToRunSpeedMultiplier = 1.0f;
    [SerializeField] float proteinToWeightStaminaDrainMultiplier = 1.0f;
    public static NutrientManager Instance {get; private set; }
    bool eatingPhase = false;

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

        EventBroadcaster.Instance.AddObserver(EventNames.START_BREAKFAST, this.startEating);
        EventBroadcaster.Instance.AddObserver(EventNames.FINISHED_BREAKFAST, this.endEating);
    }

    void startEating()
    {
        eatingPhase = true;
    }

    void endEating()
    {
        eatingPhase = false;
    }

    public void updateLocalStats()
    {
        PlayerData.localStrength = PlayerData.baseStrength + (PlayerData.protein * proteinToStrengthMultiplier);
        PlayerData.localPushForce = PlayerData.basePushForce + (PlayerData.protein * proteinToPushMultiplier);

        PlayerData.localMaxHealth = PlayerData.baseMaxHealth + (PlayerData.protein * proteinToHealthMultiplier);
        PlayerData.localHealthRegenSpeed = PlayerData.baseHealthRegenSpeed + (PlayerData.fats * fatToHealthRegenMultiplier);
        PlayerData.localMaxHealthRegenAmount = PlayerData.baseMaxHealthRegenAmount + (PlayerData.protein * proteinToHealthRegenAmountMultiplier);

        PlayerData.localMaxStamina = PlayerData.baseStamina + (PlayerData.carbs * carbToStaminaMultiplier) + (PlayerData.fats * fatToStaminaMultiplier) + (PlayerData.protein * proteinToStaminaMultiplier);
        PlayerData.localInitialStaminaRatio = PlayerData.baseInitialStaminaRatio + (PlayerData.carbs * carbToInitialStaminaMultiplier);
        PlayerData.localStaminaRegen = PlayerData.baseStaminaRegen + (PlayerData.fats * fatToStaminaRegenMultiplier);

        PlayerData.localRunSpeed = PlayerData.baseRunSpeed + (PlayerData.protein * proteinToRunSpeedMultiplier);
        PlayerData.localWalkSpeed = PlayerData.baseWalkSpeed + (PlayerData.protein * proteinToWalkSpeedMultiplier);
        PlayerData.currentWeightStaminaDrainMultiplier = PlayerData.baseWeightStaminaDrainMultiplier + (PlayerData.protein * proteinToWeightStaminaDrainMultiplier);
    }

    void Update()
    {
        if(eatingPhase)
            updateLocalStats();
    }
}