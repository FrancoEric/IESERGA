using UnityEngine;

public class playerMove : MonoBehaviour
{
    PlayerInputHandler inputHandler;
    Rigidbody2D rb;

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
        rb.linearVelocity = movement.normalized * PlayerData.currentWalkSpeed;
    }

    void Update()
    {
        
    }
}
