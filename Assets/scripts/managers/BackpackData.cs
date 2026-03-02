using UnityEngine;

[System.Serializable]
public class BackpackData
{
    public Item itemType;
    public int amount;

    public BackpackData(Item item, int amount)
    {
        this.itemType = item;
        this.amount = amount;
    }

    public BackpackData(){}
}