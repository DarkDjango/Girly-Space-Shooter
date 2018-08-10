using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScript : MonoBehaviour {

	public float timer;
	SpriteRenderer sprite;
	void Start()
	{
		sprite = GetComponent<SpriteRenderer> ();
	}
	void Update ()
	{
		if (timer > 0) {
			timer -= Time.deltaTime;
		} else
			Destroy (gameObject);
		if (timer <= 1) {
			sprite.color = new Color (1f, 1f, 1f, 0.5f);
		}
	}
}