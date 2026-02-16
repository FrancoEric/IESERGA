using UnityEngine;

static public class PlayerData
{
    [SerializeField] public static float baseHealth = 100f;
    [SerializeField] public static float baseWalkSpeed = 3f;
    [SerializeField] public static float baseRunSpeed = 5f;

    public static float currentHealth = baseHealth;
    public static float currentWalkSpeed = baseWalkSpeed;   
    public static float currentRunSpeed = baseRunSpeed;
}