using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arranhador : Hazard {

    public float speed = 10f; 
	public bool interactable;

	bool activated;
	int direction;
    public float target1;

    public float target2;

	// Use this for initialization
	void Start () {
		direction = 1;
        
    }
	
	// Update is called once per frame
	void Update () {

		if (activated && interactable) {
			float step = speed * Time.deltaTime;
			if (transform.position.y < target1 && direction == 1) {
				transform.position += new Vector3 (0, step, 0);
			} else if (transform.position.y > target2 && direction == 2) {
				transform.position -= new Vector3 (0, step, 0);
			}

			if (direction == 1 && transform.position.y > target1)
				direction = 2;
			else if (direction == 2 && transform.position.y < target2)
				direction = 1;

		}
		
	}

	public override void Activate(){
        
		activated = true;
	}
}
