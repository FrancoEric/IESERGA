using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class BackpackHandler : MonoBehaviour
{
    [SerializeField] GameObject GridParent;
    [SerializeField] GameObject slotPrefab;
    [SerializeField] GameObject weightParent;
    [SerializeField] TextMeshProUGUI totalWeightText;
    BackpackSlot[] slots;
    BackpackManager managerInstance;
    bool prevBool = false;

    void Awake()
    {
        for(int i = 0; i < PlayerData.baseBackpackSize; i++)
            Instantiate(slotPrefab, GridParent.transform);
        slots = GridParent.transform.GetComponentsInChildren<BackpackSlot>();
        //Debug.Log(slots.Length);
    }

    void Start()
    {
        managerInstance = BackpackManager.Instance;
        GridParent.SetActive(false);
        weightParent.SetActive(false);
    }

    public void toggle()
    {
        GridParent.SetActive(!GridParent.activeSelf);
        weightParent.SetActive(!weightParent.activeSelf);
    }

    void managerUpdateCheck()
    {
        if(managerInstance.newItem)
        {
            managerInstance.newItem = false;

            for(int i = 0; i < PlayerData.baseBackpackSize; i++)
            {
                if(i < managerInstance.backpackData.Count)
                    slots[i].backpackData = managerInstance.backpackData[i];
                else    
                    slots[i].backpackData = new BackpackData(ItemLibrary.Instance.getItemByName("None"),0);
            }

            weightUpdate();
        }
    }

    void playerInputCheck()
    {
        bool currentBool = PlayerInputHandler.Instance.backpack;
        if(currentBool != prevBool && currentBool)
            toggle();

        prevBool = currentBool;
    }

    void weightUpdate()
    {
        float total = 0f;

        foreach(BackpackData data in managerInstance.backpackData)
            total += data.amount * data.itemType.weight;

        totalWeightText.text = total.ToString() + "g";
        PlayerData.currentBackpackWeight = total;
    }

    public void Update()
    {
        managerUpdateCheck();
        playerInputCheck();
    }
}