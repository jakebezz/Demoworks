using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyMotion : MonoBehaviour
{ 
    public Transform targetLimb;
    ConfigurableJoint joint;

    //Mirror to bool that reverse the target rotation if true
    public bool mirror;

    private void Start()
    {
        joint = GetComponent<ConfigurableJoint>();
    }

    void Update()
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
