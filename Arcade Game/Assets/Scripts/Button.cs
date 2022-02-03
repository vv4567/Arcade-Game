using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    public ButtonClicker ButtonClicker;
    public UnityEvent OnActivation;

    private void Start()
    {
        if (ButtonClicker == null)
        {
            ButtonClicker = GetComponentInChildren<ButtonClicker>();
        }
    }

    private void Update()
    {
        if (ButtonClicker != null && ButtonClicker.isPressed())
        {
            OnActivation.Invoke();
        }
    }
}
