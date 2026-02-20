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
    public static float attackStaminaCost = 40f; //no current ver 

    //only use current vers in code as the "main" stat vars
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

    //the backpack stuff 
    public static float currentBackpackWeight = 0f;
    public static float baseWeightStaminaDrainMultiplier = 1.2f; 
    public static float currentWeightStaminaDrainMultiplier = baseWeightStaminaDrainMultiplier; 
}