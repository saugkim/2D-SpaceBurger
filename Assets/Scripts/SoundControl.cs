using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour{
public static AudioClip oFailed;
    static AudioSource aSrc;
    
  //  public GameObject soundSource;

     void Start()
    {
        oFailed = Resources.Load<AudioClip>("oFailed");
        aSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip){
            case "oFailed":
                aSrc.PlayOneShot(oFailed);
                break;
        }
    }

}