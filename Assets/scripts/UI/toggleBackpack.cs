using UnityEngine;

public class ToggleBackpack : MonoBehaviour
{
    [SerializeField] GameObject toggleable;

    void Start()
    {
        toggleable.SetActive(false);
    }

    public void toggle()
    {
        toggleable.SetActive(!toggleable.activeSelf);
    }
}