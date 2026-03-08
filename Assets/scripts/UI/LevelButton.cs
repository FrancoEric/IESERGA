using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelButton : MonoBehaviour
{
    [SerializeField] LevelSelection levelSelection;
    [SerializeField] GameObject lockedIcon;
    [SerializeField] TextMeshProUGUI levelNameText;
    [SerializeField] int levelIndex;
    [SerializeField] string levelName;
    bool isLocked = true;

    void Start()
    {
        if(PlayerData.currentLevelIndexUnlocked == levelIndex)
        {
            isLocked = false;
            
        }
        else
        {
            isLocked = true;
        }
        lockedIcon.SetActive(isLocked);
        levelNameText.text = levelName;
    }

    public void startLevel()
    {
        if(!isLocked)
        {
            levelSelection.startLevel(levelIndex);
        }
    }
}