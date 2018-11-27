using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{

    public float moveSpeed;

    [HideInInspector]
    public Vector3 offset;
    private bool following;
	public int AinesDragged;
	public SpriteRenderer spriteRND;
	public GameObject menuREF;
	public MenuRefrence menuScript;
	void Start()
    {
        following = false;
        offset = new Vector3(0f, 0f, 10f);
		AinesDragged = -1;
		spriteRND = gameObject.GetComponent<SpriteRenderer>();
		menuScript = menuREF.GetComponent<MenuRefrence>();
	}

    void FixedUpdate()
    {

        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
    }

    void Update()
    {
		
		if(following && AinesDragged >= 0){
			spriteRND.sprite = menuScript.IngredientID[AinesDragged].Kuva;
		}
    
		if(AinesDragged == -2){
			spriteRND.sprite = menuScript.RaakaPihvi.Kuva;
		}
		
		if(AinesDragged == -1){
			spriteRND.sprite = null;
			spriteRND.enabled = false;

		}else{
			spriteRND.enabled = true;
		}
		
		
	}
	
	
	void OnMouseDown()
	{
	Collider2D[] colliders;
		colliders = Physics2D.OverlapBoxAll(gameObject.transform.position, new Vector2(0.1f,0.1f),0f);
		foreach(Collider2D meme in colliders){
			if(meme.tag == "Pino"){
				StartDrag( meme.gameObject.GetComponent<AinesIDREF>().AinesOsaID);
			}
			if(meme.tag == "Grilli"){
				if(meme.GetComponent<PihvinPaistuminen>().PihviValmis){
					meme.GetComponent<PihvinPaistuminen>().TakePihvi();
					StartDrag(2);
				}
			}
		}	
	}
	void OnMouseUp()
	{
		if(following)
        {
			StopDrag();
		}
	}
	public void StartDrag(int ainesID){
		following = true;
		AinesDragged = ainesID;
	}


	void StopDrag(){
		Collider2D[] colliders;
		colliders = Physics2D.OverlapBoxAll(gameObject.transform.position, new Vector2(0.64f,0.64f),0f);
		foreach(Collider2D meme in colliders){
			if(meme.tag == "Lautanen"){
				if(AinesDragged >= 0){
					meme.gameObject.GetComponent<PurilaisLautanen>().addLayer(AinesDragged);
				}
				
			}
			if ( meme.tag == "Grilli"&&AinesDragged == -2&&meme.GetComponent<PihvinPaistuminen>().Paisto == false){
				meme.gameObject.GetComponent<PihvinPaistuminen>().StartGrilling();
				break;
			}
		}	
	
		following = false;
		AinesDragged = -1;
	}

}
