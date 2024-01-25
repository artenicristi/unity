using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergiIndicatorTrigger : MonoBehaviour
{
    public GameObject PanelEnergy;


    private void Start()
    {
        PanelEnergy.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        PanelEnergy.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        PanelEnergy.SetActive(false);
    }



}
