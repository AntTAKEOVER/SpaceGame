using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject Enemy1;
	public float speed;
	public float width = 10f;
	public float height = 10f;
	public float tilt = 35f;
	public float spawnDelay = 0.5f;
	public float movementTime = 0.08f;
	//public float rotateTime = 0.05f;
	public GameObject dampner;
	float boundaryLeft;
	float boundaryRight;
	//public bool shootCan;
	// Use this for initialization

	void getBoundary(){
		boundaryLeft = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, 0)).x + width/2;
		boundaryRight = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, 0)).x - width/2;
	}
		
	void Start () {
		dampner = GameObject.Find ("DampnerForEnemyFormation");
		OnlySpawnFull ();
		getBoundary ();

	}

	public void OnDrawGizmos(){
		Gizmos.DrawWireCube(transform.position, new Vector3(width, 0, height));
	}

	// Update is called once per frame
	void Update () {
		if (dampner.transform.position.x <= boundaryLeft) {
			if (speed >= 0) {
				return;
			} else {
				speed = -speed;
			}
		}
		if (dampner.transform.position.x >= boundaryRight) {
			if (speed <= 0) {
				return;
			} else {
				speed = -speed;
			}
		}
		dampner.transform.position += new Vector3 (speed * Time.deltaTime, 0, 0);
		transform.position = new Vector3 (Mathf.Lerp (transform.position.x, dampner.transform.position.x, movementTime), transform.position.y, transform.position.z);

		if (AllEnemiesDead ()) {
			FindObjectOfType<WaveManager> ().spawnEnemies ();
		}
		//Debug.LogWarning (AllEnemiesDead());
		//	Debug.Log ("Spawn New Wave");
		//	OnlySpawnFull();
		

		
	}

	Transform nextFreePos(){
		foreach (Transform enemyGameoBject in transform) {
			if (enemyGameoBject.childCount == 0) {
				return enemyGameoBject;
			}
		}
		return null;
	}
		

	public bool AllEnemiesDead(){
		foreach (Transform enemyTransformGameObject in transform) {
			if (enemyTransformGameObject.childCount > 0) {
				return false;
			}
		}
		return true;
	}



	/*public void spawnEnemies(){
		foreach (Transform child in transform) {
			GameObject enemy = Instantiate (Enemy1, child.transform.position, this.transform.rotation) as GameObject;
			enemy.transform.parent = child;
		}
	} */

	void OnlySpawnFull(){
		Transform FreePos = nextFreePos ();
		if (FreePos != null) {
			//Debug.Log (FreePos.transform.position);
			GameObject enemy = Instantiate (Enemy1, FreePos.transform.position, FreePos.transform.rotation) as GameObject;
			enemy.transform.parent = FreePos;
			getBoundary ();
		}

		if(nextFreePos()){
		Invoke ("OnlySpawnFull", spawnDelay);
		} 
	}



}
