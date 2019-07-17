using UnityEngine;

public class weaponPickupController : MonoBehaviour {

    public int whichWeapon;
    public AudioClip pickUpClip;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.gameObject.GetComponent<inventoryManager>().activateWeapon(whichWeapon);
            Destroy(transform.root.gameObject);
            AudioSource.PlayClipAtPoint(pickUpClip, transform.position);
        }
    }
}
