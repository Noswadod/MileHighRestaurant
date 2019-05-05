using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ObjectHitFloor : MonoBehaviour
{
   public AudioClip floorAudioNorm;
   public AudioClip floorAudioMetal;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag != "Knife" && col.gameObject.tag != "Pan" && col.gameObject.tag != "Pan2" && col.gameObject.tag != "Plate")
        {
            AudioSource.PlayClipAtPoint(floorAudioNorm, transform.position);
            
        } else
        {
            AudioSource.PlayClipAtPoint(floorAudioMetal, transform.position);
        }
      
   }
      


}
