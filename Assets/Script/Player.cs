using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	GameObject Spawn;
	public int jumlahBullet;
	public float MoveSpeed;
	public GameObject Food, bullet, skor, Hp;

	// Use this for initialization
	void Start () {
		Hp.GetComponent<skor> ().score = 100;
		if (Time.timeScale == 1) {
			jumlahBullet = 0;
		}
		Spawn = GameObject.Find ("spawn");
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector2.MoveTowards (transform.position, Camera.main.ScreenToWorldPoint (Input.mousePosition), MoveSpeed * Time.deltaTime);

		if (Input.GetMouseButtonDown (0)) {
			if (jumlahBullet > 0) {
				Instantiate (bullet, transform.position, Quaternion.identity);
				jumlahBullet--;
				skor.GetComponent<skor> ().score--;
			}	
		}

		if ( Hp.GetComponent<skor> ().score <= 0) {
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "food") {
			jumlahBullet++;
			skor.GetComponent<skor> ().score++;
			Spawn.GetComponent<ResourcesCopy> ().Value--;
		}

		if (other.gameObject.tag == "racun") {
			Hp.GetComponent<skor> ().score = Hp.GetComponent<skor> ().score - 10;
		}

		if (other.gameObject.tag == "enemy") {
			Hp.GetComponent<skor> ().score--;
		}

		if (other.gameObject.tag == "peluruenemy") {
			Hp.GetComponent<skor> ().score--;
			if (Hp.GetComponent<skor> ().score <= 0) {
				Destroy (gameObject);

			}
		}
	}
}
