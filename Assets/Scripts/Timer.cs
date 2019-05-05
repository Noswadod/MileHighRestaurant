using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;
using TMPro;

public class Timer : MonoBehaviour
{
    private float timer;
    public TextMeshPro text;

    public static bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        timer = 180.0f;
        text.fontSize = 108;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            int min = (int)timer / 60;
            int seconds = (int)(timer) % 60;
            if (seconds < 10)
            {
                text.text = min + " : 0" + seconds;
            }
            else
            {
                text.text = min + " : " + seconds;
            }
        }
        else if (!gameOver)
            {
                text.text = "GAME OVER!";
                text.fontSize = 50;

                GetComponent<AudioSource>().Play();
                gameOver = true;
        }
    }
}
