using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosives : MonoBehaviour
{
    [SerializeField] public float radius = 0f;
    //Force of explosion
    [SerializeField] public float force = 0f;
    //Forces explosion up
    [SerializeField] public float upwardsModifier = 0f;

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

        //Remove grnade
        Destroy(gameObject);
    }
}
