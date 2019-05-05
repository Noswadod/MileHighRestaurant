using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PlateDelivery : MonoBehaviour
{

    private ArrayList collidingObjs;
    private ArrayList collidingObjsNames;

    void Start()
    {
        collidingObjs = new ArrayList();
        collidingObjsNames = new ArrayList();
    }

    public bool hasObj(string name)
    {
        print("CHECK OBJECTS");
        for ( int i = 0; i < collidingObjsNames.Count; i++)
        {
            if ( ((string)(collidingObjsNames[i])).Contains(name) )
            {
                return true;
            }
        }
        return false;
    }

    public GameObject getObj(string name)
    {
        print("GET OBJECTS");
        for (int i = 0; i < collidingObjsNames.Count; i++)
        {
            if (((string)(collidingObjsNames[i])).Contains(name))
            {
                return (GameObject) collidingObjs[i];
            }
           
        }
        return null;

    }

    void OnCollisionEnter(Collision col)
    {
        collidingObjs.Add(col.gameObject);
        collidingObjsNames.Add(col.gameObject.name);
    }

    void OnCollisionExit(Collision col)
    {
        collidingObjs.Remove(col.gameObject);
        collidingObjsNames.Remove(col.gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
           
    }
}
