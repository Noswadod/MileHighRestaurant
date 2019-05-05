using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class MeatCooking : MonoBehaviour
{
    private bool isCooking;
    private float timer;

    public GameObject meat;
    public GameObject meatCooked;
    public GameObject meatBurnt;

    // Start is called before the first frame update
    void Start()
    {
        isCooking = false;

        if ( meat.tag == "MeatRaw")
        {
            timer = 10;
        } else if ( meat.tag == "MeatCooked")
        {
            timer = 5;
        }
        
    }

    public bool getIsCooking()
    {
        return isCooking;
    }

    // When meat collides with something
    void OnCollisionStay(Collision col)
    {
        if ((col.gameObject.tag == "Pan" &&  PanOnStove.onStove1 ) || ( col.gameObject.tag == "Pan2" && PanOnStove.onStove2 ))
        {
            isCooking = true;
        } else
        {
            isCooking = false;
        }
    }

    // When meat stops colliding with something
    void OnCollisionExit(Collision col)
    {
        isCooking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCooking)
        {
            timer -= Time.deltaTime;

            if (!gameObject.GetComponent<AudioSource>().isPlaying)
            {
                gameObject.GetComponent<AudioSource>().Play();
            }

            if (timer <= 0)
            {
                if (meat.tag == "MeatRaw")
                {
                    Vector3 meatPos = meat.transform.position;
                    Quaternion meatRot = meat.transform.rotation;

                    Instantiate(meatCooked, meatPos, meatRot);
                    Destroy(meat);
                }

                if (meat.tag == "MeatCooked")
                {
                    Vector3 meatPos = meat.transform.position;
                    Quaternion meatRot = meat.transform.rotation;

                    Instantiate(meatBurnt, meatPos, meatRot);
                    Destroy(meat);
                }
            }

        }
        else
        {
            if (gameObject.GetComponent<AudioSource>().isPlaying)
            {
                gameObject.GetComponent<AudioSource>().Pause();
            }
        }
        
    }
}
