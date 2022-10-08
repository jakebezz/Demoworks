using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private float rotation = 0;

    // Update is called once per frame
    void Update()
    {
        Vector3 rotationVector = transform.rotation.eulerAngles;
        rotationVector.y = rotation += 1f;
        transform.rotation = Quaternion.Euler(rotationVector);



    }
}
