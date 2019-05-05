using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LaserPointerRight : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean teleportAction;

    public GameObject controller;

    public GameObject laserPrefab; // 1
    private GameObject laser; // 2
    private Transform laserTransform; // 3
    private Vector3 hitPoint; // 4

    public static bool isTeleporting = false; // *****ADDED

    // 1
    public Transform cameraRigTransform;
    // 2
    public GameObject teleportReticlePrefab;
    // 3
    private GameObject reticle;
    // 4
    private Transform teleportReticleTransform;
    // 5
    public Transform headTransform;
    // 6
    public Vector3 teleportReticleOffset;
    // 7
    public LayerMask teleportMask;
    // 8
    private bool shouldTeleport;

    // Start is called before the first frame update
    void Start()
    {
        // 1
        laser = Instantiate(laserPrefab);
        // 2
        laserTransform = laser.transform;

        // 1
        reticle = Instantiate(teleportReticlePrefab);
        // 2
        teleportReticleTransform = reticle.transform;
    }

    // Update is called once per frame
    void Update()
    {
        // 1
        if (teleportAction.GetState(handType))
        {
            RaycastHit hit;

            // 2
            if (Physics.Raycast(controllerPose.transform.position, transform.forward, out hit, 100, teleportMask))
            {
                hitPoint = hit.point;
                ShowLaser(hit);

                // 1
                reticle.SetActive(true);
                // 2
                teleportReticleTransform.position = hitPoint + teleportReticleOffset;
                // 3
                shouldTeleport = true;
            }
        }
        else // 3
        {
            laser.SetActive(false);

            reticle.SetActive(false);
        }

        if (teleportAction.GetStateUp(handType) && shouldTeleport)
        {
            isTeleporting = true; // *****ADDED
            Teleport();
        }
    }

    private void ShowLaser(RaycastHit hit)
    {
        // 1
        laser.SetActive(true);
        // 2
        laserTransform.position = Vector3.Lerp(controllerPose.transform.position, hitPoint, .5f);
        // 3
        laserTransform.LookAt(hitPoint);
        // 4
        laserTransform.localScale = new Vector3(laserTransform.localScale.x,
                                                laserTransform.localScale.y,
                                                hit.distance);
    }

    private void Teleport()
    {
        // 1
        shouldTeleport = false;
        // 2
        reticle.SetActive(false);

        // Fix all joints touching object in hand
        GameObject objInHand = ControllerGrabObjectLeft.objectInHand; // controllerPose.GetComponent<ControllerGrabObjectRight>().objectInHand;
        GameObject onPlate = null;

        FixedJoint fx = null;

        if (objInHand != null && objInHand.tag == "Plate" )
        {
            print("RICKO MODE" + objInHand.name);

            onPlate = objInHand.GetComponent<ObjectsOnPlate>().getObjOnPlate();

            if (onPlate != null)
            {
                //print("shits working");

                fx = gameObject.AddComponent<FixedJoint>();

                fx.breakForce = Mathf.Infinity;
                fx.breakTorque = Mathf.Infinity;
                var joint = fx;
                joint.connectedBody = onPlate.GetComponent<Rigidbody>();

            }
        }

        // 3
        Vector3 difference = cameraRigTransform.position - headTransform.position;
        // 4
        difference.y = 0;
        // 5
        cameraRigTransform.position = hitPoint + difference;

        // Remove joints touching objects in hand

        if (onPlate != null && objInHand.tag == "Plate")
        {
            if (gameObject.GetComponent<FixedJoint>())
            {


                StartCoroutine(Example(onPlate, objInHand));
                //Destroy(gameObject.GetComponent<FixedJoint>());
                //   onPlate.GetComponent<Rigidbody>().velocity = controllerPose.GetVelocity();
                //   onPlate.GetComponent<Rigidbody>().angularVelocity = controllerPose.GetAngularVelocity();

            }
        }

        isTeleporting = false; // ADDED*****

    }

    IEnumerator Example(GameObject onPlate, GameObject objInHand)
    {
        //print(Time.time);
        //objInHand.GetComponent<FixedJoint>().connectedBody = null;
        yield return new WaitForSeconds(0);
        Destroy(gameObject.GetComponent<FixedJoint>());
    }

}
