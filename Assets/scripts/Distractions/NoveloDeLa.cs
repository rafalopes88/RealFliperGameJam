using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoveloDeLa : Distraction {

	Rigidbody2D rb;
	public float forces;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		rb.AddForce (Vector3.up * forces);
		rb.AddTorque(forces);
		Apagar ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
