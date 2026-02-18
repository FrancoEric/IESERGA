using UnityEngine;
using UnityEngine.AI;

//basic movement controlled by ai
//moves via navmesh agent, but also has a rigidbody for stuff like knockback and physics interactions
public class HumanoidMovement : MonoBehaviour
{
    [SerializeField] float mass = 1;
    [SerializeField] float speed = 1;
    [SerializeField] float acceleration = 1;
    [SerializeField] float stoppingDistance = 0.2f;
    [SerializeField] protected GameObject centerOfMass;
    [SerializeField] float detectionDistance = 10f;
    protected NavMeshAgent agent;
    NavMeshHit hit;
    protected Rigidbody2D rb;
    protected Collider2D col;
    protected bool isAtTarget = false;

    virtual protected void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if(!rb)
        {
            Debug.Log(gameObject.name + " is missing Rigidbody2D component");
            return;
        }

        agent = GetComponent<NavMeshAgent>();
        if(!agent)
        {
            Debug.Log(gameObject.name + " is missing NavMeshAgent component");
            return;
        }

        col = GetComponent<Collider2D>();
        if(!col)        
        {
            Debug.Log(gameObject.name + " is missing Collider2D component");
            return;
        }

        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.gravityScale = 0;
        rb.mass = mass;
        rb.freezeRotation = true;

        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.speed = speed;
        agent.acceleration = acceleration;
        agent.stoppingDistance = stoppingDistance;
    }

    virtual protected void setTarget(Vector2 target)
    {
        if (NavMesh.SamplePosition(target, out hit, 5f, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }
    }

    virtual protected void stopMoving()
    {
        if(agent)
            agent.ResetPath();
    }

    virtual protected void stopIfReachedTarget()
    {
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            stopMoving();
            isAtTarget = true;
        }
        else    
            isAtTarget = false;
    }

    virtual public bool checkLoS(Vector2 target, string tag)
    {
        Vector2 start = centerOfMass.transform.position;
        Vector2 direction = (target - start).normalized;

        int layerMask = ~LayerMask.GetMask("Ignore Raycast"); //uses defualt ignore raycast layer to ignore itself and other humanoids

        RaycastHit2D hit = Physics2D.Raycast(start, direction, detectionDistance, layerMask);
        Debug.DrawRay(start, direction * detectionDistance, Color.red);

        if (hit.collider != null && hit.collider.CompareTag(tag))
        {
            //Debug.Log("LoS to " + tag + " confirmed by " + gameObject.name);
            return true;
        }

        return false;
    }
}
