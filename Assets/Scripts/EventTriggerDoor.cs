using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTriggerDoor : MonoBehaviour
{
    public GameObject Door;
    bool isDoorOpen = false;
    bool canOpenDoor = false;
  

void Update()
    {

        if (!isDoorOpen && canOpenDoor == true)
        {
            OpenDoor();
        }else if(isDoorOpen && !canOpenDoor)
        {
            CloseDoor();
        }    

    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("Open Door");

        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E)) // Verificați dacă obiectul intrat are eticheta "Player"
        {
            //Debug.Log("Open Door");
            canOpenDoor = true;
            isDoorOpen = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Verificați dacă obiectul intrat are eticheta "Player"
        {
            canOpenDoor = false;
            //Debug.Log("Door Close");
            isDoorOpen = true;
        }
    }

    private void OpenDoor()
    {
        float rotationSpeed = 2f;
       
        Door.transform.rotation = Quaternion.Slerp(Door.transform.rotation, Quaternion.Euler(new Vector3(0f, -65f, 0f)), rotationSpeed * Time.deltaTime);
        //Debug.Log("OpenDoor");

    }
    private void CloseDoor ()
    {

        float rotationSpeed = 2.5f;
        Door.transform.rotation = Quaternion.Slerp(Door.transform.rotation, Quaternion.Euler(new Vector3(0f, 90f, 0f)), rotationSpeed * Time.deltaTime);
        //Debug.Log("CloseDoor");

    }
}
