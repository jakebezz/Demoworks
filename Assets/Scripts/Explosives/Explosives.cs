using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosives : MonoBehaviour
{
    public float radius = 0f;
    //Force of explosion
    public float force = 0f;
    //Forces explosion up
    public float upwardsModifier = 0f; 
    //Time it takes for explosive to explode
    public  float delay = 0f;
    
    //Used to actually delay the explosion
    public float countdown;
    public bool hasExploded = false;
    

    public void Explode()
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

        //Remove explosive
        Destroy(gameObject);
    }
}
