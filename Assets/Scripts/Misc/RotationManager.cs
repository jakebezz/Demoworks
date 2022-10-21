using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationManager : MonoBehaviour
{
    public static RotationManager Instance;

    public float angle;
    public Rigidbody head;
    public Rigidbody hips;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        head = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //Calculates the rotation angle
        angle = Mathf.Atan2(GetMousePosition().y, GetMousePosition().x) * Mathf.Rad2Deg;
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
        //Basically calucualtes the direction the player needs to go by normalizing it, not %100 sure how it works but it works
        direction = direction.normalized;

        return direction;
    }
}
