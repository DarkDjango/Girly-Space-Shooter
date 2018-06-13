using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeScript : MonoBehaviour {

	private float timer = 1;
	public bool isFrozen;
	public bool gotShot;
	public bool isStop = false;
	private SpriteRenderer sprite;
	private MoveScript moveScript;
	private Vector2 prevSpeed;
	private Vector2 prevDirection;

	void Start()
	{
		sprite = GetComponent<SpriteRenderer> ();
		moveScript = GetComponent<MoveScript> ();
	}
	void Update()
	{
		if (gotShot) {
			isFrozen = true;
			timer = 1;
			gotShot = false;
			}
		if (isFrozen) {
			if (!isStop) {
				prevSpeed = moveScript.speed;
				prevDirection = moveScript.direction;
				moveScript.speed = new Vector2 (1, 0);
				moveScript.direction = new Vector2 (-1, 0);
				isStop = true;
			}
			sprite.color = new Color(0.25f, 0.25f, 1f, 1f);
			if (timer > 0) {
				timer -= Time.deltaTime;
			}
			if (timer <= 0) {
				{
					isFrozen = false;
					sprite.color = new Color(1f, 1f, 1f, 1f);
					moveScript.speed = prevSpeed;
					moveScript.direction = prevDirection;
					isStop = false;
				}
			}
		}
	}
}