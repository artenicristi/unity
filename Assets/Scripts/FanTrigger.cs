using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanTrigger : MonoBehaviour
{
    public GameObject Fan;
    bool interactFan = false;
    bool isWorkinkFan = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isWorkinkFan)
        {
            OpenFan();

        }
    }

    private void OnTriggerStay(Collider other)
    {
        interactFan = true;
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E) && interactFan == true) // Verificați dacă obiectul intrat are eticheta "Player"
        {
            Debug.Log("Turn on Fan");
            isWorkinkFan = !isWorkinkFan;
            

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Verificați dacă obiectul intrat are eticheta "Player"
        {
            Debug.Log("Door Close");

            interactFan = false;
        }
    }

    private void OpenFan()
    {
        float rotationSpeed = 2000f;
        if (isWorkinkFan == true)
        {
            Fan.transform.Rotate(Vector3.left * rotationSpeed * Time.deltaTime);
            Debug.Log("Started");

        }
        else if(isWorkinkFan == false)
        {
            isWorkinkFan = false;
            Debug.Log("Stopped");
        }
    }

}
