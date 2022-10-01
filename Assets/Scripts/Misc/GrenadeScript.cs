using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeScript : MonoBehaviour
{
    //Time it takes for grenade to explode
    public float delay = 3f;
    //Radius of explosion
    public float radius = 5f;
    //Force of explosion
    public float force = 700f;

    public float upwardsModifier = 3f;

    //Used to actually delay the explosion
    float countdown;
    bool hasExploded = false;

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

    void Explode()
    {
        //Get nearby object + add force + damage
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();

            //Adds force to the nearby objects
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius, upwardsModifier);
            }
        }

        //Remove grnade
        Destroy(gameObject);
    }
}
