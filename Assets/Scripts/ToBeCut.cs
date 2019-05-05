using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ToBeCut : MonoBehaviour
{
    public SteamVR_Action_Vibration haptic;

    public GameObject food;
    public GameObject cutFood;
    private int hp;
    private bool cuttable;
    private bool isCutting;

    void Start()
    {
        isCutting = false;
        cuttable = false;
        hp = 3;
    }

    void Update()
    {
        if (hp <= 0)
        {
            Vector3 loc = food.transform.position;
            Quaternion rot = food.transform.rotation;
            Destroy(food);
            Instantiate(cutFood, loc, rot);
        //    Instantiate(cutFood, loc, rot);
        //    Instantiate(cutFood, loc, rot);
        }
    }

    // When [] collides with something
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "CuttingBoard")
        {

        //    print("CUTTABLE");
            cuttable = true;
            //food.GetComponent<Rigidbody>().isKinematic = true;
        }

        if (col.gameObject.tag == "Knife" && cuttable && !isCutting)
        {
            //haptic.Execute(0f, 0.1f, 160, 0.5f, SteamVR_Input_Sources.RightHand);

            isCutting = true;
            hp--;
            print("CUTTING HP:" + hp);

            food.GetComponent<AudioSource>().Play();
        }
    }

    // When meat stops colliding with something
    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "CuttingBoard")
        {
            cuttable = false;
        }

        if (col.gameObject.tag == "Knife")
        {
            isCutting = false;
        }


    }
}
