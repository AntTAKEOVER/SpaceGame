using UnityEngine;
using System.Collections;

public class EnemyContoller : MonoBehaviour {

	public float myHealth = 200;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(Collider other){
		Projectile bullet = other.gameObject.GetComponent<Projectile> ();
		if (bullet != null) {
			myHealth -= bullet.GetDamage ();
			bullet.Hit ();
			if (myHealth <= 0) {
				Destroy (gameObject);
			}

		//	Debug.Log ("Take Damage!");
		}
	
	}

}
