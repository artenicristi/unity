using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnergyIndicator : MonoBehaviour
{
    public Image enegyBar;
    public static float energyAmount = 80;

    private float secondsToEmptyEnergy = 1800f;


    private void Start()
    {
        enegyBar.fillAmount = energyAmount / 100;
    }

    private void Update()
    {
        if(energyAmount > 0)
        {
            energyAmount -= 100 / secondsToEmptyEnergy * Time.deltaTime;
            enegyBar.fillAmount = energyAmount / 100;
        }
        
    }
}
