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
        yOrigin = gameObject.transform.position.y;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Mathf.Abs(gameObject.transform.position.y - yOrigin) >= yThreshold && !pressed)
        {
            pressed = true;
            Debug.Log("Button Pressed");
        }
    }
}
