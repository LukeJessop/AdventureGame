using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
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
        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetTrigger("Fall");
        }
        
        //Triggers DoubleJump on W key
        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetTrigger("DoubleJump");
        }
        
        //Triggers Hit on H key
        if (Input.GetKeyDown(KeyCode.H))
        {
            animator.SetTrigger("Hit");
        }
    }
}
