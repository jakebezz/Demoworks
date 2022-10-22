using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandmineExplosion : Explosives
{
    private bool beginCountdown = false;
    [SerializeField] private AudioClip audioClipLandmineExp;

    private void Update()
    {
        // begins the countdown if the float is equal to the delay
        if(countdown == delay)
        {
            beginCountdown = true;
        }

        if (beginCountdown)
        {
            countDown();
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player" && beginCountdown == false)
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

    

    void countDown()
    {
        // timer
        countdown -= Time.deltaTime;

        if (countdown <= 0 && beginCountdown)
        {
            //explodes landmine
            Explode();
            AudioManager.Instance.PlaySoundAtPoint(audioClipLandmineExp, gameObject.transform.position);
            beginCountdown = false;
        }
    }

}
