using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ShopkeepTriggerBox : MonoBehaviour
{
    public TicketCount TicketCounter;

    public List<GameObject> player;
    public List<Reward> RewardList;


    // Start is called before the first frame update
    private void Start()
    {
        if (TicketCounter == null)
        {
            Debug.LogWarning("Missing Ticket Counter from the player");
            return;
        }

        for (int i = 0; i < RewardList.Count; ++i)
        {
            if (RewardList[i].GetComponent<XRGrabInteractable>() != null)
            {
                RewardList[i].GetComponent<XRGrabInteractable>().enabled = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && TicketCounter != null)
        {
            for(int i = 0; i < RewardList.Count; ++i)
            {
                if (RewardList[i].TicketCost <= TicketCounter.NumberOfTickets)
                {
                    TicketCounter.NumberOfTickets -= RewardList[i].TicketCost;

                    if (RewardList[i].GetComponent<XRGrabInteractable>() != null)
                    {
                        RewardList[i].GetComponent<XRGrabInteractable>().enabled = true;
                        MrCruz.PlayVoiceOver(DialogTypes.EnoughTicket);
                    }

                    return;
                }
            }

            MrCruz.PlayVoiceOver(DialogTypes.NotEnoughTicket);
        }
    }
}
