using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurilaisLautanen : MonoBehaviour
{
    public GameObject orderText;
    public GameObject menuREF;
    public MenuRefrence menu;
    public Hampurilanen burgeri;
    public List<int> stack;
    public int burgerID;
    public GameObject burgerTemplate;
    private float BurgerSize;
    public int BurgerTimer;
    public bool orderPassed;
    Text BurgerOrder;
    public GameObject asiakas;
    //kim
    public ParticleSystem particleEmit;
    GameObject orderImageHolder;
    GameObject orderImageChild;
    public GameObject asiakasCTRL;
    public GameObject customerImageHolder;
    public GameObject customerOriginPosition;
    public GameObject customerTargetPosition;
    public int ordersFailed;
    public bool orderFail;  
    //kim

    public void Start()
    {
        orderText = GameObject.FindGameObjectWithTag("Teksti");
        menu = menuREF.GetComponent<MenuRefrence>();
        //BurgerOrder = transform.GetChild(0).GetChild(0).GetComponent<Text>();
        burgeri = menu.BurgerMenu[burgerID];
        BurgerSize = 0;
        BurgerTimer = -1;
        //BurgerOrder.text = burgeri.name;
        orderPassed = false;
        orderText.GetComponent<TextScript>().ShowOrder(burgeri.name);
        ordersFailed = 0;
        //kim
        orderImageHolder = GameObject.FindGameObjectWithTag("Temp");
        orderImageChild = GameObject.FindGameObjectWithTag("TempChild");
        asiakas = GameObject.FindGameObjectWithTag("Customer");
        customerOriginPosition = GameObject.FindGameObjectWithTag("Origin");
        customerTargetPosition = GameObject.FindGameObjectWithTag("Target");
        ShowOrderImage();
        asiakasCTRL = GameObject.FindGameObjectWithTag("AsiakasCTRL");
        //kim
    }

    //kim copy from burgerShowCase scripts
    public void ShowOrderImage()
    {
        orderImageHolder.GetComponentInChildren<SpriteRenderer>().enabled = true;
        //customerImageHolder.GetComponent<SpriteRenderer>().enabled = true;
       /* 
        int burgerLayers = 0;
        float layerHeight = 0.15f;
        float skaala = 1;
        
        if (burgeri.Ingredients.Count > 6)
        {
            layerHeight = 0.15f * (8f / (burgeri.Ingredients.Count + 1));
            skaala = 8f / (burgeri.Ingredients.Count + 1);
        }

        foreach (int i in burgeri.Ingredients)
        {
            GameObject x = Instantiate(burgerTemplate, orderImageChild.transform.position + new Vector3(0, burgerLayers * layerHeight, 0), Quaternion.identity);
            x.GetComponent<SpriteRenderer>().sprite = menu.IngredientID[i].Kuva;
            burgerLayers++;
            x.GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(burgerLayers) + 1;
            x.transform.parent = orderImageChild.transform;
            x.transform.localScale = new Vector3(1, skaala, 1);
        }

        GameObject kansiSampyla = Instantiate(burgerTemplate, orderImageChild.transform.position + new Vector3(0, burgerLayers * layerHeight, 0), Quaternion.identity);
        kansiSampyla.GetComponent<SpriteRenderer>().sprite = menu.IngredientID[5].Kuva;
        burgerLayers++;
        kansiSampyla.GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(burgerLayers) + 1;
        kansiSampyla.transform.parent = orderImageChild.transform;
        kansiSampyla.transform.localScale = new Vector3(1, skaala, 1);
        */
    }
    //kim


    public void resetBurger()
    {
        BurgerSize = 0;
        stack.Clear();
        Debug.Log("Order "+ orderPassed);
        foreach (Transform i in transform)
        {
            if(ordersFailed>0){
                i.gameObject.GetComponent<Explode>().ExplodeBurger(new Vector2(Random.Range(-2f,2f),Random.Range(0f,2f)));
            }
            else{
                Destroy(i.gameObject);
            }
        }

        if (orderPassed)
        {
            asiakas.GetComponent<Animator>().SetTrigger("Happy");
            orderText.GetComponent<TextScript>().EndOrder();
            asiakas.GetComponent<CustomerMove>().Leave();
            //kim
            orderImageHolder.GetComponentInChildren<SpriteRenderer>().enabled = false;
            asiakasCTRL.GetComponent<AsiakasScript>().BurgerCount++;
            Debug.Log("Order Passed");
            Destroy(gameObject);
        }else{
            ordersFailed++;
            if(ordersFailed>1){
                particleEmit.Play();
            }
            Debug.Log("Order Failed");
            asiakas.GetComponent<Animator>().SetTrigger("Mad");
            asiakas.GetComponent<CustomerMove>().magnitude+=0.05f;
            asiakas.GetComponent<CustomerMove>().freq+=1f;
            //SoundControl.PlaySound("oFailed");


           

        }
        
    }
    public void debugBurger(){
        foreach(int i in burgeri.Ingredients){
            addLayer(i);
        }
        addLayer(5);
    }
    public void addLayer(int aines)
    {
        if (stack.Count == 0 && aines == 0)
        {
            stack.Add(aines);
            ShowBurger(aines);
        }
        else if (stack.Count > 0 && aines != 5)
        {
            stack.Add(aines);
            ShowBurger(aines);
        }
        else if (stack.Count > 0)
        {
            ShowBurger(aines);
            sendBurger();
        }

    }
    public void sendBurger()
    {
        if (stack.SequenceEqual(burgeri.Ingredients))
        {
            Debug.Log("Correct burger");

            EnergyMeter.LoadEnergy(2);
            orderPassed = true;
            //burgeri = menu.BurgerMenu[burgerID];
            BurgerTimer = 100;
        }
        else
        {
            //
            orderFail = true;
            //
            Debug.Log("Wrong burger");
            BurgerTimer = 100;


        }

    }
    private void ShowBurger(int aines)
    {
        if (aines >= 0)
        {
            
            GameObject x = Instantiate(burgerTemplate, gameObject.transform.position + new Vector3(0, BurgerSize * 0.1f, 0), Quaternion.identity);
            x.GetComponent<SpriteRenderer>().sprite = menu.IngredientID[aines].Kuva;
            BurgerSize++;
            x.GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(BurgerSize) + 1;
            x.transform.parent = gameObject.transform;
        }

    }
    private void FixedUpdate()
    {
        gameObject.GetComponent<BoxCollider2D>().offset =new Vector2(0,BurgerSize *0.1f) ;
        if (BurgerTimer > 0)
        {
            BurgerTimer -= 1;
        }
        if (BurgerTimer == 0)
        {
            resetBurger();
            BurgerTimer = -1;
        }
    }
}
