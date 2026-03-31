using UnityEngine;
using System.Collections;

//doesnt control the duration drain
//also pushes the entity
public class Stunable : Clickable
{
    [SerializeField] SpriteRenderer sprite;
    Rigidbody2D rb;
    GameObject player;
    Color ogColor;
    public float stunDuration {get; set;} = 0f;
    public float pushForce {get; set;} = 0f;

    void Awake()
    {
        ogColor = sprite.color;
        pushForce = PlayerData.localPushForce;
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    public override void hoverStart()
    {
        if(stunDuration <= 0)
            startHoverColor(Color.red, 0.3f);
    }

    public override void hoverEnd()
    {
        if(stunDuration <= 0)
            endHoverColor();
    }

    public override void clicked()
    {
        if(stunDuration <= 0 && PlayerData.localStamina >= PlayerData.attackStaminaCost)
        {
            stunDuration = PlayerData.localStrength;
            StartCoroutine(stunFlash(Color.black, 0.3f));
            EventBroadcaster.Instance.PostEvent(EventNames.STUN_CONFIRMED);
            Debug.Log("Stun confirmed");
        }
    }

    void startHoverColor(Color targetColor, float colorMult)
    {
        Color halfColor = new Color(
            targetColor.r * colorMult,
            targetColor.g * colorMult,
            targetColor.b * colorMult,
            targetColor.a
        );

        sprite.color = halfColor;
    }

    void endHoverColor()
    {
        sprite.color = ogColor;
    }

    //also handles pushing physics 
    IEnumerator stunFlash(Color targetColor, float colorMult)
    {
        Color halfColor = new Color(
            targetColor.r * colorMult,
            targetColor.g * colorMult,
            targetColor.b * colorMult,
            targetColor.a
        );

        sprite.color = halfColor;

        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.AddForce((transform.position - player.transform.position).normalized * pushForce, ForceMode2D.Impulse);

        yield return new WaitForSeconds(stunDuration);
        yield return null;

        // Restore original color
        sprite.color = ogColor;

        rb.linearVelocity = Vector2.zero;
        rb.bodyType = RigidbodyType2D.Kinematic;
    }
}