using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnHead : MonoBehaviour
{
    [SerializeField] private float range;
    private void Update()
    {
        if (RotationManager.Instance.angle > -range && RotationManager.Instance.angle < range)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, RotationManager.Instance.angle));
        }
        //Stops the head rotating further than the range
        else if(RotationManager.Instance.angle <= -range + 1)
        { 
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, -range + 1));
        }
        else if (RotationManager.Instance.angle >= range + 1)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, range));
        }
    }
}
