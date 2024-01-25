using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VazonIndicatorTrigger : MonoBehaviour
{
    public GameObject PanelVazon;


    private void Start()
    {
        PanelVazon.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        PanelVazon.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        PanelVazon.SetActive(false);
    }



}
