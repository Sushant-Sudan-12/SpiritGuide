using System.Reflection;
using UnityEditor.Callbacks;
using UnityEngine;

public class DeathCheck : MonoBehaviour
{

    [HideInInspector]public bool isInStreetLight;
    [HideInInspector]public bool isNearSpirit; 

    [HideInInspector]public bool isAlive;

    public bool getIsAlive(){
        return isAlive;
    } //getter for isAlive

    void Start()
    {
        isInStreetLight = true;
        isNearSpirit = false;
        isAlive = true;
    }

    void Update()
    {
        CheckDeath();
    }

    private void CheckDeath()
    {
        if (isAlive)
        {
            isAlive = isInStreetLight || isNearSpirit;
        }else
        {
            DeathSequence();
        }
    }

    private void DeathSequence()
    {
        gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.red;
        GetComponent<FollowerMovement>().enabled = false;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GameObject.FindGameObjectWithTag("Spirit").GetComponent<MovementSpirit>().enabled = false;
    }
}
