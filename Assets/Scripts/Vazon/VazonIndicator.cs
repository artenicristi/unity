using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class VazonIndicator : MonoBehaviour
{
    public Image waterBar;
    public Image lightBar;
    public Image grownBar;


    public static float waterAmount = 80;
    public static float lightAmount = 90;
    public static float grownAmount = 10;


    private float secondsToEmptyWater = 1400f;
    private float secondsToEmptyLight = 2400f;
    private float secondsToFullGrown = 1200f;




    private void Start()
    {
        waterBar.fillAmount = waterAmount / 100;
        lightBar.fillAmount = lightAmount / 100;
        grownBar.fillAmount = grownAmount / 100;


    }

    private void Update()
    {
        if(waterAmount > 0)
        {
            waterAmount -= 100 / secondsToEmptyWater * Time.deltaTime;
            waterBar.fillAmount = waterAmount / 100;

        }
        if (lightAmount > 0)
        {
            lightAmount -= 100 / secondsToEmptyLight * Time.deltaTime;
            lightBar.fillAmount = lightAmount / 100;

        }

        if (grownAmount < 100)
        {
            grownAmount += 100 / secondsToFullGrown * Time.deltaTime;
            grownBar.fillAmount = grownAmount / 100;

        }

    }
}
