using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PowerSelectScript : MonoBehaviour {
	private GameObject livePlayer;
	private int shotElement;
	public Image Element;
	public Sprite[] elementSprites = new Sprite[4];
	public Text timerText;
	private PlayerScript player;
	public float timer = 10;
	private CanvasGroup canvasGroup;

	void Start () {
		canvasGroup = this.gameObject.GetComponent<CanvasGroup> ();
	}
	void Update () {
		
		livePlayer = GameObject.FindGameObjectWithTag("Char");
		if (livePlayer != null){
			player = livePlayer.GetComponent<PlayerScript> ();
			if (player.GotNewPower > 0) {
				canvasGroup.alpha = 1;
				canvasGroup.interactable = true;
				shotElement = player.GotNewPower;
				if (timer > 0) {
					timer -= Time.deltaTime;
				} else {
					player.GotNewPower = 0;
				}
				Element.sprite = elementSprites [shotElement - 1];
				timerText.text = ((int)timer).ToString();
			} else {
				timer = 10;
				canvasGroup.alpha = 0;
				canvasGroup.interactable = false;
			}
		}
	}
	public void ChoseAttack () {
		player.setElement = shotElement;
		player.GotNewPower = 0;
	}
	public void ChoseDefense () {
		player.setElement2 = shotElement;
		player.GotNewPower = 0;
	}
}