using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStatsUIHandler : MonoBehaviour
{
    [SerializeField] GameObject playerStatsParent;
    [SerializeField] TextMeshProUGUI proteinText;
    [SerializeField] TextMeshProUGUI carbsText;
    [SerializeField] TextMeshProUGUI fatText;
    [SerializeField] TextMeshProUGUI strengthText;
    [SerializeField] TextMeshProUGUI vitalityText;
    [SerializeField] TextMeshProUGUI recoveryText;
    [SerializeField] TextMeshProUGUI mobilityText;
    [SerializeField] TextMeshProUGUI maxStaminaText;
    [SerializeField] TextMeshProUGUI initStaminaText;
    [SerializeField] TextMeshProUGUI stamregenText;
    bool prevBool = false;

    void Awake()
    {
        playerStatsParent.SetActive(false);
    }

    void OnEnable()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.OPEN_BACKPACK, close);
    }

    void OnDisable()
    {
        EventBroadcaster.Instance.RemoveActionAtObserver(EventNames.OPEN_BACKPACK, close);
    }

    void Update()
    {
        proteinText.text = "Protein: " + PlayerData.protein.ToString();
        carbsText.text = "Carbs: " + PlayerData.carbs.ToString();
        fatText.text = "Fat: " + PlayerData.fats.ToString();
        strengthText.text = "Strength: " + PlayerData.localStrength.ToString();
        vitalityText.text = "Vitality: " + PlayerData.localMaxHealth.ToString();
        recoveryText.text = "Wound Recovery: " + PlayerData.localHealthRegenSpeed.ToString();
        mobilityText.text = "Mobility: " + PlayerData.localRunSpeed.ToString();
        maxStaminaText.text = "Max Stamina: " + PlayerData.localMaxStamina.ToString();
        initStaminaText.text = "Initial Stamina: " + PlayerData.localInitialStaminaRatio.ToString();
        stamregenText.text = "Stamina Regen: " + PlayerData.localStaminaRegen.ToString();

        playerInputCheck();
    }

    void playerInputCheck()
    {
        bool currentBool = PlayerInputHandler.Instance.stats;
        if(currentBool != prevBool && currentBool)
            toggle();

        prevBool = currentBool;
    }

    public void toggle()
    {
        playerStatsParent.SetActive(!playerStatsParent.activeSelf);

        if(playerStatsParent.activeSelf)
            EventBroadcaster.Instance.PostEvent(EventNames.OPEN_STATS);
    }

    void close()
    {
        playerStatsParent.SetActive(false);
    }
}
