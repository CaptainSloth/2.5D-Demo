using UnityEngine;

public class playerHealth : MonoBehaviour {

    public float fullHealth;
    float currentHealth;

    public GameObject playerDeathFX;
     
    
	void Start () {
        currentHealth = fullHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addDamage(float damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            makeDed();
        }
    }

    public void makeDed()
    {
        Instantiate(playerDeathFX, transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
        Destroy(gameObject);
    }

}
