using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Bottle : MonoBehaviour
{
    public GameObject Key;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<XRGrabInteractable>())
        {
            if (Key != null)
            {
                Key.SetActive(true);

                if (MrCruz.currentDialog == DialogTypes.Tutorial)
                {
                    MrCruz.UpdateDialog();
                }
            }
            else
            {
                Debug.Log("No key");
            }
        }
    }
}
