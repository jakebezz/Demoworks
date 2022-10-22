using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveUpgrade : MonoBehaviour
{
    [SerializeField] private GameObject explosive;

    [SerializeField] private DropBomb dropBomb;

    //Use to hide pickup after it has been picked up
    [SerializeField] private MeshRenderer[] mesh;

    //Rotates upgrade
    void Update()
    {
        Vector3 rotationVector = transform.rotation.eulerAngles;
        rotationVector.y += 1f;
        transform.rotation = Quaternion.Euler(rotationVector);
    }

    //Adds the upgrade to list
    private void OnTriggerEnter(Collider other)
    {
        //Player can only get explosive if mesh is enabled
        if (other.tag == "Player" && mesh[0].enabled == true)
        {
            dropBomb.explosiveUpgrade.Add(explosive);
            
            foreach(MeshRenderer i in mesh)
            {
                i.enabled = false;
            }

            StartCoroutine(RespawnExplosive());
        }
    }

    //"Respawns" explosive after a set amount of seconds
    IEnumerator RespawnExplosive()
    {
        yield return new WaitForSeconds(6);
        foreach (MeshRenderer i in mesh)
        {
            i.enabled = true;
        }
    }
}
