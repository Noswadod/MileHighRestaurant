using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;
using TMPro;

public class GameState : MonoBehaviour
{
    public TextMeshPro text;
    public TextMeshPro orderText;

    private static int orders = 5;

    private static ArrayList orderQueue;

    public static void delivery(string order)
    {
        orderQueue.RemoveAt(orderQueue.IndexOf(order));
        if ( orders > 0)
        {
            orders--;
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        orderQueue = new ArrayList();
        orderQueue.Add("Burger (B) - A1");
        orderQueue.Add("Burger (B, L) - C2");
        orderQueue.Add("Burger (B, M) - D1");
        orderQueue.Add("Burger (B, M, T) - B2");
        orderQueue.Add("Burger (B, M, L, T) - E1");

    }

    void updateDisplay()
    {
        string toDisplay = "";
        for ( int i = 0; i < orderQueue.Count && i < 3; i++)
        {
            toDisplay = toDisplay + (string) ( orderQueue[i] )+ "\n";
        }
        text.text = toDisplay;

        orderText.text = "Remaining\n  Orders\n      " + orders;
    }

    // Update is called once per frame
    void Update()
    {
        updateDisplay();
    }
}


