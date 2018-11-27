using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodMenu : MonoBehaviour {

	public Sprite GScreen, BScreen, YScreen;

	float timer = 5f;
	float delay = 5f;

	// Use this for initialization
	void Start () {
		this.gameObject.GetComponent<SpriteRenderer>().sprite = GScreen;
	}
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if(timer <= 0)
		{
			if(this.gameObject.GetComponent<SpriteRenderer>().sprite == GScreen)
			{
				this.gameObject.GetComponent<SpriteRenderer>().sprite = BScreen;
				timer = delay;
				return;
			}
			if(this.gameObject.GetComponent<SpriteRenderer>().sprite == BScreen)
			{
				this.gameObject.GetComponent<SpriteRenderer>().sprite = YScreen;
				timer = delay;
				return;
			}
			if(this.gameObject.GetComponent<SpriteRenderer>().sprite == YScreen)
			{
				this.gameObject.GetComponent<SpriteRenderer>().sprite = GScreen;
				timer = delay;
				return;
			}
		}

	}
}
