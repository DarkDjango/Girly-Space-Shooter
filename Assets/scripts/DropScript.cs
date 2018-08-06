using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropScript : MonoBehaviour {
	public Transform droppedItem;
	public int dropProb;

	void OnDestroy()
	{
		int randomNumber = Random.Range(1,101);
		if(randomNumber <= dropProb){
			var itemTransform = Instantiate(droppedItem) as Transform;
			itemTransform.position = transform.position;
		}
	}
}
