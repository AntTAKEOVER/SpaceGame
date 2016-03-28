using UnityEngine;
using System.Collections;

public class EnemyContoller : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(Collider other){
		Projectile bullet = other.gameObject.GetComponent<Projectile> ();
		if (bullet != null) {
			Debug.Log ("Take Damage!");
		}
	
	}

}
