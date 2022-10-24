using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandmineExplosion : Explosives
{
    private bool beginCountdown = false;

    private void Update()
    {
        // begins the countdown if the float is equal to the delay
        if(countdown == delay)
        {
            beginCountdown = true;
        }

        if (beginCountdown)
        {
            CountDown();
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if((collision.gameObject.tag == "Player" || collision.gameObject.tag == "Head" || collision.gameObject.tag == "Hips") && beginCountdown == false)
        {
            // countdown begins if theres a collision with player
            countdown = delay;
        }
        
        //Sets isKinematic to true when touching the ground, stops the player from accidently pushing it with feet
        if(collision.gameObject.tag == "Ground")
        {
            Rigidbody rb = GetComponent<Rigidbody>();

            rb.isKinematic = true;
        }
    }

    

    void CountDown()
    {
        // timer
        countdown -= Time.deltaTime;

        if (countdown <= 0 && beginCountdown)
        {
            //explodes landmine
            Explode();
            AudioManager.Instance.PlaySoundAtPoint(explosionSound, gameObject.transform.position);
            beginCountdown = false;
        }
    }

}
