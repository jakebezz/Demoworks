using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ragdoll : MonoBehaviour
{
    //array for all the joints that is used to make the player ragdoll
    public ConfigurableJoint[] ragdollJoints = new ConfigurableJoint[] {};

    public JointDrive joint;

    //bool for determining whether player is on the ground
    private bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (isGrounded == false)
        {
            foreach (ConfigurableJoint Rjoint in ragdollJoints)
            {
                //if the player is off the ground, every limb in the array will ragdoll
                joint = Rjoint.angularXDrive;
                joint.positionSpring = 0f;
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

    void OnCollisionEnter(Collision collisioninfo)
    {
        //collision with ground
        if (collisioninfo.gameObject.tag =="Ground")
        {
            isGrounded = true;
        }
        
    }

    private void OnCollisionExit(Collision collisioninfo)
    {
        //off the ground
        if (collisioninfo.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
