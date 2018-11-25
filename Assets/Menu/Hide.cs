using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hide : MonoBehaviour {
	
	public GameObject painelCreditos;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Play()
    {
        SceneManager.LoadScene("mainScene 1");
    }
	public void Aparece(){
		gameObject.SetActive(true);
		painelCreditos.SetActive(false);	
	}

	public void Esconde(){
		gameObject.SetActive(false);
		painelCreditos.SetActive(true);
	}
}
