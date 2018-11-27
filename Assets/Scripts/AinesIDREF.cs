using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AinesIDREF : MonoBehaviour {
	public bool activatedIngredient;
	public int AinesOsaID;
	public SpriteRenderer spr;
	public AsiakasScript asiakas;
	void Start()
	{
		activatedIngredient = false;
		spr = gameObject.GetComponent<SpriteRenderer>();
		spr.enabled = false;
		gameObject.tag = "Untagged";
		asiakas = GameObject.FindGameObjectWithTag("AsiakasCTRL").GetComponent<AsiakasScript>();
	}
	
	void Update()
	{
		
		if(asiakas.UnlockedIngredients >=AinesOsaID&&!activatedIngredient){
			activatedIngredient = true;
		}
		
		if(activatedIngredient){
			gameObject.tag= "Pino";
			spr.enabled = true;
		}
	}
}
