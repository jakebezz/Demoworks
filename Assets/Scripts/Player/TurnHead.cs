using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnHead : MonoBehaviour
{
    private Vector3 mousePos;
    private Vector3 headPos;
    private float angle;
    public float range;

    

    private void Update()
    {
        mousePos = Input.mousePosition;
        mousePos.z = 10f;

        headPos = Camera.main.WorldToScreenPoint(transform.position);
        //Even though we are just rotating the Y axis we still need to include the x here otherwise it does some very funky stuff
        mousePos.x = mousePos.x - headPos.x;
        mousePos.y = mousePos.y - headPos.y;

        angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        if (angle > -range && angle < range)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
        else if(angle <= -range + 1)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, -range + 1));
        }
        else if (angle >= range + 1)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, range));
        }
    }
}
