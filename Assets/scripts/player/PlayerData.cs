using UnityEngine;

static public class PlayerData
{
    //initial nutrient stats, doesn need a current ver, update these
    public static float protein = 0f;
    public static float carbs = 0f;
    public static float fats = 0f;

    //modify these stats to balance 
    public static float baseMaxHealth = 100f;
    public static float baseHealthRegenSpeed = 1f;
    public static float baseMaxHealthRegenAmount = 50f;
    public static float crawlSpeed = 1f; //doesnt need a current ver
    public static float baseWalkSpeed = 3f;
    public static float baseRunSpeed = 5f;
    public static float baseStamina = 100f;
    public static float baseInitialStaminaRatio = 0.3f;
    public static float baseStaminaDrain = 5f;
    public static float baseStaminaRegen = 5f;
    public static float sprintStaminaDrainMultiplier = 2.5f; //doesnt need a current ver
    public static float baseStrength = 1f; //stun duration basically
    public static float basePushForce = 1f;
    public static float attackStaminaCost = 40f; //no current ver 

    //the player's current saved stats 
    public static float currentMaxHealth = baseMaxHealth;
    public static float currentHealth = baseMaxHealth;
    public static float currentHealthRegenSpeed = baseHealthRegenSpeed;
    public static float currentMaxHealthRegenAmount = baseMaxHealthRegenAmount;
    public static float currentHealthRegenAmount = baseMaxHealthRegenAmount;
    public static float currentWalkSpeed = baseWalkSpeed;   
    public static float currentRunSpeed = baseRunSpeed;
    public static float currentMaxStamina = baseStamina;
    public static float currentStamina = baseStamina;
    public static float currentInitialStaminaRatio = baseInitialStaminaRatio;
    public static float currentStaminaDrain = baseStaminaDrain;
    public static float currentStaminaRegen = baseStaminaRegen;
    public static float currentStrength = baseStrength; 
    public static float currentPushForce = basePushForce;

    //local vers of the current stats for instances 
    public static float localProtein = protein;
    public static float localCarbs = carbs;
    public static float localFats = fats;
    public static float localMaxHealth = baseMaxHealth;
    public static float localHealth = baseMaxHealth;
    public static float localHealthRegenSpeed = baseHealthRegenSpeed;
    public static float localMaxHealthRegenAmount = baseMaxHealthRegenAmount;
    public static float localHealthRegenAmount = baseMaxHealthRegenAmount;
    public static float localWalkSpeed = baseWalkSpeed;   
    public static float localRunSpeed = baseRunSpeed;
    public static float localMaxStamina = baseStamina;
    public static float localStamina = baseStamina;
    public static float localInitialStaminaRatio = baseInitialStaminaRatio;
    public static float localStaminaDrain = baseStaminaDrain;
    public static float localStaminaRegen = baseStaminaRegen;
    public static float localStrength = baseStrength; 
    public static float localPushForce = basePushForce;
    public static void localToCurrent()
    {
        protein = localProtein;
        carbs = localCarbs;
        fats = localFats;
        currentMaxHealth = localMaxHealth;
        currentHealth = localHealth;
        currentHealthRegenSpeed = localHealthRegenSpeed;
        currentMaxHealthRegenAmount = localMaxHealthRegenAmount;
        currentHealthRegenAmount = localHealthRegenAmount;
        currentWalkSpeed = localWalkSpeed;   
        currentRunSpeed = localRunSpeed;
        currentMaxStamina = localMaxStamina;
        currentStamina = localStamina;
        currentInitialStaminaRatio = localInitialStaminaRatio;
        currentStaminaDrain = localStaminaDrain;
        currentStaminaRegen = localStaminaRegen;
        currentStrength = localStrength;
        currentPushForce = localPushForce;
    }
    public static void currentToLocal()
    {
        localProtein = protein;
        localCarbs = carbs;
        localFats = fats;
        localMaxHealth = currentMaxHealth;
        localHealth = currentHealth;
        localHealthRegenSpeed = currentHealthRegenSpeed;
        localMaxHealthRegenAmount = currentMaxHealthRegenAmount;
        localHealthRegenAmount = currentHealthRegenAmount;
        localWalkSpeed = currentWalkSpeed;   
        localRunSpeed = currentRunSpeed;
        localMaxStamina = currentMaxStamina;
        localStamina = currentStamina;
        localInitialStaminaRatio = currentInitialStaminaRatio;
        localStaminaDrain = currentStaminaDrain;
        localStaminaRegen = currentStaminaRegen;
        localStrength = currentStrength;    
        localPushForce = currentPushForce;
    }

    //the backpack stuff 
    public static int baseBackpackSize = 10;
    public static float currentBackpackWeight = 0f;
    public static float baseWeightStaminaDrainMultiplier = 1.2f; 
    public static float currentWeightStaminaDrainMultiplier = baseWeightStaminaDrainMultiplier; 

    //level stuff 
    public static int currentLevelIndexUnlocked = 0;

    //misc stuff
    public static float blackScreenFadeTime = 1f;
}