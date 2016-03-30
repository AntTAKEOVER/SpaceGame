using UnityEngine;
using System.Collections;

public class EnemyContoller : MonoBehaviour {

	public float bulletSpeed;
	public float myHealth = 200;
	public GameObject EnemyProjectile;
	public GameObject projectileSpawnPoint;
	public float shotFrequency = 0.5f;
	public bool canShoot; 

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		float ProbabilityOfFiring = shotFrequency * Time.deltaTime;
		if(Random.value < ProbabilityOfFiring && canShoot){
			Shoot();
		}
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

	void Shoot(){
		
		GameObject bullet =  Instantiate (EnemyProjectile, projectileSpawnPoint.transform.position, transform.rotation) as GameObject;
		bullet.GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, -bulletSpeed);
	}

}
