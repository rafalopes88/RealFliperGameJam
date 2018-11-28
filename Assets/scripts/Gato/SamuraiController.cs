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
	public bool distracted, damaged;
	public SpriteRenderer sprite;
	public float carCrash = 10f;
    
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

		if (!distracted && !damaged) {
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
		if (damaged) {
			sprite.enabled = !sprite.enabled;
		} 
		else {
			sprite.enabled = true;
		}

		if((grounded || escalando) && Input.GetButtonDown("Jump") && !distracted && !damaged)
        {
            anim.SetBool("ground", false);
            rb.AddForce(new Vector2(0,jumpForce));
        }
		if (escalando  && Input.GetButton ("Horizontal") && !distracted && !damaged) {
			anim.SetBool ("escalando", true);
		} else {
			anim.SetBool ("escalando", false);
		}
    }

	void OnTriggerEnter2D(Collider2D col)
	{

		if (!damaged && !distracted) {
			if (col.gameObject.tag == "Pepino") {
				distracted = true;
				anim.SetBool ("distracted", true);
				StartCoroutine (SaiDoSusto ());
			} else if (col.gameObject.tag == "Pendulo") {
				damaged = true;
				anim.SetBool ("damaged", true);
				StartCoroutine (SaiDoSusto ());
			} else if (col.gameObject.tag == "Carro") {
				damaged = true;
				anim.SetBool ("damaged", true);
				rb.AddForce (new Vector2 (carCrash / 2, carCrash));
				StartCoroutine (SaiDoSusto ());
			}
		}
	}

	IEnumerator SaiDoSusto()
	{

		yield return new WaitForSeconds(3);
		distracted = false ;
		damaged = false ;
		anim.SetBool("distracted", false );
		anim.SetBool("damaged", false );
	}

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


}
