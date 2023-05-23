using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    [SerializeField] private AudioClip flyClip, dieClip, pointClip;
    [SerializeField] private AudioSource audioSource;

    public void AudioFly()
    {
        audioSource.PlayOneShot(flyClip);
    }
    public void AudioDie()
    {
        audioSource.PlayOneShot(dieClip);
    }
    public void AudioPoint()
    {
        audioSource.PlayOneShot(pointClip);
    }

}
