using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public float distanceOffset;
    public float heightOffset;
    public float directionOffset;
    public Transform player;
    
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x + directionOffset, player.transform.position.y + heightOffset, player.transform.position.z + distanceOffset);
    }
}
