using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navegacao : MonoBehaviour {

	private GameObject waypoint;
	private Waypoint wp;

	public void AtuaizarPonto(GameObject w, Waypoint wyp) {
		if (wp != null) {
			Ocultar ();
		}
		waypoint = w;
		wp = wyp;
		Exibir ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Exibir() {

		int size = wp.waysVizinhos.Length;
		for (int i = 0; i < size; i++) {
			wp.waysVizinhos [i].SetActive (true);
		}

	}

	public void Ocultar(){
		int size = wp.waysVizinhos.Length;
		wp.vizinhosVisiveis = false;
		for (int i = 0; i < size; i++) {
			wp.waysVizinhos [i].SetActive (false);
		}
	}

}
