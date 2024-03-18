using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openDoor : MonoBehaviour
{
    public bool opened = false;

    public Animator doorAnimator;

    public AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        doorAnimator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            opened = true;
        }

        doorAnimator.SetBool("opened", opened);
    }

    public void playSound()
    {
        sound.Play();
    }
}
