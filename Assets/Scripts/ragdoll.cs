using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ragdoll : MonoBehaviour
{
    public ConfigurableJoint ragdollJoint;
    public JointDrive joint;
    [SerializeField]private bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded == false)
        {
            joint = ragdollJoint.angularXDrive;
            joint.positionSpring = 0f;
            ragdollJoint.angularXDrive = joint;
        }
    }

    void OnCollisionEnter(Collision collisioninfo)
    {
        if (collisioninfo.gameObject.tag =="Ground")
        {
            isGrounded = true;
        }
        
    }

    private void OnCollisionExit(Collision collisioninfo)
    {
        if (collisioninfo.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
