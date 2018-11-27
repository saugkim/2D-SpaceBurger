using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour {

	// Use this for initialization
	Vector2 explosionForce;
	int timer;
	// Update is called once per frame
	
	void Start()
	{
		explosionForce = Vector2.zero;
		//explosionForce = new Vector2(Random.Range(-1f,1f),Random.Range(0.5f,1f));
	}
	void FixedUpdate () {
		transform.position=transform.position +(Vector3)explosionForce;
		if(timer >20){
			Destroy(gameObject);
		}
		if(explosionForce !=Vector2.zero){
			timer++;
		}
	}
	public void ExplodeBurger(Vector2 force){
		explosionForce =force*0.5f ;
		Debug.Log(explosionForce);
	}
}
