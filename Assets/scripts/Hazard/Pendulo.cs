using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulo : Hazard {

	public GameObject trava;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void Activate(){
		trava.SetActive (false);
	}
}
