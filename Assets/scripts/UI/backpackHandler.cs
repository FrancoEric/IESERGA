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
    [SerializeField] GameObject popupParent;
    BackpackSlot[] slots;
    BackpackManager managerInstance;
    BackpackPopup backpackPopup;
    bool prevBool = false;

    void Awake()
    {
        for(int i = 0; i < PlayerData.baseBackpackSize; i++)
            Instantiate(slotPrefab, GridParent.transform);
        slots = GridParent.transform.GetComponentsInChildren<BackpackSlot>();
        backpackPopup = GetComponentInChildren<BackpackPopup>();
        //Debug.Log(slots.Length);

        EventBroadcaster.Instance.AddObserver(EventNames.OPEN_STATS, close);
    }

    void Start()
    {
        managerInstance = BackpackManager.Instance;
        GridParent.SetActive(false);
        weightParent.SetActive(false);
        popupParent.SetActive(false);
    }

    public void toggle()
    {
        GridParent.SetActive(!GridParent.activeSelf);
        weightParent.SetActive(!weightParent.activeSelf);

        if(GridParent.activeSelf)
            EventBroadcaster.Instance.PostEvent(EventNames.OPEN_BACKPACK);
    }

    void close()
    {
        GridParent.SetActive(false);
        weightParent.SetActive(false);
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

    void hoverCheck()
    {
        bool check = false;
        foreach(BackpackSlot slot in slots)
        {
            if(slot.isHovered)
            {
                check = true;
                backpackPopup.putNewItem(slot.backpackData);
                break;
            }
        }

        if(check && backpackPopup.currentData.itemType.itemType != BackpackItemType.None)
            popupParent.SetActive(true);
        else
            popupParent.SetActive(false);
    }

    public void Update()
    {
        managerUpdateCheck();
        playerInputCheck();
        hoverCheck();
    }
}