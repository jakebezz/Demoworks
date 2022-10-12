using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
  

    //Audio clip instead of Audio source so that sound can be played when destroying coin
    [SerializeField] private AudioClip audioClip;

    // Update is called once per frame
    void Update()
    {
        Vector3 rotationVector = transform.rotation.eulerAngles;
        rotationVector.y += 1f;
        transform.rotation = Quaternion.Euler(rotationVector);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Plays audioClip at the position of the coin
            AudioSource.PlayClipAtPoint(audioClip, transform.position);
            Destroy(gameObject);
        }
    }
}
