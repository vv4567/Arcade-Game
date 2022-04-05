using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ticket : MonoBehaviour
{
    public string TicketCounterObjectName = "Watch";

    public List<GameObject> TicketPrefabs = new List<GameObject>();
    public List<int> TicketValues = new List<int>();

    public int ticketValue = 1;
    public TicketCount ticketCount = null;

    private void OnEnable()
    {
        setTicketValue(ticketValue);
    }

    private void Start()
    {
        if (ticketCount == null)
        {
            GameObject tmp = GameObject.Find(TicketCounterObjectName);
            if (tmp != null) { ticketCount = tmp.GetComponent<TicketCount>(); }
        }

        while (TicketValues.Count < TicketPrefabs.Count - 1)
        {
            TicketValues.Add(TicketValues[TicketValues.Count - 1] + 1);
        }

    }

    public void setTicketValue(int newValue)
    {
        ticketValue = newValue;

        if (TicketPrefabs == null || TicketPrefabs.Count == 0 || ticketValue == 0 || TicketValues == null || TicketValues.Count == 0)
        {
            return;
        }
        
        TicketPrefabs[0].SetActive(true);

        foreach(int value in TicketValues)
        {
            if (TicketValues.IndexOf(value) > TicketPrefabs.Count - 2) { break; }

            if (ticketValue >= value)
            {
                TicketPrefabs[TicketValues.IndexOf(value)].SetActive(false);
                TicketPrefabs[TicketValues.IndexOf(value) + 1].SetActive(true);
            }
        }
    }

    public void CollectTicket()
    {
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

    /*
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
    */
}
