using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatoFantasmasController :MonoBehaviour{

	public float maxSpeed = 10f;
	public GameObject pepino, noveloDeLa, caixa;
    GameObject novoPepino, novoNovelo, novaCaixa, MainCamera;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
		if (Input.GetButtonDown ("Fire1") && novoPepino == null) {
			novoPepino = Instantiate (pepino, transform.position, transform.rotation);
		}
        float fx = transform.position.x+Input.GetAxis("HorizontalF"), fy = transform.position.y+Input.GetAxis("VerticalF");

            transform.position += new Vector3(Input.GetAxis("HorizontalF"), Input.GetAxis("VerticalF"),0) * Time.deltaTime * maxSpeed;
	}

	void OnTriggerStay2D(Collider2D col)
	{		
		if ((col.gameObject.tag == "Carro" || col.gameObject.tag == "Pendulo" || col.gameObject.tag == "Arranhador") && Input.GetButtonDown ("Fire3")) {
			col.gameObject.GetComponent<Hazard>().Activate ();
		}
	}
}

