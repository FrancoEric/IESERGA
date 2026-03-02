using UnityEngine;

[CreateAssetMenu(menuName = "Items/Item")]
public class Item : ScriptableObject
{
    public BackpackItemType itemType;
    public Sprite sprite;
    public string Name;
    public string desc;
    public float weight;
    public float carbs;
    public float fat;
    public float protein;
}