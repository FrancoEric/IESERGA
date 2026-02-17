using UnityEngine;

static public class PlayerData
{
    public static float baseHealth = 100f;
    public static float crawlSpeed = 1f; //doesnt need a current ver
    public static float baseWalkSpeed = 3f;
    public static float baseRunSpeed = 5f;
    public static float baseStamina = 100f;
    public static float baseStaminaDrain = 5f;
    public static float baseStaminaRegen = 5f;
    public static float sprintStaminaDrainMultiplier = 2.5f; //doesnt need a current ver

    //only use current vers in code as the "main" stat vars
    public static float currentHealth = baseHealth;
    public static float currentWalkSpeed = baseWalkSpeed;   
    public static float currentRunSpeed = baseRunSpeed;
    public static float currentMaxStamina = baseStamina;
    public static float currentStamina = baseStamina;
    public static float currentStaminaDrain = baseStaminaDrain;
    public static float currentStaminaRegen = baseStaminaRegen;
}