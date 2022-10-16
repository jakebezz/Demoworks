using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Animator animator;

    public Ragdoll groundCheck;

    //Playermovement speed
    [SerializeField] float speed;

    //Sets the global hips variable to the hips rigidbody
    private void Awake()
    {
        RotationSingleton.Instance.hips = GetComponent<Rigidbody>();
    }

    //Animation set in Update, FixedUpdate is reserved for physics related code
    private void Update()
    {
        if(Input.GetKey(KeyCode.W) && groundCheck.isGrounded == true)
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

        if (Input.GetKey(KeyCode.S) && groundCheck.isGrounded == true)
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
        if(Input.GetKey(KeyCode.W) && groundCheck.isGrounded == true)
        {
            if(Input.GetKey(KeyCode.LeftShift))
            {
                //Adds force to the hips to move player forward, speed * 1.5 if player is holding left shift
                RotationSingleton.Instance.hips.AddForce(RotationSingleton.Instance.hips.transform.forward * speed * 1.5f);
            }
            else
            {
                RotationSingleton.Instance.hips.AddForce(RotationSingleton.Instance.hips.transform.forward * speed);
            }
        }
        

        if (Input.GetKey(KeyCode.S) && groundCheck.isGrounded == true)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                //-hips to move player backwards
                RotationSingleton.Instance.hips.AddForce(-RotationSingleton.Instance.hips.transform.forward * speed * 1.5f);
            }
            else
            {
                RotationSingleton.Instance.hips.AddForce(-RotationSingleton.Instance.hips.transform.forward * speed);
            }
        }
    }
}
