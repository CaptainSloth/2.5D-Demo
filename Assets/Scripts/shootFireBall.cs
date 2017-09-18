using UnityEngine;

public class shootFireBall : MonoBehaviour {

    public float damage;
    public float speed;

    Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponentInParent<Rigidbody>();

        if (transform.rotation.y > 0) rb.AddForce(Vector3.right * speed, ForceMode.Impulse);
        else rb.AddForce(Vector3.right * -speed, ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" ||  other.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {
            rb.velocity = Vector3.zero;
            enemyHealth _enemyHealth = other.GetComponent<enemyHealth>();
            
            if(_enemyHealth != null)
            {
                _enemyHealth.addDamage(damage);
                _enemyHealth.addFire();
            }

            Destroy(gameObject);
        }
    }
}
