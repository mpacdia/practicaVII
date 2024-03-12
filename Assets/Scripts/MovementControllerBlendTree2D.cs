using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class MovementControllerBlendTree2D : MonoBehaviour
{
    public float speed = 5.0f; // La velocidad a la que se va a mover el personaje

    public float rotationSpeed = 0.5f;

    private CharacterController characterController;
    private Animator animatorController;

    void Start()
    {
        // Get the Character Controller on the player
        characterController = GetComponent<CharacterController>();
        animatorController = GetComponent<Animator>();
    }

    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        // Calculamos el vector de movimiento -> ((0,0,1) * vertical + (1,0,0) * horizontal) * speed
        Vector3 move = transform.forward * vertical;
        transform.Rotate(Vector3.up * horizontal * rotationSpeed, 1, Space.Self);
        characterController.Move(move * speed * Time.deltaTime);


        // TODO: Establecer las animaciones!


        animatorController.SetFloat("speed", move.z);
    }
   }
