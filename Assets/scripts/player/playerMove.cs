using UnityEngine;

public class playerMove : MonoBehaviour
{
    PlayerInputHandler inputHandler;
    Rigidbody2D rb;
    float currentSpeed;
    bool canMove = true;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if(!rb)
        {
            Debug.LogError("Rigidbody2D component not found on " + gameObject.name);
        }

        EventBroadcaster.Instance.AddObserver(EventNames.PLAYER_STOP_MOVEMENT, StopMovement);
        EventBroadcaster.Instance.AddObserver(EventNames.PLAYER_START_MOVEMENT, StartMovement);
    }

    void Start()
    {
        inputHandler = PlayerInputHandler.Instance;
    }


    void FixedUpdate()
    {
        if(!canMove) 
            return;

        Vector2 movement = inputHandler.moveInput;
        rb.linearVelocity = movement.normalized * currentSpeed;
    }

    void Update()
    {
        finalSpeed();
    }

    void finalSpeed()
    {
        if(inputHandler.sprinting && PlayerData.currentStamina > 0)
        {
            currentSpeed = PlayerData.baseRunSpeed;
        }
        else if(PlayerData.currentStamina > 0)
        {
            currentSpeed = PlayerData.baseWalkSpeed;
        }
        else
        {
            currentSpeed = PlayerData.crawlSpeed;
        }
    }

    void StopMovement()
    {
        canMove = false;
        rb.linearVelocity = Vector2.zero;
    }

    void StartMovement()
    {
        canMove = true;
    }

}
