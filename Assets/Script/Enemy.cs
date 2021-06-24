using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	Vector2 randomPoint;
	float randomX, randomY;
	int Hp = 5;
	public int peluru;
	public GameObject bullet;
	GameObject PlayerBiru, Spawn, Skor;
	Transform PlayerAi, EnemyAi;
	public float speed = 4;
	public float StoppingArea = 3;
	public float Area = 5;
	Rigidbody2D rb2d;


	// Use this for initialization
	void Start () {
		PlayerBiru = GameObject.Find ("PlayerBiru");
		Spawn = GameObject.Find ("spawn");
		Skor = GameObject.Find ("Score");
		PlayerAi = PlayerBiru.transform;

		FirstPosition ();
	}
	
	// Update is called once per frame
	void Update () {
		EnemyMoveRandom ();

		if (Hp < 1) {
			Destroy (gameObject);
			Spawn.GetComponent<ResourcesCopy> ().EnemyValue--;
			Skor.GetComponent<skor> ().score = Skor.GetComponent<skor> ().score + 10;
			PlayerBiru.GetComponent<Player> ().jumlahBullet = PlayerBiru.GetComponent<Player> ().jumlahBullet + 10;
		}

	}

	void EnemyMoveRandom() {
		randomPoint = new Vector2 (randomX, randomY);

		if (Vector2.Distance (transform.position, randomPoint) <= 0) {
			randomX = Random.Range (-25, 25);
			randomY = Random.Range (-14, 14);
		}

		float destince = Vector2.Distance (transform.position, PlayerAi.position);

		if (destince <= Area) {
			transform.position = Vector2.MoveTowards (transform.position, PlayerAi.position, speed * Time.deltaTime);
			if (peluru >= 0) {
				Instantiate (bullet, transform.position, Quaternion.identity);
				peluru--;
			}
		} 

		if (destince >= StoppingArea) {
			transform.position = Vector2.MoveTowards (transform.position, randomPoint, speed * Time.deltaTime);
		}
			
	}

	void FirstPosition(){
		randomX = Random.Range (-25, 25);
		randomY = Random.Range (-14, 14);
		transform.position = new Vector2 (randomX, randomY);	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "peluru") {
			Hp--;
		}

		if (other.gameObject.tag == "racun") {
			peluru++;
			Spawn.GetComponent<ResourcesCopy> ().Value--;
		}

		if (other.gameObject.tag == "MainCamera") {
			
		}
	}
}
