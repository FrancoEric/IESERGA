using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStatsUIHandler : MonoBehaviour
{
    [SerializeField] GameObject playerStatsParent;
    [SerializeField] TextMeshProUGUI proteinText;
    [SerializeField] TextMeshProUGUI carbsText;
    [SerializeField] TextMeshProUGUI fatText;

    void Awake()
    {
        playerStatsParent.SetActive(false);
    }

    void Update()
    {
        proteinText.text = "Protein: " + PlayerData.protein.ToString();
        carbsText.text = "Carbs: " + PlayerData.carbs.ToString();
        fatText.text = "Fat: " + PlayerData.fats.ToString();
    }

    public void toggle()
    {
        playerStatsParent.SetActive(!playerStatsParent.activeSelf);
    }
}
