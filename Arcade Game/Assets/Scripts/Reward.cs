using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Reward : MonoBehaviour
{
    public int TicketCost = 0;
    public Text TicketCostText;
    public UnityEvent OnPickup;

    protected Collider _collider;

    private void Start()
    {
        if (TicketCostText != null)
        {
            TicketCostText.text = TicketCost.ToString() + " Tickets";
        }

        _collider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            OnPickup.Invoke();
        }
    }
}
