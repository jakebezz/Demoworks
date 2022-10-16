using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnHead : MonoBehaviour
{
    [SerializeField] private float range;
    private void Update()
    {
        if (RotationSingleton.Instance.angle > -range && RotationSingleton.Instance.angle < range)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, RotationSingleton.Instance.angle));
        }
        //Stops the head rotating further than the range
        else if(RotationSingleton.Instance.angle <= -range + 1)
        {
            Debug.Log("Mouse Position: " + RotationSingleton.Instance.GetMousePosition());
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, -range + 1));
        }
        else if (RotationSingleton.Instance.angle >= range + 1)
        {
            Debug.Log("Mouse Position: " + RotationSingleton.Instance.GetMousePosition());
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, range));
        }
    }
}
