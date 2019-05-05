using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class BunLCombiner : MonoBehaviour
{

    public GameObject bunL;
    public GameObject bunLM;
    public GameObject bunLT;

    void OnCollisionEnter(Collision col)
    {
        Vector3 pos = bunL.transform.position;
        Quaternion rot = bunL.transform.rotation;

        print(col.gameObject.tag);

        if (col.gameObject.tag == "MeatCooked")
        {
            Destroy(col.gameObject);
            Instantiate(bunLM, pos, rot);
            Destroy(bunL);

        }
        else if (col.gameObject.tag == "CutTomato")
        {
            Destroy(col.gameObject);
            Instantiate(bunLT, pos, rot);
            Destroy(bunL);
        }
    }
}
