using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BackgroundLoop : MonoBehaviour {

	public int stagePoints;
	public int loopPoints;
	public bool endStage = false;
	public Transform[] Enemy = new Transform[3];
	public int[] EnemyCost = new int[3];
	public int[] EnemyLimit = new int[3];
	public int[] EnemyProb = new int[3];
	public Transform Boss;
	public Transform loopPrefab;
	public Transform nextSensor;
	private bool BackGenerated;
	private GameObject liveBoss;
	public bool checkpoint = false;
	void Update ()
	{
		liveBoss = GameObject.FindGameObjectWithTag("Boss");
		if ((endStage) && (liveBoss == null)) {
			LifeSystemScript lifeSystem = GameObject.FindGameObjectWithTag ("LifeControl").GetComponent<LifeSystemScript> ();
			lifeSystem.stageClear = true;
		}
		if (checkpoint) {
			var newBackground = Instantiate (loopPrefab, transform.position + new Vector3 (42.35f, 0), Quaternion.identity, transform.parent) as Transform;
			var newBackground2 = Instantiate (loopPrefab, transform.position + new Vector3 (84.7f, 0), Quaternion.identity, transform.parent) as Transform;
			var newSensor = Instantiate (nextSensor, transform.position + new Vector3 (84.7f, 0), transform.rotation, transform.parent) as Transform;
			BackgroundLoop loop = newSensor.transform.GetComponent<BackgroundLoop> ();
			loop.checkpoint = false;
			loop.loopPoints = loopPoints + 1;
			if (SceneManager.GetActiveScene ().name != "MainMenu") {
				if (stagePoints > 0) {
					while (loopPoints > 0) {
						int enemyId = Random.Range (0, 3);
						if ((EnemyLimit [enemyId] > 0)&&(Random.Range(0,100) <= EnemyProb[enemyId])) { 
							var genEnemy = Instantiate (Enemy [enemyId], transform.position + new Vector3 (Random.Range (42.35f, 84.35f), Random.Range (-4, 4.5f)), Quaternion.identity, transform.parent.parent) as Transform;
							loopPoints -= EnemyCost [enemyId];
							stagePoints -= EnemyCost [enemyId];
							EnemyLimit [enemyId]--;
						}
					}
				} else if (endStage == false) {
					var genEnemy = Instantiate (Boss, transform.position + new Vector3 (42.35f, Random.Range (-2, 2.5f)), Quaternion.identity, transform.parent.parent) as Transform;
					endStage = true;
				}
			}
			loop.stagePoints = stagePoints;
			loop.endStage = endStage;
			Destroy (gameObject);
		}
	}
}