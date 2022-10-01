using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBomb : MonoBehaviour
{
    public GameObject bomb;
    public GameObject spawnLocation;
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            Instantiate(bomb, new Vector3(spawnLocation.transform.position.x, spawnLocation.transform.position.y, spawnLocation.transform.position.z), new Quaternion(0, 0, 0, 0));
            
        }
       
    }
}
