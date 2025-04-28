using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    private Animator animator;
    public AudioClip[] clips;
    private AudioSource sounds;
    private CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponentInParent<CharacterController>();
        animator = GetComponent<Animator>();
        sounds = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleAnimations();
    }

    private void HandleAnimations()
    {
        //Triggers running animation on X axis movement
        if (Input.GetAxis("Horizontal") != 0)
        {
            animator.SetTrigger("Running");
        }
        else
        {
            animator.SetTrigger("Idle");
        }

        // Triggers jump on spacebar
         if (Input.GetButtonDown("Jump"))
         {
             animator.SetTrigger("Jump");
         }

        //Triggers Fall on F key
        if (controller.velocity.y < -10)
        {
            animator.SetTrigger("Fall");
        }
    }

    public void HandleSounds(string soundName)
    {
        if (soundName == "Jump")
        {
            sounds.PlayOneShot(clips[0]);
        }

        if (soundName == "Hit")
        {
            sounds.PlayOneShot(clips[1]);
        }
    }
}
