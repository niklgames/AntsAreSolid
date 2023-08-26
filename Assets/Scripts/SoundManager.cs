using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource clickSound;
    [SerializeField] AudioSource crunchSound;

    public void PlayClickSound()
    {
        clickSound.Play();
    }

    public void PlayCrunchSound()
    {
        crunchSound.Play();
    }
}
