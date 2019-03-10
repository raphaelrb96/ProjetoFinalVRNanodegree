using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Key : MonoBehaviour {

	// TODO: Create variables to reference the game objects we need access to
	public float velocidade = 60.1f;
	// Declare a GameObject named 'keyPoofPrefab' and assign the 'KeyPoof' prefab to the field in Unity
	public GameObject keyPoofPrefab;


	private int segundos = 0;

	private bool dentro = false;
	private DateTime t_inicio;
	private TimeSpan t_result;


	void Update () {
		// OPTIONAL-CHALLENGE: Animate the coin rotating
		transform.Rotate (Vector3.up, Time.deltaTime * velocidade, Space.World);
		// TIP: You could use a method from the Transform class
		if (dentro) {
			Focado ();
		}
	}


	public void OnKeyClicked () {
		/// Called when the 'Key' game object is clicked
		/// - Unlocks the door (handled by the Door class)
		/// - Displays a poof effect (handled by the 'KeyPoof' prefab)
		/// - Plays an audio clip (handled by the 'KeyPoof' prefab)
		/// - Removes the key from the scene

		// Prints to the console when the method is called
		//Debug.Log ("'Key.OnKeyClicked()' was called");

		// TODO: Unlock the door, display the poof effect, and remove the key from the scene
		// Use 'door' to call the Door.Unlock() method
		// Use Instantiate() to create a clone of the 'KeyPoof' prefab at this coin's position and with the 'KeyPoof' prefab's rotation
		Instantiate(keyPoofPrefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
		// Use Destroy() to delete the key after for example 0.5 seconds
		Destroy(gameObject, .2f);
	}

	private void Focado() {
		//quando o lase (cursor) fica mirado na moeda
		t_result = DateTime.Now.Subtract(t_inicio);
		segundos = (int) t_result.TotalSeconds;
		if (segundos < 7) {
			//Debug.Log (t_result.TotalSeconds.ToString ());
		} else {
			OnKeyClicked ();
		}
	}

	public void Enter() {
		dentro = true;
		t_inicio = DateTime.Now;
	}

	public void Exit() {
		dentro = false;
		//t_inicio = 0f;
	}

}
