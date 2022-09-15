using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Green : MonoBehaviour
{
    public static bool yes;
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("GreenPull"))
        {
            yes = true;
        }
        else
            yes = false;
    }
}
