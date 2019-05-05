using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ActionsTest : MonoBehaviour
{

    public SteamVR_Input_Sources handType; // 1
    public SteamVR_Action_Boolean teleportAction; // 2
    public SteamVR_Action_Boolean grabAction; // 3

    // Update is called once per frame
    void Update()
    {
        if (GetTeleportDown())
        {
            print("Teleport " + handType);
        }

        if (GetGrab())
        {
            print("Grab " + handType);
        }

    }

    // Poll if Teleported action just activated return true if the case
    public bool GetTeleportDown() // 1
    {
        return teleportAction.GetStateDown(handType);
    }

    // Poll if Grab action just activated
    public bool GetGrab() // 2
    {
        return grabAction.GetState(handType);
    }



}
