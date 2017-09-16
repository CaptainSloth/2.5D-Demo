using UnityEngine;

public class enemyDamage : MonoBehaviour {

    public float damage;
    public float damageRate;
    public float pushBackForce;

    float nextDamage;

    bool playerInRange = false;

    GameObject player;
    playerHealth _playerHealth;

	// Use this for initialization
	void Start () {
        nextDamage = Time.deltaTime;
        player = GameObject.FindWithTag("Player");
        _playerHealth = player.GetComponent<playerHealth>();
	}
	
	// Update is called once per frame
	void Update () {
        if (playerInRange) Attack();
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerInRange = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            playerInRange = false;
        }
    }

    void Attack()
    {
        if (nextDamage <= Time.time)
        {
            _playerHealth.addDamage(damage);
            nextDamage = Time.time + damageRate;

            pushBack(player.transform);
        }
    }

    void pushBack(Transform pushedObject)
    {
        Vector3 pushDir = new Vector3(0, (pushedObject.position.y - transform.position.y), 0).normalized;
        pushDir *= pushBackForce;

        Rigidbody pushedRB = pushedObject.GetComponent<Rigidbody>();
        pushedRB.velocity = Vector3.zero;
        pushedRB.AddForce(pushDir, ForceMode.Impulse);
    }
}
