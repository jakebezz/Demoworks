using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeExplosion : MonoBehaviour
{
    //Time it takes for grenade to explode
    [SerializeField] private float delay = 0f;
    //Radius of explosion
    [SerializeField] private float radius = 0f;
    //Force of explosion
    [SerializeField] private float force = 0f;
    //Forces explosion up
    [SerializeField] private float upwardsModifier = 0f;

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
