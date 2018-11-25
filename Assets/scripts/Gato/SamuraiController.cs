using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamuraiController : MonoBehaviour {
    
    public float maxSpeed = 10f;
    public bool facingRight = true;
    Rigidbody2D rb;
    public Animator anim;

    bool grounded, escalando;
    public Transform groundCheck;
    public float radius = 1f;
	public LayerMask whatIsGround, whatIsArrandor;
    public float jumpForce = 7000f;
    public float run = 2f;
	public bool distracted;
    
	public float targetPosition;

    // Use this for initialization
    void Awake () {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        grounded = Physics2D.OverlapCircle(groundCheck.position, radius, whatIsGround);
		escalando = Physics2D.OverlapCircle(groundCheck.position, radius, whatIsArrandor);


        anim.SetBool("ground", grounded);
        anim.SetFloat("vSpeed", rb.velocity.y);

        float move;

		if (!distracted) {
			move = Input.GetAxis ("Horizontal");
			anim.SetFloat("speed", Mathf.Abs(move));
			rb.velocity = new Vector2(move * maxSpeed, rb.velocity.y);

			if (move > 0 && !facingRight)
				Flip();
			else if(move < 0 && facingRight)
				Flip();
		}
    }

    void Update()
    {
		if((grounded || escalando) && Input.GetButtonDown("Jump") && !distracted)
        {
            anim.SetBool("ground", false);
            rb.AddForce(new Vector2(0,jumpForce));
        }
    }

	void OnTriggerEnter2D(Collider2D col)
	{
		distracted = true;
		anim.SetBool("distracted", true );
		StartCoroutine (SaiDoSusto());
	}

	IEnumerator SaiDoSusto()
	{

		yield return new WaitForSeconds(3);
		distracted = false ;
		anim.SetBool("distracted", false );
	}

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
