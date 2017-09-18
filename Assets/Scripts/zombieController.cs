using UnityEngine;

public class zombieController : MonoBehaviour {

    public GameObject flipModel;

    //Audio Options
    public AudioClip[] idleSounds;
    public float idleSoundsTime;
    AudioSource enemyMovementAudioSource;
    float nextIdleSound = 0f;

    public float detectionTime;
    float startRun;
    bool firstDetection;

    //movement option
    public float runSpeed;
    public float walkSpeed;
    public bool facingRight = true;

    float moveSpeed;
    bool running;

    Rigidbody rb;
    Animator animator;
    Transform detectedPlayer;

    bool detected;

	// Use this for initialization
	void Start () {
        rb = GetComponentInParent<Rigidbody>();
        animator = GetComponentInParent<Animator>();
        enemyMovementAudioSource = GetComponent<AudioSource>();

        running = false;
        detected = false;
        firstDetection = false;
        moveSpeed = walkSpeed;

        if (Random.Range(0, 10) > 5) Flip();

	}

	void FixedUpdate () {
        if (detected)
        {
            if(detectedPlayer.position.x < transform.position.x && facingRight) Flip();
            else if (detectedPlayer.position.x > transform.position.x && !facingRight) Flip();

            if (!firstDetection)
            {
                startRun = Time.time + detectionTime;
                firstDetection = true;
            }
        }
        if (detected && !facingRight) rb.velocity = new Vector3((moveSpeed * -1), rb.velocity.y, 0);
        else if (detected && facingRight) rb.velocity = new Vector3(moveSpeed, rb.velocity.y, 0);

        if(!running && detected)
        {
            if (startRun < Time.time){
                moveSpeed = runSpeed;
                animator.SetTrigger("run");
                running = true;
            }
        }

        //idle or walking sounds
        if (!running)
        {
            if(Random.Range(0,10) > 5 && nextIdleSound < Time.time)
            {
                AudioClip tempClip = idleSounds[Random.Range(0, idleSounds.Length)];
                enemyMovementAudioSource.clip = tempClip;
                enemyMovementAudioSource.Play();
                nextIdleSound = idleSoundsTime + Time.time;
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !detected)
        {
            detected = true;
            detectedPlayer = other.transform;
            animator.SetBool("detected", detected);
            if (detectedPlayer.position.x < transform.position.x && facingRight) Flip();
            else if (detectedPlayer.position.x > transform.position.x && !facingRight) Flip();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            firstDetection = false;
            if (running)
            {
                animator.SetTrigger("run");
                moveSpeed = walkSpeed;
                running = false;
            }
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = flipModel.transform.localScale;
        theScale.z *= -1;
        flipModel.transform.localScale = theScale;
    }

}
