using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class DeliverFoodToSeat : MonoBehaviour
{

    public GameObject seat;

    void OnCollisionEnter(Collision col )
    {
        
        print("Colision: " + col.gameObject.name);
      //  string name = col.gameObject.name;
    
        if ( col.gameObject.tag == "Plate")
        {

            if (seat.tag == "A1" && col.gameObject.GetComponent<PlateDelivery>().hasObj("Bun"))
            {
                Destroy(col.gameObject.GetComponent<PlateDelivery>().getObj("Bun"));
                Destroy(col.gameObject);
                GameState.delivery("Burger (B) - A1");
                seat.GetComponent<AudioSource>().Play();
            }
            else if (seat.tag == "C2" && col.gameObject.GetComponent<PlateDelivery>().hasObj("BunL"))
            {
                Destroy(col.gameObject.GetComponent<PlateDelivery>().getObj("BunL"));
                Destroy(col.gameObject);
                GameState.delivery("Burger (B, L) - C2");
                seat.GetComponent<AudioSource>().Play();
            }
            else if (seat.tag == "D1" && col.gameObject.GetComponent<PlateDelivery>().hasObj("BunM"))
            {
                Destroy(col.gameObject.GetComponent<PlateDelivery>().getObj("BunM"));
                Destroy(col.gameObject);
                GameState.delivery("Burger (B, M) - D1");
                seat.GetComponent<AudioSource>().Play();
            }
            else if (seat.tag == "B2" && col.gameObject.GetComponent<PlateDelivery>().hasObj("BunTM"))
            {
                Destroy(col.gameObject.GetComponent<PlateDelivery>().getObj("BunTM"));
                Destroy(col.gameObject);
                GameState.delivery("Burger (B, M, T) - B2");
                seat.GetComponent<AudioSource>().Play();
            }
            else if (seat.tag == "E1" && col.gameObject.GetComponent<PlateDelivery>().hasObj("BunFin"))
            {
                Destroy(col.gameObject.GetComponent<PlateDelivery>().getObj("BunFin"));
                Destroy(col.gameObject);
                GameState.delivery("Burger (B, M, L, T) - E1");
                seat.GetComponent<AudioSource>().Play();
            }
        }

        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
