using UnityEngine;

//parent class, dont use raw
abstract public class Clickable : MonoBehaviour
{
    abstract public void hoverStart();

    abstract public void hoverEnd();

    abstract public void clicked();
}
