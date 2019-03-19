using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Tocha : MonoBehaviour {

	public GameObject luz, fogo;
	private bool apagar = false;
	private DateTime t_inicio;
	private TimeSpan t_result;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (apagar) {
			AtivarCronometro ();
		}
	}

	public void Apagar(){
		apagar = true;
		t_inicio = DateTime.Now;
	}

	void AtivarCronometro(){
		t_result = DateTime.Now.Subtract(t_inicio);
		int seegundos = (int) t_result.TotalSeconds;
		if (seegundos < 5) {
			Debug.Log (t_result.TotalSeconds.ToString ());
		} else {
			//codigo para acao que sera executtada
			fogo.SetActive(false);
			luz.SetActive(false);
			return;
		}
	}

}
