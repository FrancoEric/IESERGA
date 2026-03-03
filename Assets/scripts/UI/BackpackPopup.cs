using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BackpackPopup : MonoBehaviour
{
    [SerializeField] float mouseXOffset;
    [SerializeField] float mouseYOffset;
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI descText;
    [SerializeField] TextMeshProUGUI weightText;
    [SerializeField] TextMeshProUGUI caloriesText;
    [SerializeField] TextMeshProUGUI proteinText;
    [SerializeField] TextMeshProUGUI carbsText;
    [SerializeField] TextMeshProUGUI fatText;
    public BackpackData currentData;
    
    void Start()
    {
        currentData = new BackpackData(ItemLibrary.Instance.getItemByName("None"), 0);
    }

    public void putNewItem(BackpackData data)
    {
        currentData = data;
    }

    void Update()
    {
        nameText.text = currentData.itemType.name;
        descText.text = currentData.itemType.desc;
        weightText.text = "Total Weight: " + (currentData.itemType.weight * currentData.amount).ToString() + "g";
        caloriesText.text = "Total Calories: " + (currentData.itemType.calories * currentData.amount).ToString();
        proteinText.text = "Total Protein: " + (currentData.itemType.protein * currentData.amount).ToString();
        carbsText.text = "Total Carbs: " + (currentData.itemType.carbs * currentData.amount).ToString();
        fatText.text = "Total Fat: " + (currentData.itemType.fat * currentData.amount).ToString();

        Vector2 pos = PlayerInputHandler.Instance.mousePosition;
        pos.x += mouseXOffset;
        pos.y += mouseYOffset;
        transform.position = pos;
    }
}