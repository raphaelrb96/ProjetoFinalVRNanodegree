using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanterna_Logic : MonoBehaviour {

	public Light luzLant;
	public GameObject lant;
	public bool esqueiroActive = false;
	public bool chave1 = false;
	public bool chaveMain = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Ligar() {
		lant.SetActive (true);
	}

	public void Desligar() {
		lant.SetActive (false);
	}

	public void AumentarLuz(float x) {
		luzLant.intensity = x;
	}

	public void Potencia1(){
		AumentarLuz (3.2f);
	}

	public void Potencia2(){
		AumentarLuz (4.2f);
	}

	public bool EstaLigada(){
		return lant.activeSelf;
	}

	public bool GetEsqueiroActv(){
		return esqueiroActive;
	}

	public void PegarEsqueiro(){
		esqueiroActive = true;
	}

}
