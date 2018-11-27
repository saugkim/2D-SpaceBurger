using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyMeter : MonoBehaviour
{
    Image EnergyBar0;
    public Image MiniEnergyBar;
    float maxEnergy = 5000f;
    public static float Energy;
    public static int energySteps;
    //kim
    public static float TotalEnergy;
    PauseControl gameControl;
    public GameObject gameControlGameObject;
    //kim

    void Start()
    {
        //kim
        gameControl = gameControlGameObject.GetComponent<PauseControl>();
        //kim
        energySteps = 6;
        EnergyBar0 = GetComponent<Image>();
        Energy = maxEnergy + 4000f;
        TotalEnergy = 1f;
    }

    public static void LoadEnergy(int palkki)
    {
        TotalEnergy += (1f / energySteps)*palkki;
    }

    void FixedUpdate()
    {
        if(TotalEnergy >1){
            TotalEnergy = 1;
        }
        if (Energy > 0)
        {
            Energy -= 10;
        }

        if (Energy/maxEnergy < 1)
        {
            MiniEnergyBar.fillAmount = Energy/maxEnergy;
        }
        else
        {
            MiniEnergyBar.fillAmount = 1;
        }
        EnergyBar0.fillAmount = TotalEnergy;

        if (Energy == 0)
        {
            Energy = maxEnergy;
            TotalEnergy -= 1f / energySteps;
        }
        if (TotalEnergy < 0-(1f / energySteps) / 2)
        {
            gameControl.GameOver();
        }
    }


}