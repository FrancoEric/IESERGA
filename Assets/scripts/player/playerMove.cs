using UnityEngine;

public class playerMove : MonoBehaviour
{
    PlayerInputHandler inputHandler;
    Rigidbody2D rb;
    float currentSpeed;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if(!rb)
        {
            Debug.LogError("Rigidbody2D component not found on " + gameObject.name);
        }
    }

    void Start()
    {
        inputHandler = PlayerInputHandler.Instance;
    }


    void FixedUpdate()
    {
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
}
