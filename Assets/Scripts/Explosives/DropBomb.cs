using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBomb : MonoBehaviour
{
    [SerializeField] private GameObject landMine;
    [SerializeField] private GameObject grenade;

    public GameObject upgradedLandMine;
    public GameObject upgradedGrenade;

    [SerializeField] private GameObject spawnLocationLandmine;
    [SerializeField] private GameObject spawnLocationGrenade;

    [SerializeField] private AudioClip audioClipLauncher;
    [SerializeField] private AudioClip audioClipClang;

    //player ref
    [SerializeField] private GameObject character;

    //clone of either a landmine or grenade
    private GameObject clone;

    //cooldown for landmine
    private float landmineCoolDown = 0;
    private bool spacePressed = false;

    //cooldown for grenade
    private float grenadeCoolDown = 0;
    private bool bPressed = false;

    [SerializeField]
    private GameObject smoke;

    //List of upgrades player has
    public List<GameObject> explosiveUpgrade = new List<GameObject>();

    private void Start()
    { 
        //Stops smoke playing when starting game
        smoke.SetActive(false);
    }

    void Update()
    {
        //starts the cooldown for the landmine if space is pressed
        if (spacePressed)
        {
            landmineCoolDown -= Time.deltaTime;
            if(landmineCoolDown <= 0)
            {
                spacePressed = false;
                //Reset the smoke state so it can activate again
                smoke.SetActive(false);
            }
        }
        
        //starts the cooldown for the grenade if b is pressed
        if (bPressed)
        {
            grenadeCoolDown -= Time.deltaTime;
            if (grenadeCoolDown <= 0)
            {
                bPressed = false;
                smoke.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && spacePressed == false)
        {
            //cooldown length
            landmineCoolDown = 3;

            //creates upgraded landmine if one is in players inventory
            if (explosiveUpgrade.Count > 0 && explosiveUpgrade.Contains(upgradedLandMine))
            {
                clone = Instantiate(upgradedLandMine, new Vector3(spawnLocationLandmine.transform.position.x, spawnLocationLandmine.transform.position.y, spawnLocationLandmine.transform.position.z), new Quaternion(0, 0, 0, 0));
                explosiveUpgrade.Remove(upgradedLandMine);
            }
            else
            {
                //creates landmine
                clone = Instantiate(landMine, new Vector3(spawnLocationLandmine.transform.position.x, spawnLocationLandmine.transform.position.y, spawnLocationLandmine.transform.position.z), new Quaternion(0, 0, 0, 0));
            }

            AudioManager.Instance.PlaySoundAtPoint(audioClipLauncher, gameObject.transform.position);
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
            clone.GetComponent<Rigidbody>().AddForce(transform.forward * -400 + transform.up * 400);
            
            spacePressed = true;

            //Activates the smoke effect at the same postion the Landmine is launched from
            smoke.SetActive(true);
            smoke.transform.position = spawnLocationLandmine.transform.position;
        }

        else if (Input.GetKeyDown(KeyCode.B) && bPressed == false)
        {

            if (explosiveUpgrade.Contains(upgradedGrenade))
            {
                //creates upgraded grenade
                clone = Instantiate(upgradedGrenade, new Vector3(spawnLocationGrenade.transform.position.x, spawnLocationGrenade.transform.position.y, spawnLocationGrenade.transform.position.z), new Quaternion(0, 0, 0, 0));
                explosiveUpgrade.Remove(upgradedGrenade);
            }
            else
            {
                //creates grenade
                clone = Instantiate(grenade, new Vector3(spawnLocationGrenade.transform.position.x, spawnLocationGrenade.transform.position.y, spawnLocationGrenade.transform.position.z), new Quaternion(0, 0, 0, 0));
            }

            AudioManager.Instance.PlaySoundAtPoint(audioClipClang, gameObject.transform.position);
            //cooldown
            grenadeCoolDown = 3;
            bPressed = true;

            smoke.SetActive(true);
            smoke.transform.position = spawnLocationGrenade.transform.position;
        }
    }


}
