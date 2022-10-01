using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;

    //DELETE THIS COMMENT 

    //Playermovement speed
    public float speed;

    //Hip rigidbody
    public Rigidbody hips;

    //Bool to check if player is touching the ground
    public bool isGrounded;

    private void Start()
    {
        //Sets hips to the rigidbody
        hips = GetComponent<Rigidbody>();
    }

    //Animation set in Update, FixedUpdate is reserved for physics related code
    private void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                //Sets the animation to run animation
                animator.SetBool("isWalk", true);
                animator.SetBool("isRun", true);
            }
            else
            {
                //Sets the animation to walk animation
                animator.SetBool("isWalk", true);
                animator.SetBool("isRun", false);
            }
        }

        else
        {
            //Sets both to false, will play idle animation
            animator.SetBool("isWalk", false);
            animator.SetBool("isRun", false);
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                //Sets the animation to run animation
                animator.SetBool("isWalk", true);
                animator.SetBool("isRun", true);
            }
            else
            {
                //Sets the animation to walk animation
                animator.SetBool("isWalk", true);
                animator.SetBool("isRun", false);
            }
        }
    }

    //Fixed Update rather than Update because we're using physics
    private void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.W))
        {
            if(Input.GetKey(KeyCode.LeftShift))
            {
                //Adds force to the hips to move player forward, speed * 1.5 if player is holding left shift
                hips.AddForce(hips.transform.forward * speed * 1.5f);
            }
            else
            {
                hips.AddForce(hips.transform.forward * speed);
            }
        }


        if (Input.GetKey(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                //-hips to move player backwards
                hips.AddForce(-hips.transform.forward * speed * 1.5f);
            }
            else
            {
                hips.AddForce(-hips.transform.forward * speed);
            }
        }
        
    }
}
