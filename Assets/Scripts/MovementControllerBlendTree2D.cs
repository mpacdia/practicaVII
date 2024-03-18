using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using Cinemachine;


public class MovementControllerBlendTree2D : MonoBehaviour
{
    public float speed = 5.0f; // La velocidad a la que se va a mover el personaje

    public float rotationSpeed = 0.5f;

    public bool doorArea = false;
    public bool insideHouse = false;
    public bool running = false;
    public bool stay = true;

    public GameObject enemy;

    private CharacterController characterController;
    private Animator animatorController;
    public Animator doorAnimator;
    public Animator enemyAnimator;


    public CinemachineVirtualCamera cameraOutside;
    public CinemachineVirtualCamera cameraInside;

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

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            running = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            running = false;
        }


        animatorController.SetBool("running", running);
        animatorController.SetFloat("speed", Mathf.Abs(move.z));

        doorAnimator.SetBool("isCloseToDoor", doorArea);

        enemyAnimator.SetBool("stay", stay);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "doorArea")
        {
            doorArea = true;
        }
        
        if (other.gameObject.tag == "insideHouse")
        {
            cameraOutside.Priority = 0;
            cameraInside.Priority = 1;
        }

        if (other.gameObject.tag == "enemy")
        {
            stay = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "doorArea")
        {
            doorArea = false;
        }

        if (other.gameObject.tag == "insideHouse")
        {
            cameraOutside.Priority = 1;
            cameraInside.Priority = 0;
        }
    }
}
