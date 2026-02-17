using UnityEngine;
using UnityEngine.UI;

public class PlayerStamina : MonoBehaviour
{
    [SerializeField] Slider stamSlider;
    [SerializeField] float staminaRegenDelay = 2f;
    float staminaRegenTimer = 0f;
    PlayerInputHandler inputHandler;

    void Awake()
    {

    }

    void Start()
    {
        inputHandler = PlayerInputHandler.Instance;
    }   

    void Update()
    {
        updateStamina();
        stamSlider.value = PlayerData.currentStamina / PlayerData.currentMaxStamina;
    }

    void updateStamina()
    {
        if(inputHandler.moveInput.magnitude > 0 && !inputHandler.sprinting)
        {
            PlayerData.currentStamina -= PlayerData.currentStaminaDrain * Time.deltaTime;
            staminaRegenTimer = 0f;
        }
        else if(inputHandler.moveInput.magnitude > 0 && inputHandler.sprinting)
        {
            PlayerData.currentStamina -= PlayerData.currentStaminaDrain * PlayerData.sprintStaminaDrainMultiplier * Time.deltaTime;
            staminaRegenTimer = 0f;
        }
        else
        {
            staminaRegenTimer += Time.deltaTime;
            if(staminaRegenTimer >= staminaRegenDelay)
                PlayerData.currentStamina += PlayerData.currentStaminaRegen * Time.deltaTime;
        }

        if(PlayerData.currentStamina < 0)
            PlayerData.currentStamina = 0;
    }
}