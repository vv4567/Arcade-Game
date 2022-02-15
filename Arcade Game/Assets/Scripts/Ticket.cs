using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ticket : MonoBehaviour
{

    //public GameObject ticketPrefab;

    public int ticketValue = 1;

    public void setTicketValue(int newValue)
    {
        ticketValue = newValue;
    }

   /* private void OnTriggerEnter(Collider other)
    {
        if(other.tag =="Player")
        {
            //other.GetComponent<TicketCount>().points++;

            GameManager gameManager = null;
            GameObject tmp = GameObject.Find("GameManager");
            if (tmp != null) { gameManager = tmp.GetComponent<GameManager>(); }

            if (gameManager != null)
            {
                TicketCount ticketCount = gameManager.GetComponent<TicketCount>();
                if (ticketCount != null)
                {
                    ticketCount.points++;
                }
            }

            Destroy(this.gameObject);
        }
    }*/
}
