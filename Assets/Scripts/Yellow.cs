using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yellow : MonoBehaviour
{
    public SoundManager sm;
    public Animator anm;
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("YellowPull") && Green.yes == true)
        {
            anm.SetBool("Open", true);
            Debug.Log("YEE");
            sm.OpenDoorSound();
        }
    }
}