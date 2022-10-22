 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public PlayerController player;
    //Will be set by an empty object
    [SerializeField] private Transform respawn;
    private void OnTriggerEnter(Collider other)
    {
        //If player touches checkpoint, set checkpoint to respawn point
        if (other.tag == "Player")
        {
            player.respawnPoint = respawn;
        }
    }
}
