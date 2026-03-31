using UnityEngine;

static public class PlayerData
{
    //initial nutrient stats, doesn need a current ver, update these
    public static float protein = 0f;
    public static float carbs = 0f;
    public static float fats = 0f;
    public static float calories = 0f;

    //modify these stats to balance 
    public static float baseMaxHealth = 100f;
    public static float baseHealthRegenSpeed = 1f;
    public static float baseMaxHealthRegenAmount = 50f;
    public static float hpRegenDelay = 10f;
    public static float crawlSpeed = 1f; //doesnt need a current ver
    public static float baseWalkSpeed = 3f;
    public static float baseRunSpeed = 5f;
    public static float baseStamina = 100f;
    public static float baseInitialStaminaRatio = 0.3f;
    public static float baseStaminaDrain = 5f;
    public static float baseStaminaRegen = 20f;
    public static float sprintStaminaDrainMultiplier = 2.5f; //doesnt need a current ver
    public static float baseStrength = 1f; //stun duration basically
    public static float basePushForce = 1f;
    public static float attackStaminaCost = 40f; //no current ver 

    //local vers of the current stats for instances 
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

    //the backpack stuff 
    public static int baseBackpackSize = 20;
    public static float currentBackpackWeight = 0f;
    public static float baseWeightStaminaDrainMultiplier = 0.01f; 
    public static float currentWeightStaminaDrainMultiplier = baseWeightStaminaDrainMultiplier; 

    //level stuff 
    public static int currentLevelIndexUnlocked = 0;

    //misc stuff
    public static float blackScreenFadeTime = 1f;
    public static bool showAdvancedInfo = false;
}