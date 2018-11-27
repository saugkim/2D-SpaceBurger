using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SetValue : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<TMP_Dropdown>().value = QualitySettings.GetQualityLevel();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
