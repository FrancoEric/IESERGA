using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

[System.Serializable]
public enum BackpackItemType
{
    Food,
    None
}

public class BackpackManager : MonoBehaviour
{
    public static BackpackManager Instance {get; private set; }
    public List<BackpackData> backpackData {get;private set;} = new List<BackpackData>();
    public List<BackpackData> localBackpack {get;private set;} = new List<BackpackData>();
    public bool newItem = false;
    
    void Awake()
    {
        if(Instance != null && Instance != this) 
        {
            Destroy(this.gameObject);
        } 
        else 
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        EventBroadcaster.Instance.AddObserver(EventNames.FINISH_TRIGGER, copyLocalToMain);
    }

    public bool addItem(Item item, int amount)
    {
        for(int i = 0; i < localBackpack.Count; i++)
            if(localBackpack[i].itemType.Name == item.name)
            {
                localBackpack[i].amount += amount;
                newItem = true;
                return true;
            }

        if(localBackpack.Count < PlayerData.baseBackpackSize)
        {
            BackpackData temp = new BackpackData();
            temp.itemType = item;
            temp.amount = amount;
            localBackpack.Add(temp);
            newItem = true;
            return true;
        }

        return false;
    }

    public void removeItem(Item item, int amount)
    {
        for(int i = 0; i < localBackpack.Count; i++)
            if(localBackpack[i].itemType.Name == item.name)
            {
                localBackpack[i].amount -= amount;
                if(localBackpack[i].amount <= 0)
                    localBackpack.RemoveAt(i);
                newItem = true;
            }
    }

    void copyLocalToMain()
    {
        backpackData.Clear();
        foreach(BackpackData data in localBackpack)
            backpackData.Add(data);
            
        newItem = true;
    }
}
