using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeExplosion : Explosives
{
    //Stops player from being launched if out of range of grenade
    private bool playerInRange;

    [SerializeField] private AudioClip audioClipGrenageExp;

    private GameObject[] playerHead;
    private TurnHead turnHead;
    private GameObject[] playerHips;
    private PlayerController player;

    private void Start()
    {
        playerInRange = false;
        countdown = delay;

        playerHead = GameObject.FindGameObjectsWithTag("Head");
        turnHead = playerHead[0].GetComponent<TurnHead>();

        playerHips = GameObject.FindGameObjectsWithTag("Hips");
        player = playerHips[0].GetComponent<PlayerController>();
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
                if (turnHead.GetMousePosition().x < 0)
                {
                    player.hips.AddForce(Vector3.down * force, ForceMode.Impulse);
                }
                else
                {
                    //Adds force in the correct direction
                    player.hips.AddForce(turnHead.GetMousePosition() * force, ForceMode.Impulse);
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
