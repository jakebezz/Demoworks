using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBomb : MonoBehaviour
{
    [SerializeField] private GameObject landMine;
    [SerializeField] private GameObject grenade;
    [SerializeField] private GameObject spawnLocationLandmine;
    [SerializeField] private GameObject spawnLocationGrenade;
    public GameObject character;

    //For Testing
    [SerializeField] private GameObject tempGrenade;


    private GameObject clone;

    private float coolDown = 0;
    private bool pressed = false;
    
    [SerializeField] GameObject playerObj;

    private void Start()
    {
        
    }

    void Update()
    {
        
       

        
        if (pressed == true)
        {
            coolDown -= Time.deltaTime;
            if(coolDown <= 0)
            {
                pressed = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && pressed == false)
        {
            Vector3 playerVelocity = character.GetComponent<Rigidbody>().velocity;
            coolDown = 3;
            clone = Instantiate(landMine, new Vector3(spawnLocationLandmine.transform.position.x, spawnLocationLandmine.transform.position.y, spawnLocationLandmine.transform.position.z), new Quaternion(0, 0, 0, 0));
            clone.GetComponent<Rigidbody>().velocity = playerVelocity;
            clone.GetComponent<Rigidbody>().AddForce(transform.right * 500 + transform.up * 500);
            
            pressed = true;
        }
        else if (Input.GetKeyDown(KeyCode.B) && pressed == false)
        {
            clone = Instantiate(grenade, new Vector3(spawnLocationGrenade.transform.position.x, spawnLocationGrenade.transform.position.y, spawnLocationGrenade.transform.position.z), new Quaternion(0, 0, 0, 0));
            coolDown = 3;
            pressed = true;
        }
        else if(Input.GetKeyDown(KeyCode.K) && pressed == false)
        {
            clone = Instantiate(tempGrenade, new Vector3(spawnLocationGrenade.transform.position.x, spawnLocationGrenade.transform.position.y, spawnLocationGrenade.transform.position.z), new Quaternion(0, 0, 0, 0));
        }
    }
}
