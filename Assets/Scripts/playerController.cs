using UnityEngine;

public class playerController : MonoBehaviour {

    //movement variables
    public float runSpeed;
    public float walkSpeed;

    Rigidbody rb;
    Animator animator;

    bool facingRight;

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
        float move = Input.GetAxis("Horizontal");
        animator.SetFloat("speed", Mathf.Abs(move));

        float sneak = Input.GetAxisRaw("Fire3");
        animator.SetFloat("sneak", sneak);


        if (sneak > 0)
        {
            rb.velocity = new Vector3(move * walkSpeed, rb.velocity.y, 0f);
        }
        else
        {
            rb.velocity = new Vector3(move * runSpeed, rb.velocity.y, 0f);
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
}
