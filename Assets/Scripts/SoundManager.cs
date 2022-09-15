using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip openDoor, press, wrong, winSound;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

public void OpenDoorSound()
    {
        audioSource.PlayOneShot(openDoor);
    }

    public void PressSound()
    {
        audioSource.PlayOneShot(press);
    }

    public void WrongSound()
    {
        audioSource.PlayOneShot(wrong);
    }

    public void WinSound()
    {
        audioSource.PlayOneShot(winSound);
    }
}
