using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeExplosion : Explosives
{
    //Time it takes for grenade to explode
    [SerializeField] private float delay = 0f;

    //Used to actually delay the explosion
    private float countdown;
    private bool hasExploded = false;

    void Start()
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
