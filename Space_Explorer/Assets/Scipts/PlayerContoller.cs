using UnityEngine;
using System.Collections;

public class PlayerContoller : MonoBehaviour {
	public GameObject dampner;
	public GameObject spawnPoint;
	public GameObject playerProjectile;
	public float projectileSpeed;
	public float fireSpeed;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		float xmin;
		float xmax;
		float tilt = 35f;
		dampner.transform.position += new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, 0);

		xmin = Camera.main.ViewportToWorldPoint (new Vector3(0,0,0)).x + 4 ;
		xmax = Camera.main.ViewportToWorldPoint (new Vector3(1,0,0)).x - 4;

		dampner.transform.position = new Vector3 (Mathf.Clamp (dampner.transform.position.x, xmin, xmax), 0, 0);
		transform.position = new Vector3 (Mathf.Lerp (transform.position.x, dampner.transform.position.x, 0.08f), 0,0);
		transform.rotation = Quaternion.Euler(new Vector3(0,0, Input.GetAxis("Horizontal") * -tilt));
	
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Space)) {
			InvokeRepeating ("Shoot", 0.01f, fireSpeed);
		}

		if (Input.GetKeyUp (KeyCode.Space)) {
			CancelInvoke ();
		}
		
	}

	void Shoot(){
		GameObject bullet =	Instantiate (playerProjectile, spawnPoint.transform.position, Quaternion.identity) as GameObject;
		bullet.GetComponent<Rigidbody>().velocity = new Vector3(0,0, projectileSpeed);
	}
		
}


