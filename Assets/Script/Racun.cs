using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racun : MonoBehaviour {
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "player") {
			Destroy (gameObject);
		}
		if (other.gameObject.tag == "enemy") {
			Destroy (gameObject);
		}
	}
}
