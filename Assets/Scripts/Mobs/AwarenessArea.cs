using UnityEngine;

public class AwarenessArea : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform follower;
    Vector2 targetDirection;
    Vector2 differenceVectorTarget;
    
    AwareController awareController;

    [SerializeField] private float playerAwarenessDistance;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float movementSpeed;

    public bool awareOfTarget;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        follower = GameObject.FindGameObjectWithTag("Follower").transform;
    }

    private void Update()
    {
        CheckAware();
    }

    private void FixedUpdate() {
        UpdateTargetDirection();
        RotateTowardsTarget();

    }
    private void UpdateTargetDirection()
    {
        if(awareOfTarget){
            targetDirection = differenceVectorTarget.normalized;
        }else{
            return;
        }
    }

    private void RotateTowardsTarget()
    {
        if(!awareOfTarget){
            transform.rotation = Quaternion.identity;
            return;
        }
        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, targetDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        transform.rotation = rotation;
        
    }

    private void CheckAware()
    {
        differenceVectorTarget = follower.position - transform.position;
        if((differenceVectorTarget  .magnitude < playerAwarenessDistance))
        {
            awareOfTarget = true;
        }else
        {
            awareOfTarget = false;
        }
    }  
}
