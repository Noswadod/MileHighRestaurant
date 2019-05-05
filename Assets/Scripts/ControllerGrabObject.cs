using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ControllerGrabObject : MonoBehaviour
{
    public SteamVR_Input_Sources handType;  // Reference to handType
    public SteamVR_Behaviour_Pose controllerPose; 
    public SteamVR_Action_Boolean grabAction; // Reference to grab type

    private GameObject collidingObject; // Stores object trigger currently colliding with
    private GameObject objectInHand; // Reference to object player is currently grabbing

    public GameObject plate;
    public GameObject tomato;
    public GameObject lettuce;
    public GameObject meat;
    public GameObject bun;

    private ArrayList grabbedObjects = new ArrayList();// Recommended

    public GameObject getObjInHand()
    {
        print("getObjInHand");
        return objectInHand;
    }

    private void SetCollidingObject(Collider col)
    {
        // 1
        if (collidingObject || !col.GetComponent<Rigidbody>())
        {
            return;
        }
        // 2
        collidingObject = col.gameObject;
    }

    // When trigger collider enters another collider, set up other as potential grab target 
    public void OnTriggerEnter(Collider other)
    {
        SetCollidingObject(other);
    }

    // Ensures target is set when player holding controller over object for a while
    public void OnTriggerStay(Collider other)
    {
        SetCollidingObject(other);
    }

    // When collider exits an object, leaving ungrabbed target, removes the target
    public void OnTriggerExit(Collider other)
    {
        if (!collidingObject)
        {
            return;
        }

        collidingObject = null;
    }

    private void GrabObject()
    {
        // 1
        objectInHand = collidingObject;
        collidingObject = null;
        // 2

        grabbedObjects.Add(objectInHand);

        // Plate stack grabbed
        if ( objectInHand.tag == "PlateStack")
        {
            objectInHand = Instantiate(plate, objectInHand.transform.position, objectInHand.transform.rotation);
        }

        // Tomato stack grabbed
        if (objectInHand.tag == "TomatoStack")
        {
            objectInHand = Instantiate(tomato, objectInHand.transform.position, objectInHand.transform.rotation);
        }

        // Lettuce stack grabbed
        if (objectInHand.tag == "LettuceStack")
        {
            objectInHand = Instantiate(lettuce, objectInHand.transform.position, objectInHand.transform.rotation);
        }

        // Meat stack grabbed
        if (objectInHand.tag == "MeatStack")
        {
            objectInHand = Instantiate(meat, objectInHand.transform.position, objectInHand.transform.rotation);
        }

        // Bun stack grabbed
        if (objectInHand.tag == "BunStack")
        {
            objectInHand = Instantiate(bun, objectInHand.transform.position, objectInHand.transform.rotation);
        }

        var joint = AddFixedJoint();
        joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
    }

    // Makes a fixed joint to controller
    private FixedJoint AddFixedJoint()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 20000;
        fx.breakTorque = 20000;
        return fx;
    }

    // Removes grabbed object's fixed joint and controls speed when tossed away
    private void ReleaseObject()
    {
        for ( int i = 0; i < grabbedObjects.Count; i++ )
        {
            GameObject obj = (GameObject) grabbedObjects[i];

            // 1
            if (GetComponent<FixedJoint>())
            {
                // 2
                GetComponent<FixedJoint>().connectedBody = null;
                Destroy(GetComponent<FixedJoint>());
                // 3
                obj.GetComponent<Rigidbody>().velocity = controllerPose.GetVelocity();
                obj.GetComponent<Rigidbody>().angularVelocity = controllerPose.GetAngularVelocity();

            }

        }
        // 4
        //grabbedObjects.Clear();
        objectInHand = null;
    }

    // Update is called once per frame
    void Update()
    {
        //print("Current Obj in hand:" + objectInHand);
        // When player triggers Grab action
        if (grabAction.GetLastStateDown(handType))
        {
            if (collidingObject)
            {
                GrabObject();
            }
        }

        // If player releases input linked to Grab and object attached, release it
        if (grabAction.GetLastStateUp(handType))
        {
            if (objectInHand)
            {
                //print("RELEASES OBJ");
                ReleaseObject();
            }
        }

        
    }
}
