using UnityEngine;
using UnityEngine.UI;

public class enemyHealth : MonoBehaviour {

    public float enemyMaxHealth;
    public float damageModifier;
    public GameObject damageParticles;
    public bool drops;
    public GameObject drop;
    public AudioClip deathSound;
    public bool canBurn;
    public float burnDamage;
    public float burnTime;
    public GameObject burnEffects;

    bool onFire;
    float nextBurn;
    float burnInternal = 1f;
    float endBurn;

    float currentHealth;

    public Slider enemyHealthIndicator;
    AudioSource enemyAudioSource;

	// Use this for initialization
	void Awake () {
        currentHealth = enemyMaxHealth;
        enemyHealthIndicator.maxValue = enemyMaxHealth;
        enemyHealthIndicator.value = currentHealth;
        enemyAudioSource = GetComponent<AudioSource>();
		
	}
	
	// Update is called once per frame
	void Update () {
		if(onFire && Time.time > nextBurn)
        {
            addDamage(burnDamage);
            nextBurn += burnInternal;
        }
        if(onFire&& Time.time > endBurn)
        {
            onFire = false;
            burnEffects.SetActive(false);
        }
	}

    public void addDamage(float damage)
    {
        enemyHealthIndicator.gameObject.SetActive(true);
        damage = damage * damageModifier;
        if (damage <= 0f) return;
        currentHealth -= damage;
        enemyHealthIndicator.value = currentHealth;
        enemyAudioSource.Play();
        if (currentHealth <= 0) makeDed();
    }

    public void damageFX(Vector3 point, Vector3 rot)
    {
        Instantiate(damageParticles, point, Quaternion.Euler(rot));
    }

    public void addFire()
    {
        if (!canBurn) return;
        onFire = true;
        burnEffects.SetActive(true);
        endBurn = Time.time + burnTime;
        nextBurn = Time.time + burnInternal;
    }

    void makeDed()
    {
        //turn off movement
        // create ragdoll
        zombieController zombie = GetComponentInChildren<zombieController>();
        if(zombie != null)
        {
            zombie.ragdollDeath();
        }

        AudioSource.PlayClipAtPoint(deathSound, transform.position, 0.15f);

        Destroy(gameObject.transform.root.gameObject);
        //if (drops) Instantiate(drop, transform.position, transform.rotation);
        if (drops) Instantiate(drop, transform.position, Quaternion.identity);
        // Quaternion.identity (fix if drop falls wrong)
    }
}
