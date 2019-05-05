using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PanOnStove : MonoBehaviour
{
    public static bool onStove1;
    public static bool onStove2;

    public GameObject pan;

    // When meat collides with something
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Stove")
        {
            if ( pan.tag == "Pan")
            {
                onStove1 = true;
            } else
            {
                onStove2 = true;
            }
           
        }
    }

    // When meat stops colliding with something
    void OnCollisionExit(Collision col)
    {
       
        if (col.gameObject.tag == "Stove")
        {
       
            if (pan.tag == "Pan")
            {
                onStove1 = false;
            }
            else
            {
                onStove2 = false;
            }
        }
    }

}
