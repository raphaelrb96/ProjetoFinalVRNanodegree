using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ritual : MonoBehaviour {

	public GameObject[] fogos;
	public bool tudoOk = false;

	public GameObject pointKey;
	public GameObject key;
	public GameObject keyEfect;

	private DateTime t_inicio;
	private TimeSpan t_result;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (tudoOk) {
			t_result = DateTime.Now.Subtract(t_inicio);
			int seegundos = (int) t_result.TotalSeconds;
			if (seegundos < 4) {
				Debug.Log (t_result.TotalSeconds.ToString ());
			} else {
				tudoOk = false;
				//Click();
				//codigo para acao que sera executtada
				ComecarRitual();
			}
		}
	}

	public void AcenderVela(int x) {
		GameObject obj = fogos [x];
		obj.SetActive (true);
		if (TodasAcesas ()) {
			tudoOk = true;
			t_inicio = DateTime.Now;
		}
	}

	public bool TodasAcesas(){
		for (int i = 0; i < 4; i++) {
			if (!fogos [i].activeSelf) {
				return false;
			}
		}
		return true;
	}

	public void ComecarRitual() {
		Instantiate(keyEfect, new Vector3(pointKey.transform.position.x, pointKey.transform.position.y, pointKey.transform.position.z), Quaternion.identity);
		Instantiate(key, new Vector3(pointKey.transform.position.x, pointKey.transform.position.y, pointKey.transform.position.z), Quaternion.identity);
	}

}
