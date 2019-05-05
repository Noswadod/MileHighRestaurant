using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


public class ObjectsOnPlate : MonoBehaviour
{

    private GameObject objOnPlate;


    public GameObject getObjOnPlate()
    {
        return objOnPlate;
    }

    // When plate collides with something
    void OnCollisionEnter(Collision col)
    {
        //print("ENTER" + col.gameObject);
        if (col.gameObject.tag != "PlateDontTouch" && (col.gameObject.tag == "Bun" || col.gameObject.tag == "BunLT" || col.gameObject.tag == "BunLM" || col.gameObject.tag == "BunTM" ||
            col.gameObject.tag == "CutLettuce" || col.gameObject.tag == "MeatBurnt" || col.gameObject.tag == "MeatCooked" || col.gameObject.tag == "MeatRaw" || col.gameObject.tag == "CutTomato"))
        {
            if (col.gameObject != null)
            {
                objOnPlate = col.gameObject;
            }
        }

    }

    // When plate collides with something
    /*void OnCollisionStay(Collision col)
    {
        //print("STAY" + col.gameObject);
        
        if (col.gameObject.tag == "Bun" || col.gameObject.tag == "BunLT" || col.gameObject.tag == "BunLM" || col.gameObject.tag == "BunTM" ||
            col.gameObject.tag == "CutLettuce" || col.gameObject.tag == "MeatBurnt" || col.gameObject.tag == "MeatCooked" || col.gameObject.tag == "MeatRaw" || col.gameObject.tag == "CutTomato")
        {

            objOnPlate = col.gameObject;
        }
        
        if (col.gameObject.tag != "PlateDontTouch" && (col.gameObject.tag == "Bun" || col.gameObject.tag == "BunLT" || col.gameObject.tag == "BunLM" || col.gameObject.tag == "BunTM" ||
        col.gameObject.tag == "CutLettuce" || col.gameObject.tag == "MeatBurnt" || col.gameObject.tag == "MeatCooked" || col.gameObject.tag == "MeatRaw" || col.gameObject.tag == "CutTomato"))
        {
            if (col.gameObject != null)
            {
                objOnPlate = col.gameObject;
            }
        }


    }*/

    // When meat stops colliding with something
    void OnCollisionExit(Collision col)
    {
        //print("EXIT");
        if (col.gameObject.tag != "PlateDontTouch" && (col.gameObject.tag == "Bun" || col.gameObject.tag == "BunLT" || col.gameObject.tag == "BunLM" || col.gameObject.tag == "BunTM" ||
            col.gameObject.tag == "CutLettuce" || col.gameObject.tag == "MeatBurnt" || col.gameObject.tag == "MeatCooked" || col.gameObject.tag == "MeatRaw" || col.gameObject.tag == "CutTomato"))
        {
            if (!LaserPointerLeft.isTeleporting && !LaserPointerRight.isTeleporting)
            {
                objOnPlate = null;
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (objOnPlate != null)
        {
            print(objOnPlate.name);
        }
    }
}
