using UnityEngine;


public class healthPickup : MonoBehaviour {

    public float healthAmount;
    public AudioClip healthPickupSound;

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
            other.GetComponent<playerHealth>().addHealth(healthAmount);
            Destroy(transform.root.gameObject);
            AudioSource.PlayClipAtPoint(healthPickupSound, transform.position, 2f);
        }
    }
}


// other.GetComponentInChildren<fireBullet>().reload();