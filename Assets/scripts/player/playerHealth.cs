using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] Slider hpSlider;
    [SerializeField] Slider extraHpSlider;
    float regenTimer = 0f;

    void Awake()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.FINISHED_BREAKFAST, this.initHP);
    }

    void initHP()
    {
        PlayerData.localHealth = PlayerData.localMaxHealth;
        PlayerData.localHealthRegenAmount = PlayerData.localMaxHealthRegenAmount;
    }

    public void takeDamage(float dmg)
    {
        PlayerData.localHealth -= dmg;
        if(PlayerData.localHealth < 0)
            PlayerData.localHealth = 0;
        regenTimer = PlayerData.hpRegenDelay;
    }

    void updateSlider()
    {
        hpSlider.value = PlayerData.localHealth / PlayerData.localMaxHealth;
        extraHpSlider.value = PlayerData.localHealthRegenAmount / PlayerData.localMaxHealthRegenAmount;
    }

    void Update()
    {
        regenTimer -= Time.deltaTime;
        if(regenTimer <= 0 && PlayerData.localHealthRegenAmount > 0 && PlayerData.localHealth < PlayerData.localMaxHealth)
        {
            float heal = PlayerData.localHealthRegenSpeed * Time.deltaTime;
            PlayerData.localHealth += heal;
            PlayerData.localHealthRegenAmount -= heal;
            //Debug.Log(PlayerData.localHealthRegenAmount);

            if(PlayerData.localHealth > PlayerData.localMaxHealth)
                PlayerData.localHealth = PlayerData.localMaxHealth;
            if(PlayerData.localHealthRegenAmount < 0)
                PlayerData.localHealthRegenAmount = 0;
        }

        updateSlider();
    }
}