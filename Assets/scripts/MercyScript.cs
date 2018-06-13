using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MercyScript : MonoBehaviour {

	public float timer;
	public bool isInvencible;
	BoxCollider2D collision;
	SpriteRenderer sprite;
	void Start()
	{
		collision = GetComponent<BoxCollider2D>();
		sprite = GetComponent<SpriteRenderer> ();
	}
	void Update()
	{
		if (isInvencible) {
			collision.enabled = false;
			sprite.color = new Color(1f, 1f, 1f, 0.5f);
			if (timer > 0) {
				timer -= Time.deltaTime;
			}
			if (timer <= 0) {
				{
					isInvencible = false;
					collision.enabled = true;
					sprite.color = new Color(1f, 1f, 1f, 1f);
				}
			}
		}
	}
}