using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] Slider hpSlider;

    void Awake()
    {
        
    }

    public void takeDamage(float dmg)
    {
        PlayerData.currentHealth -= dmg;
    }

    void updateSlider()
    {
        hpSlider.value = PlayerData.currentHealth / PlayerData.currentMaxHealth;
    }

    void Update()
    {
        updateSlider();
    }
}