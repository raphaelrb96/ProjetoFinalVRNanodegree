using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PortaoGrade : MonoBehaviour {

	private float inicio = 11.69f;
	private float final = 16.0f;
	private bool aberto = false;
	public GameObject[] gameobj;

	private bool intrigger = false;
	private bool go_crono = false;
	private DateTime t_inicio;
	private TimeSpan t_result;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(go_crono)
			TriploView ();

		if (aberto) {
			if(transform.position.y < 4.29f) {
				transform.Translate (0, 2.5f * Time.deltaTime, 0, Space.World);
			}
		}
	}

	public void Abrir(){
		aberto = true;
		gameobj [0].SetActive (true);
		gameobj [1].SetActive (true);
		gameobj [2].SetActive (true);
	}

	public void Fechar(){
		aberto = false;
		gameobj [0].SetActive (false);
		gameobj [1].SetActive (false);
		gameobj [2].SetActive (false);
	}

	public void Acao(){
		if (!aberto)
			Abrir ();
	}

	private void TriploView() {
		// conteudo
		if (!intrigger) {
			intrigger = true;
			t_inicio = DateTime.Now;
		} else {
			t_result = DateTime.Now.Subtract(t_inicio);
			int seegundos = (int) t_result.TotalSeconds;
			if (seegundos < 2) {
				Debug.Log (t_result.TotalSeconds.ToString ());
			} else {
				Limpar ();
				//Click();
				//codigo para acao que sera executtada
				Acao();
				return;
			}
		}

	}

	public void Enter() {
		go_crono = true;
	}

	private void Limpar() {
		intrigger = false;
		go_crono = false;
	}

	public void Exit() {
		Limpar ();
	}


}
