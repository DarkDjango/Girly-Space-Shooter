using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewLevelScript : MonoBehaviour {

	public int level = 1;

	private Text text_level;

	// Use this for initialization
	void Start () {
		text_level = GetComponent<Text>();
		text_level.text = "レベル"+level;
		StartCoroutine(FadeTextToFullAlpha(1f, GetComponent<Text>()));
	}
	
	// Update is called once per frame
	void Update () {
		Destroy(gameObject,3);
	}

	public IEnumerator FadeTextToFullAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }
 
    public IEnumerator FadeTextToZeroAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }
}
