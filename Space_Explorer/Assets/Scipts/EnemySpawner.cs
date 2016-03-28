using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject Enemy1;
	public float speed;
	public float width = 10f;
	public float height = 10f;

	float boundaryLeft;
	float boundaryRight;
	// Use this for initialization
	void Start () {
	
		boundaryLeft = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, 0)).x + width/2;
		boundaryRight = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, 0)).x - width/2;
		foreach (Transform child in transform) {
			GameObject enemy = Instantiate (Enemy1, child.transform.position, this.transform.rotation) as GameObject;
			enemy.transform.parent = child;
		}
	}

	public void OnDrawGizmos(){
		Gizmos.DrawWireCube(transform.position, new Vector3(width, 0, height));
	}

	// Update is called once per frame
	void Update () {
		if (transform.position.x <= boundaryLeft) {
			if (speed >= 0) {
				return;
			} else {
				speed = -speed;
			}
		}
		if (transform.position.x >= boundaryRight) {
			if (speed <= 0) {
				return;
			} else {
				speed = -speed;
			}
		}
		transform.position += new Vector3 (speed * Time.deltaTime, 0, 0);

		
	}
}
