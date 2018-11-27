using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TextScript : MonoBehaviour
{
   
    // Use this for initialization
    public TextMeshProUGUI teksti;
    public GameObject anchor;

    void Start()
    {
       
        teksti = gameObject.GetComponent<TextMeshProUGUI>();
        teksti.enabled = false;

    }
    
    
    void Update()
    {
        if(anchor != null){
            transform.position = anchor.transform.position;
        }
        
    }
    public void ShowOrder(string burgerName)
    {
        teksti.enabled = true;

        teksti.text = burgerName;

       
    }
    public void EndOrder()
    {
        teksti.enabled = false;

      
    }

}
