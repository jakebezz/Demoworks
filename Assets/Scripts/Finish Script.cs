using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishScript : MonoBehaviour
{
    public GameObject finishUI;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            finishUI.SetActive(true);
        }
    }
}
