using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerIot : MonoBehaviour
{
    public GameObject TriggerPanelPrefab;

    private void Start()
    {
        TriggerPanelPrefab.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        TriggerPanelPrefab.SetActive(true);
        Cursor.lockState = CursorLockMode.None;

        // Arată cursorul
        Cursor.visible = true;
        FirstPersonController.instance.cameraCanMove = false ;
    }

    private void OnTriggerExit(Collider other)
    {
        TriggerPanelPrefab.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;

        // Ascunde cursorul
        Cursor.visible = false;
        FirstPersonController.instance.cameraCanMove = true;

    }
}
