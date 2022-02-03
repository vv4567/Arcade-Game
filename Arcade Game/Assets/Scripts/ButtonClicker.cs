using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClicker : MonoBehaviour
{
    public float yThreshold = 0.05f;

    private Vector3 originPos = Vector3.zero;
    private bool pressed = false;
    private bool spring = false;

    private void Start()
    {
        originPos.y = gameObject.transform.localPosition.y;
    }

    /*
    private void OnTriggerEnter(Collider other)
    {
        spring = false;
    }
    */

    private void OnTriggerExit(Collider other)
    {
        spring = true;
    }

    private void OnTriggerStay(Collider other)
    {
        spring = (other == null);
    }

    // Update is called once per frame
    private void Update()
    {
        if (gameObject.transform.localPosition.y >= originPos.y)
        {
            gameObject.transform.localPosition = originPos;
            spring = false;
            return;
        }

        if (spring)
        {
            gameObject.transform.localPosition += new Vector3(0f, 0.001f, 0f);
        }


        if (Mathf.Abs(gameObject.transform.localPosition.y - originPos.y) >= yThreshold)
        {
            if (!pressed)
            {
                pressed = true;
                Debug.Log("Button Pressed");
            }
        }
        else
        {
            pressed = false;
        }
    }

    public bool isPressed()
    {
        return pressed;
    }
}
