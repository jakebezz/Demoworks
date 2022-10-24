using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //Audio clip instead of Audio source so that sound can be played when destroying coin
    [SerializeField] private AudioClip audioClip;

    [SerializeField] private PlayerController player;

    // Update is called once per frame
    void Update()
    {
        //rotates the coin in a smooth fashion
        Vector3 rotationVector = transform.rotation.eulerAngles;
        rotationVector.y += 1f;
        transform.rotation = Quaternion.Euler(rotationVector);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Head" || other.gameObject.tag == "Hips")
        {
            //Plays audioClip at the position of the coin
            AudioManager.Instance.PlaySoundAtPoint(audioClip, gameObject.transform.position);
            Destroy(gameObject);
            player.coins += 1;
        }
    }
}
