using UnityEngine;

public class melee : MonoBehaviour {

    public float damage;
    public float knockBack;
    public float knockBackRadius;
    public float meleeRate;

    float nextMelee;

    int shootableMask;

    Animator animator;
    playerController _playerControl;

	// Use this for initialization
	void Start () {
        shootableMask = LayerMask.GetMask("Shootable");
        animator = transform.root.GetComponent<Animator>();
        _playerControl = transform.root.GetComponent<playerController>();
        nextMelee = 0f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float melee = Input.GetAxis("Fire2");

        if (melee > 0 && nextMelee < Time.time && !(_playerControl.getRunning()))
        {
            animator.SetTrigger("gunMelee");
            nextMelee = Time.time + meleeRate;

            //do Damage
            Collider[] attacked = Physics.OverlapSphere(transform.position, knockBackRadius, shootableMask);

            int i = 0;
            while(i< attacked.Length)
            {
                if (attacked[i].tag == "Enemy")
                {
                    enemyHealth doDamage = attacked[i].GetComponent<enemyHealth>();
                    doDamage.addDamage(damage);
                    doDamage.damageFX(transform.position, transform.localEulerAngles);
                }
            }
            i++;
        }
	}
}
