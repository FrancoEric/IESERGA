using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hpRegenDelay = 10f;
    [SerializeField] Slider hpSlider;
    [SerializeField] Slider extraHpSlider;
    float regenTimer = 0f;

    void Awake()
    {
        
    }

    public void takeDamage(float dmg)
    {
        PlayerData.currentHealth -= dmg;
        regenTimer = hpRegenDelay;
    }

    void updateSlider()
    {
        hpSlider.value = PlayerData.currentHealth / PlayerData.currentMaxHealth;
        extraHpSlider.value = PlayerData.currentHealthRegenAmount / PlayerData.currentMaxHealthRegenAmount;
    }

    void Update()
    {
        regenTimer -= Time.deltaTime;
        if(regenTimer <= 0 && PlayerData.currentHealthRegenAmount > 0 && PlayerData.currentHealth < PlayerData.currentMaxHealth)
        {
            PlayerData.currentHealth += PlayerData.currentHealthRegenSpeed * Time.deltaTime;
            PlayerData.currentHealthRegenAmount -= PlayerData.currentHealthRegenSpeed * Time.deltaTime;

            if(PlayerData.currentHealth > PlayerData.currentMaxHealth)
                PlayerData.currentHealth = PlayerData.currentMaxHealth;
            if(PlayerData.currentHealthRegenAmount < 0)
                PlayerData.currentHealthRegenAmount = 0;
        }

        updateSlider();
    }
}