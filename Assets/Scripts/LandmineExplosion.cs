using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandmineExplosion : Explosives
{

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Explode();
        }
    }
}
