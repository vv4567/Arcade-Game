using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketTriggerBox : MonoBehaviour
{
    private Collider collider;

    private void Start()
    {
        collider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<InteractableItem>() != null)
        {
            Debug.Log(other.GetComponent<InteractableItem>().ItemID);
        }
    }
}
