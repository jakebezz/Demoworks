using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBomb : MonoBehaviour
{
    [SerializeField] private GameObject landMine;
    [SerializeField] private GameObject grenade;

    [SerializeField] private GameObject spawnLocationLandmine;
    [SerializeField] private GameObject spawnLocationGrenade;
   
    //player ref
    public GameObject character;

    //clone of either a landmine or grenade
    private GameObject clone;

    //cooldown for landmine
    private float landmineCoolDown = 0;
    private bool spacePressed = false;

    //cooldown for grenade
    private float grenadeCoolDown = 0;
    private bool bPressed = false;

    [SerializeField] GameObject playerObj;

    void Update()
    {
        //starts the cooldown for the landmine if space is pressed
        if (spacePressed)
        {
            landmineCoolDown -= Time.deltaTime;
            if(landmineCoolDown <= 0)
            {
                spacePressed = false;
            }
        }
        
        //starts the cooldown for the grenade if b is pressed
        if (bPressed)
        {
            grenadeCoolDown -= Time.deltaTime;
            if (grenadeCoolDown <= 0)
            {
                bPressed = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && spacePressed == false)
        {
            //cooldown length
            landmineCoolDown = 3;

            //creates landmine
            clone = Instantiate(landMine, new Vector3(spawnLocationLandmine.transform.position.x, spawnLocationLandmine.transform.position.y, spawnLocationLandmine.transform.position.z), new Quaternion(0, 0, 0, 0));
           
            // get player velocity
            Vector3 playerVelocity = character.GetComponent<Rigidbody>().velocity;

            /* this will match the landmine's velocity to the player's,
            * 
            * this makes it so the landmine will keep up with the player if they are running.
            * 
            * without this, the landmine would simply fly backwards and wont go over the player's head.
            */
            clone.GetComponent<Rigidbody>().velocity = playerVelocity;

            //adds a force to arch the landmine up and over the player
            clone.GetComponent<Rigidbody>().AddForce(transform.right * 500 + transform.up * 500);
            
            spacePressed = true;
        }

        else if (Input.GetKeyDown(KeyCode.B) && bPressed == false)
        {
            //creates grenade
            clone = Instantiate(grenade, new Vector3(spawnLocationGrenade.transform.position.x, spawnLocationGrenade.transform.position.y, spawnLocationGrenade.transform.position.z), new Quaternion(0, 0, 0, 0));
            //cooldown
            grenadeCoolDown = 3;
            bPressed = true;
        }
    }

    void help()
    {

    }
}
