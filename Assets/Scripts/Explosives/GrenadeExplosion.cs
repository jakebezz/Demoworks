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
            //Stops the player from being able to lauch backwards
            if (RotationSingleton.Instance.GetMousePosition().x < 0)
            {
                RotationSingleton.Instance.hips.AddForce(Vector3.down * force, ForceMode.Impulse);
            }
            else
            {
                //Adds force in the correct direction
                RotationSingleton.Instance.hips.AddForce(RotationSingleton.Instance.GetMousePosition() * force, ForceMode.Impulse);
            }

            hasExploded = true;
            Instantiate(explosionVFX, new Vector3(transform.position.x, transform.position.y, transform.position.z), new Quaternion(0, 0, 0, 0));
            Destroy(gameObject);
        }
    } 
}
