using UnityEngine;
using UnityEngine.UI;

public class PlayerStamina : MonoBehaviour
{
    [SerializeField] Slider stamSlider;
    [SerializeField] Slider attackSlider;
    [SerializeField] float staminaRegenDelay = 2f;
    float staminaRegenTimer = 0f;
    PlayerInputHandler inputHandler;

    void Awake()
    {
        resetStamina();
        EventBroadcaster.Instance.AddObserver(EventNames.STUN_CONFIRMED, this.attacked);
    }

    void Start()
    {
        inputHandler = PlayerInputHandler.Instance;
    }   

    void Update()
    {
        updateStamina();
        stamSlider.value = PlayerData.currentStamina / PlayerData.currentMaxStamina;
        attackSlider.value = PlayerData.attackStaminaCost / PlayerData.currentMaxStamina;
    }

    void updateStamina()
    {
        if(inputHandler.moveInput.magnitude > 0 && !inputHandler.sprinting)
        {
            PlayerData.currentStamina -= PlayerData.currentStaminaDrain * PlayerData.currentWeightStaminaDrainMultiplier * Time.deltaTime;
            staminaRegenTimer = 0f;
        }
        else if(inputHandler.moveInput.magnitude > 0 && inputHandler.sprinting)
        {
            PlayerData.currentStamina -= PlayerData.currentStaminaDrain * PlayerData.sprintStaminaDrainMultiplier * PlayerData.currentWeightStaminaDrainMultiplier * Time.deltaTime;
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

    public void resetStamina()
    {
        PlayerData.currentStamina = PlayerData.currentMaxStamina * PlayerData.currentInitialStaminaRatio;
    }

    void attacked()
    {
        PlayerData.currentStamina -= PlayerData.attackStaminaCost;
    }
}