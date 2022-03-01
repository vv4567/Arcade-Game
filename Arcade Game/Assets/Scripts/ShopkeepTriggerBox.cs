using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ShopkeepTriggerBox : MonoBehaviour
{
    public TicketCount ticketManager;
    public GameObject player;
    public List<GameObject> RewardList;
    public List<int> RewardRequirement;


    // Start is called before the first frame update
    private void Start()
    {
        GameObject gameManagerObj = GameObject.Find("GameManager");
        if (gameManagerObj != null)
        {
            ticketManager = gameManagerObj.GetComponent<TicketCount>();
        }

        while (RewardRequirement.Count < RewardList.Count)
        {
            RewardRequirement.Add(0);
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
        if (other.tag == "Player" && ticketManager != null)
        {
            for(int i = 0; i < RewardRequirement.Count; ++i)
            {
                if (RewardRequirement[i] <= ticketManager.NumberOfTickets)
                {
                    if (RewardList[i].GetComponent<XRGrabInteractable>() != null)
                    {
                        RewardList[i].GetComponent<XRGrabInteractable>().enabled = true;
                    }
                }
            }
        }
    }
}
