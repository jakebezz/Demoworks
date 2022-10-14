using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] private float distanceOffset;
    [SerializeField] private float heightOffset;
    [SerializeField] private float directionOffset;
    [SerializeField] private Transform player;
    
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x + directionOffset, player.transform.position.y + heightOffset, player.transform.position.z + distanceOffset);
    }
}
