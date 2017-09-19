using UnityEngine;

public class playerController : MonoBehaviour {

    //movement variables
    public float runSpeed;
    public float walkSpeed;
    bool running;

    Rigidbody rb;
    Animator animator;

    bool facingRight;

    //for jumping
    bool grounded = false;
    Collider[] groundCollisions;
    float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHeight;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        facingRight = true;
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void FixedUpdate()
    {
        running = false;

        if(grounded && Input.GetAxis("Jump") > 0)
        {
            grounded = false;
            animator.SetBool("grounded", grounded);
            rb.velocity = new Vector3(rb.velocity.x, 0, 0);
            rb.AddForce(new Vector3(0, jumpHeight, 0));
        }
        //Ground Check
        groundCollisions = Physics.OverlapSphere(groundCheck.position, groundCheckRadius, groundLayer);
        if (groundCollisions.Length > 0) grounded = true;
        else grounded = false;

        animator.SetBool("grounded", grounded);

        //jumping
        animator.SetFloat("vertSpeed", rb.velocity.y);

        float move = Input.GetAxis("Horizontal");
        animator.SetFloat("speed", Mathf.Abs(move));

        float sneak = Input.GetAxisRaw("Fire3");
        animator.SetFloat("sneak", sneak);

        float firing = Input.GetAxisRaw("Fire1");
        animator.SetFloat("shooting", firing);

        if ((sneak > 0 || firing>0) && grounded)
        {
           rb.velocity = new Vector3(move * walkSpeed, rb.velocity.y, 0f);
        }
        else
        {
            rb.velocity = new Vector3(move * runSpeed, rb.velocity.y, 0f);
            if (Mathf.Abs(move)>0) running = true;
        }
        
        

        if (move > 0 && !facingRight) Flip();
        else if (move < 0 && facingRight) Flip();
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.z *= -1;
        transform.localScale = scale;
    }

    public float GetFacing()
    {
        if (facingRight) return 1;
        else return -1;
    }

    public bool getRunning()
    {
        return running;
    }




}
