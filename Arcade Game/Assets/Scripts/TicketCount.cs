using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TicketCount : MonoBehaviour
{
    public int points = 0;

    public Text ticketCountText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        if (ticketCountText != null)
        { ticketCountText.text = points.ToString(); }
    }
    private void OnGUI()
    {

           // GUI.Label(new Rect(10, 10, 100, 20), "Tickets : " + points);
    }
}

