using UnityEngine;

public class eraser : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerHealth playerFall = other.gameObject.GetComponent<playerHealth>();
            playerFall.makeDed();
        }
        else Destroy(gameObject);
    }
}
