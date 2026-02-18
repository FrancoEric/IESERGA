using UnityEngine;
using System.Collections;

enum ZombieState
{
    Idle,
    Alterted,
    Stunned
}

public class HumanoidZombie : HumanoidMovement
{
    [SerializeField] string playerTag = "Player";
    [SerializeField] float damage = 55f;
    [SerializeField] float attackDelay = 1f;
    [SerializeField] float attackInterval = 2f;
    [SerializeField] float idleRoamRadius = 5f;
    [SerializeField] float startIdleWaitTime = 5f;
    [SerializeField] float idleWaitTime = 3f;
    ZombieState currentState;
    Stunable stunComp;
    Vector2 idleLocation;
    Vector2 targetLocation;
    string targetTag;
    float idleTimder = 0f;
    float attackTimer = 0f;
    Transform playerTransform;
    PlayerHealth hpComp;

    override protected void Awake()
    {
        base.Awake();

        idleLocation = transform.position;
        currentState = ZombieState.Idle;

        GameObject player = GameObject.FindWithTag(playerTag);
        playerTransform = player.transform;
        hpComp = player.GetComponent<PlayerHealth>();

        stunComp = GetComponent<Stunable>();
    }

    public void setAltertedTarget(Vector2 target)
    {
        targetLocation = target;
        currentState = ZombieState.Alterted;
        idleTimder = startIdleWaitTime;
    }

    public void startIdle()
    {
        currentState = ZombieState.Idle;
    }

    //waits for a bit before idle starts
    //randomly roams around spawn point
    void idleUpdate()
    {
        idleTimder -= Time.deltaTime;
        if(idleTimder <= 0)
        {
            Vector2 randomDirection = Random.insideUnitCircle.normalized;
            Vector2 randomPoint = idleLocation + randomDirection * Random.Range(0.1f, idleRoamRadius);
            setTarget(randomPoint);
            idleTimder = idleWaitTime;
        }

        stopIfReachedTarget();
    }

    void altertedUpdate()
    {
        float distance = (centerOfMass.transform.position - playerTransform.position).sqrMagnitude;
        if(agent.stoppingDistance * agent.stoppingDistance < distance)
            setTarget(targetLocation);
        stopIfReachedTarget();

        if(isAtTarget)
        {
            attackTimer -= Time.deltaTime;
            if(attackTimer <= 0)
            {
                hpComp.takeDamage(damage);
                attackTimer = attackInterval;
            }
        }
        else    
            attackTimer = attackDelay;

        //Debug.Log(isAtTarget);
    }

    void Update()
    {
        switch(currentState)
        {
            case ZombieState.Idle:
                idleUpdate();
                break;
            
            case ZombieState.Alterted:
                altertedUpdate();
                break;
        }

        //AI
        if(stunComp.stunDuration > 0)
        {
            currentState = ZombieState.Stunned;
            stunComp.stunDuration -= Time.deltaTime;
        }
        else if(checkLoS(playerTransform.position, playerTag))
        {
            setAltertedTarget(playerTransform.position);
            idleLocation = playerTransform.position;
        }
        else
        {
            startIdle();
        }
    }
}