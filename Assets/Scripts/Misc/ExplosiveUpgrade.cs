using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveUpgrade : MonoBehaviour
{
    [SerializeField] private GameObject explosive;

    [SerializeField] private DropBomb dropBomb;

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
        if (other.tag == "Player")
        {
            dropBomb.explosiveUpgrade.Add(explosive);
            Destroy(gameObject);
        }
    }
}
