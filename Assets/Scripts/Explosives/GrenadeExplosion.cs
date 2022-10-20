using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeExplosion : Explosives
{
    //Stops player from being launched if out of range of grenade
    private bool playerInRange;

    [SerializeField] private AudioClip audioClipGrenageExp;
    private void Start()
    {
        playerInRange = false;
        countdown = delay;
    }

    void FixedUpdate()
    {
        //Starts countdown to explode
        countdown -= Time.deltaTime;

        if (countdown <= 0f && hasExploded == false)
        {
            if (playerInRange == true)
            {
                //Stops the player from being able to lauch backwards
                if (RotationManager.Instance.GetMousePosition().x < 0)
                {
                    RotationManager.Instance.hips.AddForce(Vector3.down * force, ForceMode.Impulse);
                }
                else
                {
                    //Adds force in the correct direction
                    RotationManager.Instance.hips.AddForce(RotationManager.Instance.GetMousePosition() * force, ForceMode.Impulse);
                }
            }

            AudioManager.Instance.PlaySoundAtPoint(audioClipGrenageExp, gameObject.transform.position);
            hasExploded = true;

            Destroy(gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
}
