using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeletonmove : MonoBehaviour
{
    private Rigidbody2D mybody;
    private Animator anim;

    public float speed = 5f;
    public Transform front_check;
    public Transform back_check,attack_check;
    private Vector3 left_collision_pos,right_collision_pos;
    public LayerMask groundLayer;
    public LayerMask playerLayer;
    private int i = 1;

    void Awake(){
        mybody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); 

        left_collision_pos = back_check.localPosition;      
        right_collision_pos = attack_check.localPosition;

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        attackCheck();
        if (!Physics2D.Raycast(front_check.position,Vector2.down,0.5f,groundLayer)){
            ChangeDirection();
        }
    }

    void FixedUpdate(){
        moveEnemy();
    }

    void attackCheck(){
        RaycastHit2D infront = Physics2D.Raycast(attack_check.position,Vector2.right,0.1f,playerLayer); 
        RaycastHit2D inback = Physics2D.Raycast(back_check.position,Vector2.left,0.1f,playerLayer);
        if(infront || inback){
            if(infront.collider.gameObject.tag == "Follower" ){
                anim.Play("Attack");
            }else if(infront.collider.gameObject.tag == "Spirit" ){
                anim.Play("Move");
            }
        }
    }

    public void gameEnd(){
        Time.timeScale = 0;
    }

    void moveEnemy(){
        if(i==1){
            mybody.velocity = new Vector2(speed,mybody.velocity.y);
        }
        else{
            mybody.velocity = new Vector2(-speed,mybody.velocity.y);
        }
    }

    void ChangeDirection(){
        Vector3 tempScale = transform.localScale ;
        if (i!=1){
            tempScale.x = Mathf.Abs(tempScale.x);

            back_check.localPosition = left_collision_pos;
            attack_check.localPosition = right_collision_pos;

        }
        else{
            tempScale.x = -Mathf.Abs(tempScale.x); 

            back_check.localPosition = right_collision_pos;
            attack_check.localPosition = left_collision_pos;
        }
        transform.localScale = tempScale ;
        i*=-1;
    }
}
