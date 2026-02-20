using UnityEngine;
using System.Collections;

//doesnt control the duration drain
public class Stunable : Clickable
{
    [SerializeField] SpriteRenderer sprite;
    Color ogColor;
    public float stunDuration {get; set;} = 0f;

    void Awake()
    {
        ogColor = sprite.color;
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
        if(stunDuration <= 0 && PlayerData.currentStamina >= PlayerData.attackStaminaCost)
        {
            stunDuration = PlayerData.currentStrength;
            StartCoroutine(stunFlash(Color.black, 0.3f));
            EventBroadcaster.Instance.PostEvent(EventNames.STUN_CONFIRMED);
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

    IEnumerator stunFlash(Color targetColor, float colorMult)
    {
        Color halfColor = new Color(
            targetColor.r * colorMult,
            targetColor.g * colorMult,
            targetColor.b * colorMult,
            targetColor.a
        );

        sprite.color = halfColor;

        yield return new WaitForSeconds(stunDuration);

        // Restore original color
        sprite.color = ogColor;
    }
}