using UnityEngine;

public class NearSpirit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Follower"){
            other.gameObject.GetComponent<DeathCheck>().isNearSpirit = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Follower"){
            other.gameObject.GetComponent<DeathCheck>().isNearSpirit = false;
        }
    }
    
}
