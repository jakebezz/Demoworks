using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandmineExplosion : Explosives
{
    private bool beginCountdown = false;

    private void Update()
    {
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
            countdown = delay;
        }
    }

    void countDown()
    {
        countdown -= Time.deltaTime;

        if (countdown <= 0 && beginCountdown)
        {
            Explode();
            beginCountdown = false;
        }
    }

}
