using UnityEngine;

public class advancedInfoToggle : MonoBehaviour
{
    public void toggleAdvanced()
    {
        PlayerData.showAdvancedInfo = !PlayerData.showAdvancedInfo;
    }
}
