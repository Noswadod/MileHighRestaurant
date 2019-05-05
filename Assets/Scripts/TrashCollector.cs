using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class TrashCollector : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag != "DoNotDelete" && col.gameObject.tag != "Pan" && col.gameObject.tag != "Pan2" && col.gameObject.tag != "Knife")
        {
            Destroy(col.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
