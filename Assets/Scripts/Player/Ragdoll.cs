using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    //array for all the joints that is used to make the player ragdoll
    [SerializeField] private ConfigurableJoint[] ragdollJoints = new ConfigurableJoint[] {};

    [SerializeField] private JointDrive joint;

    //Used to change the value of angularXDrive while player is in air, used in inspector for testing purposes
    [SerializeField] private float xDriveAmount;

    //bool for determining whether player is on the ground
    public bool isGrounded = true;

    //Audio Controll
    public AudioClip[] audioClip;


    void FixedUpdate()
    {
        if (isGrounded == false)
        {
            foreach (ConfigurableJoint Rjoint in ragdollJoints)
            {
                //if the player is off the ground, every limb in the array will ragdoll
                joint = Rjoint.angularXDrive;
                //Changed value from 0, should improve how the player stands up after launching
                joint.positionSpring = xDriveAmount;
                Rjoint.angularXDrive = joint;
            }
        }
        else
        {
            foreach (ConfigurableJoint Rjoint in ragdollJoints)
            {
                //if the player is grounded, limbs return to normal
                joint = Rjoint.angularXDrive;
                if(Rjoint.name == "Hips")
                {
                    joint.positionSpring = 750f;
                }
                else
                {
                    joint.positionSpring = 180f;
                }
                
                Rjoint.angularXDrive = joint;
            }
        }
    }
    //Changed to OnTriggerStay, should stop bug that stopped player standing up
    private void OnTriggerStay(Collider other)
    {
        //collision with ground
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //off the ground
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = false;
            PlaySound();
        }
    }

    void PlaySound()
    {
        int rng = Random.Range(0, 6);
        AudioManager.Instance.PlaySound(audioClip[rng]);
    }
}
