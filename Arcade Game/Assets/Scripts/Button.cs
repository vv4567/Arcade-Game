using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public float yThreshold = 0;
    public float yOrigin = 0;
    private bool pressed = false;

    private void Start()
    {
        //yOrigin = gameObject.transform.localPosition.y;
    }


    private void OnTriggerExit(Collider other)
    {
        gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, yOrigin, gameObject.transform.localPosition.z);
    }

    // Update is called once per frame
    private void Update()
    {

        if (Mathf.Abs(gameObject.transform.localPosition.y - yOrigin) >= yThreshold)
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
}
