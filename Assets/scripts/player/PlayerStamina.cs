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
        EventBroadcaster.Instance.AddObserver(EventNames.STUN_CONFIRMED, this.attacked);
        EventBroadcaster.Instance.AddObserver(EventNames.FINISHED_BREAKFAST, this.resetStamina);
    }

    void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveActionAtObserver(EventNames.STUN_CONFIRMED, this.attacked);
        EventBroadcaster.Instance.RemoveActionAtObserver(EventNames.FINISHED_BREAKFAST, this.resetStamina);
    }

    void Start()
    {
        inputHandler = PlayerInputHandler.Instance;
    }   

    void Update()
    {
        updateStamina();
        stamSlider.value = PlayerData.localStamina / PlayerData.localMaxStamina;
        attackSlider.value = PlayerData.attackStaminaCost / PlayerData.localMaxStamina;
    }

    void updateStamina()
    {
        if(inputHandler.moveInput.magnitude > 0 && !inputHandler.sprinting)
        {
            PlayerData.localStamina -= (PlayerData.localStaminaDrain + (PlayerData.currentWeightStaminaDrainMultiplier * PlayerData.currentBackpackWeight)) * Time.deltaTime;
            staminaRegenTimer = 0f;
        }
        else if(inputHandler.moveInput.magnitude > 0 && inputHandler.sprinting)
        {
            float drain = (PlayerData.localStaminaDrain * PlayerData.sprintStaminaDrainMultiplier + (PlayerData.currentWeightStaminaDrainMultiplier * PlayerData.currentBackpackWeight)) * Time.deltaTime;
            PlayerData.localStamina -= drain;
            staminaRegenTimer = 0f;
            //Debug.Log("stam drain: " + drain);
        }
        else
        {
            staminaRegenTimer += Time.deltaTime;
            if(staminaRegenTimer >= staminaRegenDelay)
                PlayerData.localStamina += PlayerData.localStaminaRegen * Time.deltaTime;

            if(PlayerData.localStamina > PlayerData.localMaxStamina)
                PlayerData.localStamina = PlayerData.localMaxStamina;
        }

        if(PlayerData.localStamina < 0)
            PlayerData.localStamina = 0;
    }

    public void resetStamina()
    {
        PlayerData.localStamina = PlayerData.localMaxStamina * PlayerData.localInitialStaminaRatio;
    }

    void attacked()
    {
        PlayerData.localStamina -= PlayerData.attackStaminaCost;
        staminaRegenTimer = 0f;
    }
}