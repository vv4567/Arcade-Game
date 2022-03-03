using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PrizeScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.position = new Vector3(1.897f, 0.2f, 1.68f);//(where you want to teleport)
            if (other.GetComponentInChildren<LocomotionSystem>() != null)
            {
                other.GetComponentInChildren<LocomotionSystem>().gameObject.SetActive(false);
            }
        }
    }
}
