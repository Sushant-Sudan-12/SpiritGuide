using UnityEngine;
public class SpiritTrigger : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject lightObject;
    [SerializeField] bool initialLightStatus;
    private void Start()
    {
        lightObject = transform.parent.GetChild(0).gameObject;
        lightObject.SetActive(initialLightStatus);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.transform.parent.gameObject.tag == "Spirit"){
            lightObject.SetActive(true);
        }
    }
}
