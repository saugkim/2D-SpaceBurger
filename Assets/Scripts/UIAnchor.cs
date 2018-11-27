using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnchor : MonoBehaviour {

	// Use this for initialization
	public GameObject anchor;
	
    void Awake()
    {
       if(anchor != null){
            transform.position = anchor.transform.position;
        } 
    }
    void Update()
    {
        if(anchor != null){
            transform.position = anchor.transform.position;
        }
        
    }
}
