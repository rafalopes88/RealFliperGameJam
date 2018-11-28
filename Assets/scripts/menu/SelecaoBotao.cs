using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelecaoBotao : MonoBehaviour {

    public List<Button> botoes;
    public RectTransform selecaoBotao;
    private int listIndex = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Vertical"))
        {
            if (Input.GetAxis("Vertical") < 0)
            {
                if (listIndex < botoes.Count - 1)
                {
                    listIndex++;
                }
                else
                {
                    listIndex = 0;
                }
            }
            else if (Input.GetButtonDown("Vertical"))
            {
                if (listIndex > 0)
                {
                    listIndex--;
                }
                else
                {
                    listIndex = botoes.Count - 1;
                }
            }
        }
        selecaoBotao.localPosition = botoes[listIndex].GetComponent<RectTransform>().localPosition;
        if(Input.GetButtonDown("Jump")){
            botoes[listIndex].onClick.Invoke();
        }
	}
}
