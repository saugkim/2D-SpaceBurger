using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsiakasScript : MonoBehaviour
{

    // Use this for initialization
    public GameObject button;
    public bool debugMode;
    public GameObject asiakas;
    public GameObject orderText;
    public int asiakasMax;
    public GameObject Lautanen;
    public int levelMax;
    public int burgerLevel;
    public int burgerTimer;
    public int BurgerCount;
    public int NewBurgerAmount;
    public int ProgressionLevel;
    public int ProgressionMax;
    public int levelRequirement;
    public int UnlockedIngredients;
    public int newUlockedIngredients;
    public GameObject flyby;
    public GameObject debugObj;
    void Start()
    {
        newUlockedIngredients = 2;
        UnlockedIngredients = 5;
        asiakasMax = 1;
        levelMax = 4;
        burgerLevel = 0;
        burgerTimer = -1;
        ProgressionLevel = 0;
        ProgressionMax = 2;
        NewBurgerAmount = 3;
        levelRequirement = 6;
        burgerTimer = Random.Range(180, 300);
        
        Debug.Log(PlayerPrefs.GetInt("DebugMode",0));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (BurgerCount == levelRequirement && ProgressionLevel < ProgressionMax)
        {
            flyby.GetComponent<FlyByPath>().StartFlyBy();
            BurgerCount = 0;   
            
            ProgressionLevel++;
        }
        
        
            
        
        if (burgerTimer >= 0)
        {
            burgerTimer--;
        }
        if (burgerTimer == 0)
        {
            asiakas.GetComponent<CustomerMove>().StartOrder();
        }

    }
    public void Progress(){
        levelMax += NewBurgerAmount;
        UnlockedIngredients += newUlockedIngredients;
    }
    public void OrderBurger()
    {
        
        GameObject inst = Instantiate(Lautanen, transform.position, Quaternion.identity);
        if (burgerLevel <= levelMax)
        {
            inst.GetComponent<PurilaisLautanen>().burgerID = burgerLevel;
            burgerLevel++;
        }
        else
        {
            inst.GetComponent<PurilaisLautanen>().burgerID = Random.Range(0, levelMax);
        }

    }
    public void DebugLautanen(){
        debugObj = GameObject.FindGameObjectWithTag("Lautanen");
        if(debugObj != null){
            debugObj.GetComponent<PurilaisLautanen>().debugBurger();
        }
        
    }

}
