using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ticket : MonoBehaviour
{

    //public GameObject ticketPrefab;
    public int ticketValue = 1;
    private TicketCount ticketCount = null;

    private void Start()
    {
        GameObject tmp = GameObject.Find("Watch");
        if (tmp != null) { ticketCount = tmp.GetComponent<TicketCount>(); }
    }

    public void setTicketValue(int newValue)
    {
        ticketValue = newValue;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //other.GetComponent<TicketCount>().points++;
            if (ticketCount != null)
            {
               ticketCount.NumberOfTickets += ticketValue;
            }
            else
            {
                Debug.Log("Cannot find ticketCount");
            }

            Destroy(this.gameObject);
        }
    }
}
