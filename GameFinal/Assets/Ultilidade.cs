using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ultilidade : MonoBehaviour {

	private bool intrigger = false;
	private bool go_crono = false;
	private DateTime t_inicio;
	private TimeSpan t_result;
	public int tipo_acao = 0;
	public int tempo_acao = 3;
	public Lanterna_Logic lanternaMain;
	public Tocha tocha;
	public Ritual ritual;

	private int COLETAR_LANTERNA = 1;
	private int COLETAR_MACA = 2;
	private int COLETAR_PILHA = 2;
	private int COLETAR_AGUA = 2;
	private int COLETAR_ESQUEIRO = 3;

	private int ACENDER_VELA1 = 4;
	private int ACENDER_VELA2 = 5;
	private int ACENDER_VELA3 = 6;
	private int ACENDER_VELA4 = 7;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(go_crono)
			TriploView ();
	}

	void Desaparecer(){
		gameObject.SetActive (false);
	}

	void Aparecer(){
		gameObject.SetActive (true);
	}

	public void Acao(int a){
		switch (a) {
			case 2:
				Desaparecer ();
				break;
			case 1:
				lanternaMain.Ligar ();
				tocha.Apagar ();
				PegarLanterna ();
				break;
			case 3:
				Esqueiro ();
				break;
			case 4:
				if(lanternaMain.esqueiroActive)
					ritual.AcenderVela (0);
				break;
			case 5:
				if(lanternaMain.esqueiroActive)
					ritual.AcenderVela (1);
				break;
			case 6:
				if(lanternaMain.esqueiroActive)
					ritual.AcenderVela (2);
				break;
			case 7:
				if(lanternaMain.esqueiroActive)
					ritual.AcenderVela (3);
				break;
			default:
				break;
		}
	}

	private void TriploView() {
		// conteudo
		if (!intrigger) {
			intrigger = true;
			t_inicio = DateTime.Now;
		} else {
			t_result = DateTime.Now.Subtract(t_inicio);
			int seegundos = (int) t_result.TotalSeconds;
			if (seegundos < tempo_acao) {
				Debug.Log (t_result.TotalSeconds.ToString ());
			} else {
				Limpar ();
				//Click();
				//codigo para acao que sera executtada
				Acao(tipo_acao);
				return;
			}
		}

	}

	public void Enter() {
		Imprimi ("Enter");
		go_crono = true;
	}


	public void Exit() {
		Imprimi ("Exit");
		Limpar ();
	}

	public void PegarLanterna() {
		Desaparecer ();
	}

	private void Limpar() {
		intrigger = false;
		go_crono = false;
	}

	public void Imprimi(string s){
		Debug.Log (s);
	}

	public void Esqueiro(){
		lanternaMain.PegarEsqueiro ();
		Desaparecer ();
	}

}
