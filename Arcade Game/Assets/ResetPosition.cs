using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    public bool SetInitialPosition = false;
    public bool UseLocalPosition = false;
    public Vector3 InitialPosition;

    private Vector3 savedPos = Vector3.zero;

    private void OnEnable()
    {
        if (SetInitialPosition)
        {
            savedPos = InitialPosition;
        }
        else
        {
            if (UseLocalPosition)
            {
                savedPos = transform.localPosition;
            }
            else
            {
                savedPos = transform.position;
            }
        }

    }

    public void ResetPos()
    {
        if (UseLocalPosition)
        {
            transform.localPosition = savedPos;
        }
        else
        {
            transform.position = savedPos;
        }
    }
}
