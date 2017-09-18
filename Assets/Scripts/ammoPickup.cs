using UnityEngine;

public class ammoPickup : MonoBehaviour {

    public float ammoAmount;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponentInChildren<fireBullet>().reload();
            Destroy(transform.root.gameObject);
        }
    }
}
