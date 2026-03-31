using UnityEngine;
using System.Collections;

public class playerMove : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Transform spriteObj;
    PlayerInputHandler inputHandler;
    Rigidbody2D rb;
    float currentSpeed;
    bool canMove = true;
    float prevAngle = 0f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if(!rb)
        {
            Debug.LogError("Rigidbody2D component not found on " + gameObject.name);
        }

        EventBroadcaster.Instance.AddObserver(EventNames.PLAYER_STOP_MOVEMENT, StopMovement);
        EventBroadcaster.Instance.AddObserver(EventNames.PLAYER_START_MOVEMENT, StartMovement);
        EventBroadcaster.Instance.AddObserver(EventNames.STUN_CONFIRMED, pushAnim);
        EventBroadcaster.Instance.AddObserver(EventNames.PICKED_UP_ITEM, grabAnim);
    }

    void Start()
    {
        inputHandler = PlayerInputHandler.Instance;
    }

    void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveActionAtObserver(EventNames.PLAYER_STOP_MOVEMENT, StopMovement);
        EventBroadcaster.Instance.RemoveActionAtObserver(EventNames.PLAYER_START_MOVEMENT, StartMovement);
        EventBroadcaster.Instance.RemoveActionAtObserver(EventNames.STUN_CONFIRMED, pushAnim);
        EventBroadcaster.Instance.RemoveActionAtObserver(EventNames.PICKED_UP_ITEM, grabAnim);
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
        updateAnims();
        rotateSprite();
    }

    void finalSpeed()
    {
        if(inputHandler.sprinting && PlayerData.localStamina > 0)
        {
            currentSpeed = PlayerData.localRunSpeed;
        }
        else if(PlayerData.localStamina > 0)
        {
            currentSpeed = PlayerData.localWalkSpeed;
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

    void rotateSprite()
    {
        Vector2 dir = inputHandler.moveInput.normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        if(inputHandler.moveInput.magnitude > 0)
            prevAngle = angle;

        spriteObj.rotation = Quaternion.Euler(0f, 0f, prevAngle + 90);
    }

    void updateAnims()
    {
        if(rb.linearVelocity.magnitude > 0)
            animator.SetBool("isMoving", true);
        else    
            animator.SetBool("isMoving", false);
    }

    void pushAnim()
    {
        StartCoroutine(setAnimBoolForAFrame("isPushing"));
    }

    void grabAnim()
    {
        StartCoroutine(setAnimBoolForAFrame("isGrabbing"));
    }

    IEnumerator setAnimBoolForAFrame(string boolName)
    {
        animator.SetBool(boolName, true);
        yield return null;
        animator.SetBool(boolName, false);
    }
}
