using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tutorial : MonoBehaviour
{
    [SerializeField] string mainMenuSceneName;
    [SerializeField] TextMeshProUGUI pageText;
    [SerializeField] Image img;
    [SerializeField] Sprite[] tutorialImages;
    int currentImageIndex = 0;

    void Awake()
    {
        img.sprite = tutorialImages[0];
        pageText.text = (currentImageIndex + 1).ToString() + " / " + tutorialImages.Length.ToString();
    }

    public void back()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(mainMenuSceneName);
    }

    public void next()
    {
        if(currentImageIndex < tutorialImages.Length - 1)
        {
            currentImageIndex++;
            img.sprite = tutorialImages[currentImageIndex];
            pageText.text = (currentImageIndex + 1).ToString() + " / " + tutorialImages.Length.ToString();
        }
    }

    public void previous()
    {
        if(currentImageIndex > 0)
        {
            currentImageIndex--;
            img.sprite = tutorialImages[currentImageIndex];
            pageText.text = (currentImageIndex + 1).ToString() + " / " + tutorialImages.Length.ToString();
        }
    }
}