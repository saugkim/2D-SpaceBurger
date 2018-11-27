using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PihvinPaistuminen : MonoBehaviour
{

    public float paistoaika = 0;

    // Use this for initialization

	public GameObject Pihvi;
	public GameObject AinesVisual;
    // Update is called once per frame
	public Sprite RaakaPihvi;
	public Sprite ValmisPihvi;
	public bool PihviValmis;
	public bool Paisto;
	void Start()
	{
		PihviValmis = false;
		paistoaika =0;
		Paisto = false;
	}
	void Update()
    {
        if(Paisto == true){
			paistoaika += Time.deltaTime;
		}

        //pihvin paisto hyväksi
        
        //pihvin karrelle palaminen
        if (paistoaika > 5&& paistoaika < 15)
        {
            PihviValmis = true;
			Pihvi.GetComponent<SpriteRenderer>().sprite = ValmisPihvi;
        }
        if (paistoaika > 15)
        {
            Paisto = false;
			Destroy(Pihvi);
			paistoaika = 0;
			PihviValmis = false;
		}

    }
    public void StartGrilling()
    {

		Pihvi = Instantiate(AinesVisual, transform.position,Quaternion.identity);
		Pihvi.GetComponent<SpriteRenderer>().sprite = RaakaPihvi;
		Paisto = true;
	}


	
	public void TakePihvi(){
		Destroy(Pihvi);
		paistoaika = 0;
		Paisto = false;
		PihviValmis = false;
	}
}
