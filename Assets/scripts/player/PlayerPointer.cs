using UnityEngine;

public class PlayerPointer : MonoBehaviour
{
    [SerializeField] float maxPointerDistance = 1.0f;
    PlayerInputHandler inputHandler;
    Transform playerTransform;
    bool prevBool = false;
    GameObject currentPointerObject;
    
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
        currentPointerObject = other.gameObject;
    }

    void Update()
    {
        onLeftClick();
        movePointer();
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
            Debug.Log("Left clicked");
        }
        prevBool = inputHandler.leftClick;
    }
}
