using System;
using UnityEngine;

public class FollowerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody2D rb;

    [SerializeField]private float forwardSpeed;
    
    private bool moveForward;

    private bool isAlive;

    void Start()
    {
        isAlive = true;
        moveForward = false;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckAlive();
        ToggleMoveForward();
        MoveForward();
    }

    private void CheckAlive()
    {
        isAlive = GetComponent<DeathCheck>().getIsAlive();
    }

    private void ToggleMoveForward()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            moveForward = !moveForward;
        }
    }

    private void MoveForward()
    {
        if(moveForward)
        {
            rb.velocity = new Vector2(forwardSpeed,rb.velocity.y);
        }else
        {
            rb.velocity = new Vector2(0,rb.velocity.y);
        }
    }
}
