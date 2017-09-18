using UnityEngine;
using UnityEngine.UI;

public class fireBullet : MonoBehaviour {

    public float timeBetweenBullets = 0.15f;
    public GameObject projectile;

    //Bullet info
    public Slider playerAmmoSlider;
    public int maxRounds;
    public int startRounds;
    int remainingRounds;
    
    float nextBullet;

    //audio info
    AudioSource gunAudioSource;
    public AudioClip shootSound;
    public AudioClip reloadSound;

	// Use this for initialization
	void Awake () {
        nextBullet = 0f;
        remainingRounds = startRounds;
        playerAmmoSlider.maxValue = maxRounds;
        playerAmmoSlider.value = remainingRounds;
        gunAudioSource = GetComponent<AudioSource>();
        Debug.Log("Pew");
	}
	
    void playShootSound(AudioClip _playShootSound)
    {
        gunAudioSource.clip = _playShootSound;
        gunAudioSource.Play();
    }

	// Update is called once per frame
	void Update () {
        playerController player = transform.root.GetComponent<playerController>();

        if (Input.GetAxisRaw("Fire1") > 0 && nextBullet < Time.time && remainingRounds>0)
        {
            nextBullet = Time.time + timeBetweenBullets;
            Vector3 rot;
            if (player.GetFacing() == -1f)
            {
                rot = new Vector3(0, -90, 0);
            }
            else rot = new Vector3(0, 90, 0);

            //Calls bullet
            Instantiate(projectile, transform.position, Quaternion.Euler(rot));

            playShootSound(shootSound);

            remainingRounds -= 1;
            playerAmmoSlider.value = remainingRounds;
        }
        
	}

    public void reload()
    {
        remainingRounds = maxRounds;
        playerAmmoSlider.value = remainingRounds;
        playShootSound(reloadSound);
    }
}
