using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource clickSound;
    [SerializeField] AudioSource crunchSound;
    [SerializeField] AudioSource crushSound;
    [SerializeField] AudioSource fireBallSound;

    public void PlayClickSound()
    {
        clickSound.Play();
    }

    public void PlayCrunchSound()
    {
        crunchSound.Play();
    }

    public void PlayCrushSound()
    {
        crushSound.Play();
    }

    public void PlayFireballSound()
    {
        fireBallSound.Play();
    }
}
