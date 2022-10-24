using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnHead : MonoBehaviour
{
    [SerializeField] private float range;
    [SerializeField] private float angle;

    public Rigidbody head;

    private void Start()
    {
        head = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //Calculates the rotation angle
        angle = Mathf.Atan2(GetMousePosition().y, GetMousePosition().x) * Mathf.Rad2Deg;

        if (angle > -range && angle < range)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
        //Stops the head rotating further than the range
        else if(angle <= -range + 1)
        { 
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, -range + 1));
        }
        else if (angle >= range + 1)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, range));
        }
    }

    public Vector3 GetMousePosition()
    {
        Vector3 worldPosition = new Vector3(0, 0, 0);
        //Set the screen position to the Vector 3 mouse position
        Vector3 screenPosition = Input.mousePosition;

        LayerMask layerMask = LayerMask.GetMask("MouseLayer");

        //Raycast to mouse position
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        //If the mouse hits the layerMask
        if (Physics.Raycast(ray, out RaycastHit hit, layerMask))
        {
            //Sets worldPosition to the hit point
            worldPosition = hit.point;

            Debug.DrawRay(worldPosition, hit.point, Color.red);
        }

        //Finds the direction that force will be added by fidning the difference between worldPosition and the players position
        Vector3 direction = worldPosition - head.transform.position;
        //Basically calucualtes the direction the player needs to go by normalizing it, making the vector have a magnitude of one and essentially stops the player from lauching miles into the sky when exploding from the grenade
        direction = direction.normalized;

        return direction;
    }
}

