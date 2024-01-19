using UnityEngine;

public class MovementSpirit : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] private float linearDrag;
    [SerializeField] private float movementSpeed;

    private Vector2 unNormalisedVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.drag = linearDrag; //To make things that are required to be change in the same place
    }

   private void Update() {
        MoveVertical();
        MoveHorizontal();
   }

    private void MoveVertical()
    {
        if(Input.GetKey(KeyCode.W))
        {
            unNormalisedVelocity = new Vector2(rb.velocity.x,movementSpeed);
            rb.velocity = (unNormalisedVelocity.normalized)*movementSpeed;
        }
        else if(Input.GetKey(KeyCode.S))
        {
            unNormalisedVelocity = new Vector2(rb.velocity.x,-1*movementSpeed);
            rb.velocity = (unNormalisedVelocity.normalized)*movementSpeed;
        }
    }
    private void MoveHorizontal(){
        if(Input.GetKey(KeyCode.D))
        {
            unNormalisedVelocity = new Vector2(movementSpeed,rb.velocity.y);
            rb.velocity = (unNormalisedVelocity.normalized)*movementSpeed;
        }
        else if(Input.GetKey(KeyCode.A))
        {
            unNormalisedVelocity = new Vector2(-1*movementSpeed,rb.velocity.y);
            rb.velocity = (unNormalisedVelocity.normalized)*movementSpeed;
        }
    }
    
}
