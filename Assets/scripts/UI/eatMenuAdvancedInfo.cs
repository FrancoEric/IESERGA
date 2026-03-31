using UnityEngine;

public class eatMenuAdvancedInfo : MonoBehaviour
{
    [SerializeField] GameObject advInfoParent;

        void Update()
        {
            if(!PlayerData.showAdvancedInfo)
                advInfoParent.SetActive(false);
            else    
                advInfoParent.SetActive(true);
        }
    }