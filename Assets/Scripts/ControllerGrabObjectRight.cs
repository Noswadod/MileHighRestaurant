using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ControllerGrabObjectRight : MonoBehaviour
{
    public SteamVR_Input_Sources handType;  // Reference to handType
    public SteamVR_Behaviour_Pose controllerPose; 
    public SteamVR_Action_Boolean grabAction; // Reference to grab type

    private GameObject collidingObject; // Stores object trigger currently colliding with
    public static GameObject objectInHand; // Reference to object player is currently grabbing

    public SteamVR_Action_Vibration hapticAction;

    public GameObject plate;
    public GameObject tomato;
    public GameObject lettuce;
    public GameObject meat;
    public GameObject bun;
    public GameObject knife;

    public AudioClip grabSoundNorm;
    public AudioClip grabSoundMetal;

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

        if (objectInHand.tag != "Knife" && objectInHand.tag != "Pan" && objectInHand.tag != "Pan2" && objectInHand.tag != "Plate")
        {
            AudioSource.PlayClipAtPoint(grabSoundNorm, transform.position);
        }
        else
        {
            AudioSource.PlayClipAtPoint(grabSoundMetal, transform.position);
        }

        hapticAction.Execute(0f, 0.1f, 160, 0.5f, SteamVR_Input_Sources.RightHand);

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

        // Knife stack grabbed
        if (objectInHand.tag == "KnifeDispenser")
        {
            print("KNIFE GRAB");
            Vector3 pos = objectInHand.transform.position;
            pos.y = pos.y + 0.5f;
            objectInHand = Instantiate(knife, objectInHand.transform.position, objectInHand.transform.rotation);
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
        
            // 1
            if (GetComponent<FixedJoint>())
            {
                // 2
                GetComponent<FixedJoint>().connectedBody = null;
                Destroy(GetComponent<FixedJoint>());
                // 3
                GetComponent<Rigidbody>().velocity = controllerPose.GetVelocity();
                GetComponent<Rigidbody>().angularVelocity = controllerPose.GetAngularVelocity();

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
            if (gameObject.GetComponent<FixedJoint>())
            {
                Destroy(gameObject.GetComponent<FixedJoint>());
            }

            if (objectInHand)
            {
                //print("RELEASES OBJ");
                ReleaseObject();
            }
        }

        
    }
}
