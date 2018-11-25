using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carro : Hazard {

	public float speed = 10f;

	public float target1, target2;

	public bool facingRight = false;

	bool activated;

	public SpriteRenderer sprite;
	int direction;

	// Use this for initialization

	void Start () {
		direction = 1;
		target1 = transform.position.x - 10f;
		target2 = transform.position.x + 10f;
	}
	
	// Update is called once per frame
	void Update () {
		if (activated) {
			float step = speed * Time.deltaTime;
			if (transform.position.x > target1 && direction == 1) {
				transform.position -= new Vector3 (step, 0, 0);
			} else if (transform.position.x < target2 && direction == 2) {
				transform.position += new Vector3 (step, 0, 0);
			}

			if (direction == 1 && transform.position.x < target1)
				direction = 2;
			else if (direction == 2 && transform.position.x > target2)
				direction = 1;

			if (direction == 2 && !facingRight) {
				facingRight = !facingRight;
				sprite.flipX = true;
			} else if (direction == 1 && facingRight) {
				facingRight = !facingRight;
				sprite.flipX = false;
			}
		}
	
	}

	public override void Activate(){
		Debug.Log ("oi");
		activated = true;
	}


}
