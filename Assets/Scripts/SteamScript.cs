using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamScript : MonoBehaviour
{
    ParticleSystem steam;
    //public GameObject meat;

    // Start is called before the first frame update
    void Start()
    {
        steam = GetComponent<ParticleSystem>();
        steam.Play();
    }

    // Update is called once per frame
    void Update()
    {
        //print(meat.GetComponent<MeatCooking>().getIsCooking());

        if (steam.gameObject.transform.parent.GetComponent<MeatCooking>().getIsCooking())
        {
            if (!steam.isPlaying)
            {
                steam.Play();
            }
        }
        else
        {
            if (steam.isPlaying)
            {
                steam.Pause();
            }
        }
    }
}
