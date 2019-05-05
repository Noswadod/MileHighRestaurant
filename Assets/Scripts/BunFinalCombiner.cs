using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class BunFinalCombiner : MonoBehaviour
{

    public GameObject bun;
    public GameObject bunFinished;

    void OnCollisionEnter(Collision col)
    {
        Vector3 pos = bun.transform.position;
        Quaternion rot = bun.transform.rotation;

        print(col.gameObject.tag);

        if (bun.gameObject.tag == "BunTM" && col.gameObject.tag == "CutLettuce")
        {
            Destroy(col.gameObject);
            Instantiate(bunFinished, pos, rot);
            Destroy(bun);

        }
        else if (bun.gameObject.tag == "BunLM" && col.gameObject.tag == "CutTomato")
        {
            Destroy(col.gameObject);
            Instantiate(bunFinished, pos, rot);
            Destroy(bun);
        } else if( bun.gameObject.tag == "BunLT" && col.gameObject.tag == "MeatCooked")
        {
            Destroy(col.gameObject);
            Instantiate(bunFinished, pos, rot);
            Destroy(bun);
        }
    }
}
