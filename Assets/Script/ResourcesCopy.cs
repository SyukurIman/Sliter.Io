using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesCopy : MonoBehaviour {
	public GameObject[] Resources, Enemy;
	public int Value, EnemyValue;
	public float speed = 0.1f;
	float Yarea, Xarea;

	// Use this for initialization
	void Start () {
		if (Time.timeScale == 1) {
			Value = 0;
			EnemyValue = 0;
		}
		StartCoroutine (Spawner());
	}

	private void spawnFood(){
		if (Value < 100 ) {
			Xarea = Random.Range (-26, 26);
			Yarea = Random.Range (-14, 14);			
			int randFood = Random.Range (0, Resources.Length);
			transform.position = new Vector2 (Xarea, Yarea);	
			Instantiate (Resources[randFood], transform.position, transform.rotation);
			Value++;
		}
	}

	private void spawnEnemy(){
		if (EnemyValue < 10) {
			transform.position = new Vector2 (Xarea, Yarea);
			int randEnemy = Random.Range (0, Enemy.Length);		
			Instantiate (Enemy[randEnemy], transform.position, transform.rotation);
			EnemyValue++;
		}
	}

	IEnumerator Spawner(){
		while (true) {
			yield return new WaitForSeconds (speed);
			spawnFood ();
			spawnEnemy ();
		}

	}

}
