using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBomb : MonoBehaviour
{
    [SerializeField] private GameObject landMine;
    [SerializeField] private GameObject grenade;
    [SerializeField] private GameObject spawnLocationLandmine;
    [SerializeField] private GameObject spawnLocationGrenade;
    [SerializeField] private GameObject character;
    private GameObject clone;

    private void Start()
    {
        
    }
    void Update()
    {
    
        if (Input.GetKeyDown(KeyCode.Space))
        {
            clone = Instantiate(landMine, new Vector3(spawnLocationLandmine.transform.position.x, spawnLocationLandmine.transform.position.y, spawnLocationLandmine.transform.position.z), new Quaternion(0, 0, 0, 0));
            clone.GetComponent<Rigidbody>().AddForce(transform.right * 500);
            clone.GetComponent<Rigidbody>().AddForce(transform.up * 500);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            clone = Instantiate(grenade, new Vector3(spawnLocationGrenade.transform.position.x, spawnLocationGrenade.transform.position.y, spawnLocationGrenade.transform.position.z), new Quaternion(0, 0, 0, 0));
        }


    }
}
