using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropScript : MonoBehaviour {
	public Transform droppedItem;
	// Use this for initialization

	void OnDestroy()
	{
		var itemTransform = Instantiate(droppedItem) as Transform;
		// Assign position
		itemTransform.position = transform.position;
	}
}
