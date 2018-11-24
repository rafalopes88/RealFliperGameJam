using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatoFantasmasController :MonoBehaviour{

	public float maxSpeed = 10f;
	public GameObject pepino, noveloDeLa, caixa;
	GameObject novoPepino,novoNovelo, novaCaixa;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetButtonDown ("Fire1") && novoPepino == null) {
			novoPepino = Instantiate (pepino, transform.position, transform.rotation);
		} 
		if (Input.GetButtonDown ("Fire2") && novoNovelo == null) {
			novoNovelo = Instantiate (noveloDeLa, transform.position, transform.rotation);
		}
		if (Input.GetButtonDown ("Fire3") && novaCaixa == null) {
			novaCaixa = Instantiate (caixa, transform.position, transform.rotation);
		}

		transform.position += new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"),0) * Time.deltaTime * maxSpeed;
	}
}
