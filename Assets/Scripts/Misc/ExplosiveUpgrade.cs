using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ExplosiveUpgrade : MonoBehaviour
{
    [SerializeField] private GameObject explosive;

    [SerializeField] private DropBomb dropBomb;

    //Use to hide pickup after it has been picked up is array because the model has multiple parts
    [SerializeField] private MeshRenderer[] mesh;

    [SerializeField] private float timeLeft = 6;
    private bool activeTimer = false;

    [SerializeField] private TextMeshPro timerText;

    private void Start()
    {
        //Hides the text on start
        timerText.enabled = false;
    }

    void Update()
    {
        //Roatates object
        Vector3 rotationVector = transform.rotation.eulerAngles;
        rotationVector.y += 1f;
        transform.rotation = Quaternion.Euler(rotationVector);

        if (activeTimer == true)
        {
            //Shows text
            timerText.enabled = true;

            //Countdown
            if (timeLeft > 0)
            {
                //Counts down and rounds number to int then coverts to string 
                timeLeft -= Time.deltaTime;
                timerText.text = Mathf.RoundToInt(timeLeft).ToString();
            }
            else
            {
                //"Respawns" explosive after a set amount of seconds
                foreach (MeshRenderer i in mesh)
                {
                    i.enabled = true;
                }

                //Reset variables
                timeLeft = 6;
                activeTimer = false;
                timerText.enabled = false;
            }
        }
    }

    //Adds the upgrade to list
    private void OnTriggerEnter(Collider other)
    {
        //Player can only get explosive if mesh is enabled
        if ((other.tag == "Player" || other.tag == "Hips" || other.tag == "Head") && mesh[0].enabled == true)
        {
            dropBomb.explosiveUpgrade.Add(explosive);

            foreach (MeshRenderer i in mesh)
            {
                i.enabled = false;
            }
            //Starts timer
            activeTimer = true;
        }
    }
}
