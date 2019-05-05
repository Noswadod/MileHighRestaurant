using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class BunMCombiner : MonoBehaviour
{

    public GameObject bunM;
    public GameObject bunLM;
    public GameObject bunTM;

    void OnCollisionEnter(Collision col)
    {
        Vector3 pos = bunM.transform.position;
        Quaternion rot = bunM.transform.rotation;

        print(col.gameObject.tag);

        if (col.gameObject.tag == "CutLettuce")
        {
            Destroy(col.gameObject);
            Instantiate(bunLM, pos, rot);
            Destroy(bunM);

        }
        else if (col.gameObject.tag == "CutTomato")
        {
            Destroy(col.gameObject);
            Instantiate(bunTM, pos, rot);
            Destroy(bunM);
        }
    }
}
