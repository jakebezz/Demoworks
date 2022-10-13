using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NEWTEMPGRENADESCRIPT : Explosives
{
    [SerializeField] private Vector3 mousePos;
    [SerializeField] private Rigidbody playerRigid;
    [SerializeField] private GameObject playerObj;
    
    private void Start()
    {
        hasExploded = false;
        playerRigid = playerObj.transform.GetChild(0).gameObject.GetComponent<Rigidbody>();

        Debug.Log("Child: " + playerRigid.name);

        countdown = delay;
    }

    void Update()
    {
        mousePos = Input.mousePosition;
        mousePos.z = 10f;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        countdown -= Time.deltaTime;
        if (countdown <= 0f && hasExploded == false)
        {
            playerRigid.AddForce(mousePos * force, ForceMode.Impulse);
            hasExploded = true;

            Destroy(gameObject);
        }
    }
}
