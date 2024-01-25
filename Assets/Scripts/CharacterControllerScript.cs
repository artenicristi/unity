using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerScript : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float rotationSpeed = 180.0f;
    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Obține inputul de la tastatură sau de la alte dispozitive
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calcularea mișcării în funcție de input
        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput);
        moveDirection = transform.TransformDirection(moveDirection); // Transformarea direcției în coordonatele locale

        // Aplică mișcarea
        characterController.SimpleMove(moveDirection * moveSpeed);

        // Rotirea personajului în funcție de inputul de rotație
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime * horizontalInput);
    }
}
