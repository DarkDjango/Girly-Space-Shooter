using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropScript : MonoBehaviour {
	public Transform droppedItem;
	private HealthScript health;
	public int dropProb;
	void Start()
	{
		health = gameObject.GetComponent<HealthScript> ();
	}

	void OnDestroy()
	{
		if ((health != null) && (health.hp == 0)) {
			int randomNumber = Random.Range (1, 101);
			if (randomNumber <= dropProb) {
				var itemTransform = Instantiate (droppedItem) as Transform;
				itemTransform.position = transform.position;
			}
		}
	}
}
