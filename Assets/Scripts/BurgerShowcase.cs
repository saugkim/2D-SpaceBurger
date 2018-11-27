using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BurgerShowcase : MonoBehaviour
{

    public GameObject menuREF;
    public MenuRefrence menu;
    public Hampurilanen burgeri;

    public GameObject burgerTemplate;
    public int burgerID;
    public int timer;
    public GameObject asiakasScript;
    private int burgerLayers;
    public GameObject TekstiOBJ;
    void Start()
    {
        menu = menuREF.GetComponent<MenuRefrence>();
        burgerID = 0;
        burgeri = menu.BurgerMenu[burgerID];

        burgerLayers = 0;
        showcaseBurger();
        timer = 900;
    }


    public void SwitchBurger(int amount)
    {
        timer = 600;
        foreach (Transform z in transform)
        {
            Destroy(z.gameObject);
        }
        if (burgerID < asiakasScript.GetComponent<AsiakasScript>().levelMax&&amount == 1)
        {
            burgerID++;
        }
        else if(amount == 1)
        {
            burgerID = 0;
        }if (burgerID> 0&&amount == -1){
            burgerID--;
        }else if(amount ==-1){
            burgerID = asiakasScript.GetComponent<AsiakasScript>().levelMax;
        }

        burgeri = menu.BurgerMenu[burgerID];

        burgerLayers = 0;
        showcaseBurger();
    }

   


    void FixedUpdate()
    {
        if (timer >= 0)
        {
            timer--;
        }
        if (timer == 0)
        {
            SwitchBurger(1);
        }
    }


    public void showcaseBurger()
    {
        float layerHeight = 0.15f;
        float skaala = 1;
        TekstiOBJ.GetComponent<TextScript>().ShowOrder(burgeri.name);
        if (burgeri.Ingredients.Count > 6)
        {
            layerHeight = 0.15f * (8f / (burgeri.Ingredients.Count + 1));
            skaala = 8f / (burgeri.Ingredients.Count + 1);
        }


        foreach (int i in burgeri.Ingredients)
        {
            GameObject x = Instantiate(burgerTemplate, gameObject.transform.position + new Vector3(0, burgerLayers * layerHeight, 0), Quaternion.identity);
            x.GetComponent<SpriteRenderer>().sprite = menu.IngredientID[i].Kuva;
            burgerLayers++;
            x.GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(burgerLayers) + 1;
            x.transform.parent = gameObject.transform;
            x.transform.localScale = new Vector3(1, skaala, 1);
        }

        GameObject kansiSampyla = Instantiate(burgerTemplate, gameObject.transform.position + new Vector3(0, burgerLayers * layerHeight, 0), Quaternion.identity);
        kansiSampyla.GetComponent<SpriteRenderer>().sprite = menu.IngredientID[5].Kuva;
        burgerLayers++;
        kansiSampyla.GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(burgerLayers) + 1;
        kansiSampyla.transform.parent = gameObject.transform;
        kansiSampyla.transform.localScale = new Vector3(1, skaala, 1);
    }
}
