using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class BunCombining : MonoBehaviour
{

    public GameObject bun;
    public GameObject bunL;
    public GameObject bunT;
    public GameObject bunM;

    void OnCollisionEnter(Collision col)
    {
        Vector3 pos = bun.transform.position;
        Quaternion rot = bun.transform.rotation;

        print(col.gameObject.tag);

        if (col.gameObject.tag == "MeatCooked")
        {
            Destroy(col.gameObject);
            Instantiate(bunM, pos, rot);
            Destroy(bun);
           
        } else if(col.gameObject.tag == "CutTomato")
        {
            Destroy(col.gameObject);
            Instantiate(bunT, pos, rot);
            Destroy(bun);
        } else if( col.gameObject.tag == "CutLettuce")
        {
            Destroy(col.gameObject);
            Instantiate(bunL, pos, rot);
            Destroy(bun);
        }
    }
}
