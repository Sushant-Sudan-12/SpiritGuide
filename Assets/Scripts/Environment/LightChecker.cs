using UnityEngine;

public class LightChecker : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Follower"){
            other.gameObject.GetComponent<DeathCheck>().isInStreetLight = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Follower"){
            other.gameObject.GetComponent<DeathCheck>().isInStreetLight = false;
        }
    }
}
