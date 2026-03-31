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
    [System.Serializable]
    struct startingFood
    {
        public string foodName;
        public int amount;
    }
    [SerializeField] startingFood[] startingFoods;

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

    void Start()
    {
        foreach(startingFood item in startingFoods)
        {
            BackpackData temp = new BackpackData();
            temp.itemType = ItemLibrary.Instance.getItemByName(item.foodName);
            temp.amount = item.amount;
            backpackData.Add(temp);
        }
    }

    public bool addItem(Item item, int amount)
    {
        if(amount <= 0)
            return false;

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
        //Debug.Log("item name: " + item.Name);

        for(int i = 0; i < localBackpack.Count; i++)
        {
            //Debug.Log("local backpack item name: " + localBackpack[i].itemType.Name);
            if(localBackpack[i].itemType.Name == item.Name)
            {
                localBackpack[i].amount -= amount;
                if(localBackpack[i].amount <= 0)
                    localBackpack.RemoveAt(i);
                newItem = true;
                break;
            }
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
