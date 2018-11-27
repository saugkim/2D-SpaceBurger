using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if(PlayerPrefs.GetInt("DebugMode",0)==0){
            gameObject.SetActive(false);
        }
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
