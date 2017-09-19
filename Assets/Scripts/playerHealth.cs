using UnityEngine;
using UnityEngine.UI;


//TO ADD
//DAMAGESCREEN FLASH WHEN PLAYER HEALTH LOW

public class playerHealth : MonoBehaviour {

    public float fullHealth;
    float currentHealth;

    public GameObject playerDeathFX;

    //HUD
    public Slider playerHealthSlider;
    public Image damageScreen;
    Color flashColor = new Color(255f, 255f, 255f, 1f);
    float flashSpeed = 5f;
    bool damaged = false;
    public Text endGameDedText;
    public restartGame MCP;


    AudioSource playerAudioSource;
    
	void Awake () {
        currentHealth = fullHealth;
        playerHealthSlider.maxValue = fullHealth;
        playerHealthSlider.value = currentHealth;
        playerAudioSource = GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update () {
        //we hurt?
        if (damaged)
        {
            damageScreen.color = flashColor;
        }
        else
        {
            damageScreen.color = Color.Lerp(damageScreen.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
	}

    public void addDamage(float damage)
    {
        currentHealth -= damage;
        playerHealthSlider.value = currentHealth;
        damaged = true;

        playerAudioSource.Play();

        if (currentHealth <= 0)
        {
            makeDed();
        }
    }

    public void addHealth(float health)
    {
        currentHealth += health;
        if (currentHealth > fullHealth) currentHealth = fullHealth;
        playerHealthSlider.value = currentHealth;
    }

    public void makeDed()
    {
        Instantiate(playerDeathFX, transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
        damageScreen.color = flashColor;
        Destroy(gameObject);
        Animator endGameAnimation = endGameDedText.GetComponent<Animator>();
        endGameAnimation.SetTrigger("endGame");
        MCP.restartTheGame();
    }

}
