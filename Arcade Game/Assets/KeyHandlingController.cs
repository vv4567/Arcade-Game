using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHandlingController : MonoBehaviour
{
    public List<LockHighlight> LockHighlighters;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            foreach(LockHighlight highlighter in LockHighlighters)
            {
                if (highlighter != null)
                {
                    highlighter.Highlight();
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            foreach (LockHighlight highlighter in LockHighlighters)
            {
                if (highlighter != null)
                {
                    highlighter.Unhighlight();
                }
            }
        }
    }
}
