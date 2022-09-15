using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorMix : MonoBehaviour
{

    private bool correctMix;
    public Animator anim;
    private int red, blue;
    public SoundManager sm;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Red"))
        {
            red = 1;
            sm.PressSound();

            if (red == 1 && blue == 1)
            {
                anim.SetBool("OpenPurple", true);
                sm.OpenDoorSound();
                red = 0;
                blue = 0;
            }
        }
        if (collision.gameObject.CompareTag("Blue"))
        {
            blue = 1;
            sm.PressSound();
            if (red == 1 && blue == 1)
            {
                anim.SetBool("OpenPurple", true);
                sm.OpenDoorSound();
                red = 0;
                blue = 0;
            }
        }
        if (collision.gameObject.CompareTag("Other"))
        {
            sm.WrongSound();
            red = 0;
            blue = 0;
        }
    }
}
