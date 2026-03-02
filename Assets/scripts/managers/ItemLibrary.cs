using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ItemLibrary : MonoBehaviour
{
    public static ItemLibrary Instance {get; private set; }
    [SerializeField] public Item[] items;

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
    }

    public Item getItemByName(string name)
    {
        for(int i = 0; i < items.Length; i++)
        {
            if(items[i].Name == name)
                return items[i];
        }

        Debug.Log("No item of name " + name + " was found, defualting to null");
        return null;
    }
}