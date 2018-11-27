using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SettingsMenu : MonoBehaviour {

	public Toggle debugToggle;

	void Start()
	{
		debugToggle.isOn = 0!=PlayerPrefs.GetInt("DebugMode",0);	
	}
	public void GraphicsChange (int indexGFX) {
		QualitySettings.SetQualityLevel(indexGFX);
	}
	
	// Update is called once per frame
	public void SoundChange (bool sound) {
		if(sound){
			PlayerPrefs.SetInt("DebugMode",1);
		}else{
			PlayerPrefs.SetInt("DebugMode",0);
		}
	}
}
