using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killing : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Follower")
            other.gameObject.GetComponent<DeathCheck>().isAlive = false; //This would trigger the death sequence inside follower
    }
}