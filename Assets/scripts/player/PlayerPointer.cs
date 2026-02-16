using UnityEngine;
using System.Collections.Generic;

public class PlayerPointer : MonoBehaviour
{
    [SerializeField] float maxPointerDistance = 1.0f;
    PlayerInputHandler inputHandler;
    Transform playerTransform;
    bool prevBool = false;
    List<Clickable> hoveredObjects = new List<Clickable>();
    Clickable currentPointerObject;
    Clickable prevPointerObject;
    
    void Awake()
    {   
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Start()
    {
        inputHandler = PlayerInputHandler.Instance;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Clickable comp = other.gameObject.GetComponent<Clickable>();
        if(comp)
        {
            hoveredObjects.Add(comp);
            currentPointerObject = comp;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Clickable comp = other.gameObject.GetComponent<Clickable>();
        if(comp)
        {
            foreach(Clickable c in hoveredObjects)
            {
                if(c == comp)
                {
                    hoveredObjects.Remove(c);
                    break;
                }
            }
            
            if(currentPointerObject == comp)
            {
                if(hoveredObjects.Count > 0)
                    currentPointerObject = hoveredObjects[hoveredObjects.Count - 1];
                else
                    currentPointerObject = null;
            }
        }
    }

    void Update()
    {
        onLeftClick();
        movePointer();
        updateHovers();
    }

    void updateHovers()
    {
        if(currentPointerObject != prevPointerObject)
        {
            if(prevPointerObject)
                prevPointerObject.hoverEnd();
            if(currentPointerObject)
                currentPointerObject.hoverStart();
        }
        prevPointerObject = currentPointerObject;
    }

    void movePointer()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(inputHandler.mousePosition);
        Vector2 direction = mousePos - (Vector2)playerTransform.position;

        if(direction.magnitude > maxPointerDistance)
            direction = direction.normalized * maxPointerDistance;

        transform.position = (Vector2)playerTransform.position + direction;
    }

    void onLeftClick()
    {
        if(inputHandler.leftClick && !prevBool)
        {
            if(currentPointerObject)
                currentPointerObject.clicked();
        }
        prevBool = inputHandler.leftClick;
    }
}
