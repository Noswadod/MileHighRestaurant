using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class BunTCombiner : MonoBehaviour
{

    public GameObject bunT;
    public GameObject bunLT;
    public GameObject bunTM;

    void OnCollisionEnter(Collision col)
    {
        Vector3 pos = bunT.transform.position;
        Quaternion rot = bunT.transform.rotation;

        print(col.gameObject.tag);

        if (col.gameObject.tag == "CutLettuce")
        {
            Destroy(col.gameObject);
            Instantiate(bunLT, pos, rot);
            Destroy(bunT);

        }
        else if (col.gameObject.tag == "MeatCooked")
        {
            Destroy(col.gameObject);
            Instantiate(bunTM, pos, rot);
            Destroy(bunT);
        }
    }
}
