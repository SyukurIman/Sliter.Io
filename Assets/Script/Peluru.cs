using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peluru : MonoBehaviour {
	Vector3 dir;
	// Use this for initialization
	void Start () {
		dir = Camera.main.ScreenToWorldPoint (Input.mousePosition);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector2.MoveTowards (transform.position, dir, 20 * Time.deltaTime);
		if (Vector2.Distance (transform.position, dir) <= 0) {
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "enemy") {
			Destroy (gameObject);
		}
	}

}
