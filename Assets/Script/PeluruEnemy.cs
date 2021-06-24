using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeluruEnemy : MonoBehaviour {
	Transform PlayerBiru;
	Vector3 dir;
	// Use this for initialization
	void Start () {
		PlayerBiru = GameObject.Find ("PlayerBiru").transform;
		dir = Camera.main.ScreenToWorldPoint (PlayerBiru.position);
	}

	// Update is called once per frame
	void Update () {

		transform.position = Vector2.MoveTowards (transform.position, dir, 20 * Time.deltaTime);
		if (Vector2.Distance (transform.position, dir) <= 0) {
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "player") {
			Destroy (gameObject);
		}
	}

}
