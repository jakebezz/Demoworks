using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public AudioClip[] audioClip;

    //Needed to check if player is grounded, if not the sound will play
    Ragdoll ragdoll;
    [SerializeField]GameObject groundChecker;


    void Start()
    {
        ragdoll = groundChecker.GetComponent<Ragdoll>();
    }

    private void OnCollisionExit(Collision collision)
    {
        
    }

    void Update()
    {
        //This didnt work when it was set to false, not sure why
        if(groundChecker)
        {
            PlaySound();
        }
    }

    void PlaySound()
    {
        int rng = Random.Range(0, 6);
        AudioManager.Instance.PlaySound(audioClip[rng]);
    }
}
