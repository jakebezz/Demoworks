using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeExplosion : Explosives
{
    //Variables for getting and coverting mouse position
    private Vector3 screenPosition;
    private Vector3 worldPosition;
    //LayerMask to be hit by mouse, set this to MouseLayer if it has been reset
    [SerializeField] private LayerMask layerMask;

    private void Start()
    {
        countdown = delay;
    }

    void FixedUpdate()
    {
        //Set the screen position to the Vector 3 mouse position
        screenPosition = Input.mousePosition;

        //Raycast to mouse position
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        //If the mouse hits the layerMask
        if (Physics.Raycast(ray, out RaycastHit hit, layerMask))
        {
            //Sets worldPosition to the hit point
            worldPosition = hit.point;
        }

        //Starts countdown to explode
        countdown -= Time.deltaTime;

        if (countdown <= 0f && hasExploded == false)
        {
            //Finds the direction that force will be added by fidning the difference between worldPosition and the players position
            Vector3 direction = worldPosition - PlayerController.hips.transform.position;
            //Basically calucualtes the direction the player needs to go by normalizing it, not %100 sure how it works but it works
            direction = direction.normalized;

            //Adds force in the correct direction
            PlayerController.hips.AddForce(direction * force, ForceMode.Impulse);

            hasExploded = true;

            Destroy(gameObject);
        }
    }
}
