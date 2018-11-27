using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energy : MonoBehaviour
{

    public GameObject meterPosition;
    Image EnergyBar0;
    float maxEnergy = 10000f;
    public float energy;
   
    public GameObject gameOverPanel;

    void Start()
    {
        EnergyBar0 = GetComponent<Image>();
        energy = maxEnergy;
        transform.position = Camera.main.WorldToScreenPoint(meterPosition.transform.position);
    }


    private void FixedUpdate()
    {
        if (GameObject.FindWithTag("Lautanen") != null)
        {
            GameObject lautanenRef = GameObject.FindGameObjectWithTag("Lautanen");
            PurilaisLautanen lautanen = lautanenRef.GetComponent<PurilaisLautanen>();


            float increase = 0f;

            if (energy > maxEnergy)
            {
                energy = maxEnergy;
            }

            if (energy > 0 && lautanen.orderFail)
            {
                increase = (maxEnergy * 0.17f) * -1;
                energy += increase;
                EnergyBar0.fillAmount = energy / maxEnergy;
                lautanen.orderFail = false;
            }

            if (lautanen.orderPassed)
            {
                increase = maxEnergy * 0.17f;
                energy += increase;
                EnergyBar0.fillAmount = energy / maxEnergy;
                lautanen.orderPassed = false;
            }

            if (energy <= 0)
            {
                Time.timeScale = 0;
                gameOverPanel.SetActive(true);
            }
        }
    }
}
