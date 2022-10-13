using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeExplosion : Explosives
{
    public void Start()
    {
        //Sets countdown to delay
        countdown = delay;
    }

    void Update()
    {
        //Reduces by time between frame (1 second)
        countdown -= Time.deltaTime;
        //Explodes grenade
        if (countdown <= 0f && hasExploded == false)
        {
            Explode();
            hasExploded = true;
        }

    }
}
