using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyMotion : MonoBehaviour
{
    [SerializeField] Transform targetLimb;
    [SerializeField] ConfigurableJoint joint;

    //Mirror to bool that reverse the target rotation if true
    [SerializeField] bool mirror;
    //Copy motion will only work if active is true, active is true if player is grounded 
    [SerializeField] bool active;

    //Ragdoll class and GroundChecker object used to get the isGrounded bool from Ragdoll class
    private Ragdoll ragdoll;
    [SerializeField] GameObject groundChecker;

    private void Start()
    {
        joint = GetComponent<ConfigurableJoint>();
        ragdoll = groundChecker.GetComponent<Ragdoll>();
    }

    void Update()
    {
        if(ragdoll.isGrounded == true)
        {
            active = true;
        }
        else
        {
            active = false;
        }

        if (active == true)
        {
            if (mirror == true)
            {
                joint.targetRotation = Quaternion.Inverse(targetLimb.rotation);
            }
            else
            {
                joint.targetRotation = targetLimb.rotation;
            }
        }
    }
}