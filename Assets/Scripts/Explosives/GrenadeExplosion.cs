using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeExplosion : Explosives
{

    private void Start()
    {
        countdown = delay;
    }

    void FixedUpdate()
    {
        //Starts countdown to explode
        countdown -= Time.deltaTime;

        if (countdown <= 0f && hasExploded == false)
        {
            //Adds force in the correct direction
            RotationSingleton.Instance.hips.AddForce(RotationSingleton.Instance.GetMousePosition() * force, ForceMode.Impulse);

            hasExploded = true;

            Destroy(gameObject);
        }
    } 
}
