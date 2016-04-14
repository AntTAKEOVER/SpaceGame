using UnityEngine;
using System.Collections;

public class WaveManager : MonoBehaviour {

	public Wave[] waves;
	Wave currentWave;
	int currentWaveNumber = 1;
	GameObject formation; 
	int enmemiesCount;
	//bool allEnemiesDead = false;
	float formationsRemaining;
	float totalFormations;
	GameObject Childformation;


	void Start(){
		initializeWave ();
	}

	void Update(){
		//allEnemiesDead = currentWave.enemyFormation.GetComponent<EnemySpawner> ().AllEnemiesDead();
		//Debug.Log (allEnemiesDead);
	//	if (allEnemiesDead) {
			//spawnEnemies ();
		//}
		//Debug.LogWarning("Wave Number " + currentWaveNumber);
		//Debug.LogWarning ("Enemy remaining " + formationsRemaining );

	}

	void progressWave(){
		//currentWaveNumber += 1;


		if (currentWaveNumber <= waves.Length) {
			currentWave = waves [currentWaveNumber - 1];
	
			totalFormations = currentWave.enemyCount;
			formationsRemaining = totalFormations;
		
			spawnEnemies ();
		}
	}


	void initializeWave(){
		currentWave = waves [currentWaveNumber - 1];
		totalFormations = currentWave.enemyCount;
		formationsRemaining = totalFormations;
		spawnEnemies ();
	}

	public void spawnEnemies(){
		if (formationsRemaining > 0) {
			if (Childformation != null) {
				Destroy (Childformation.gameObject);
			}
			Childformation = Instantiate (currentWave.enemyFormation, transform.position, Quaternion.identity) as GameObject;
			formationsRemaining -= 1;
			Childformation.transform.parent = transform;

		}else if (formationsRemaining <= 0 && currentWaveNumber <= waves.Length) {
			//Debug.Log ("Progressed Wave");
			currentWaveNumber += 1;
			progressWave ();
		}
	}


	[System.Serializable]
	public class Wave{
		public float enemyCount;
		public GameObject enemyFormation;
	}




	/* void Start () {

		OnlySpawnFull ();
		//getBoundary ();

	}
	void Update () {
		
		if (AllEnemiesDead ()) {
			Debug.Log ("Spawn New Wave");
			OnlySpawnFull();
		}


	}

	Transform nextFreePos(){
		foreach (Transform enemyGameoBject in transform) {
			if (enemyGameoBject.childCount == 0) {
				return enemyGameoBject;
			}
		}
		return null;
	}


	bool AllEnemiesDead(){
		foreach (Transform enemyTransformGameObject in transform) {
			if (enemyTransformGameObject.childCount > 0) {
				return false;
			}
		}
		return true;
	}



	void OnlySpawnFull(){
		Transform FreePos = nextFreePos ();
		if (FreePos != null) {
			//Debug.Log (FreePos.transform.position);
			GameObject enemy = Instantiate (Enemy1, FreePos.transform.position, FreePos.transform.rotation) as GameObject;
			enemy.transform.parent = FreePos;

		}

		if(nextFreePos()){
			Invoke ("OnlySpawnFull", spawnDelay);
		}
	} */






		
}
