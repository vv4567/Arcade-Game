using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    public GameObject Key;
    public List<string> IgnoreObjects;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == this.gameObject) { return; }

        if (other.gameObject.name == this.gameObject.name) { return; }

        foreach (string name in IgnoreObjects)
        {
            if (other.gameObject.name.Contains(name))
            {
                return;
            }
        }

        if (Key != null)
        {
            Key.SetActive(true);
        }
    }
}
