using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Mole : MonoBehaviour
{
    public GameObject molePrefab;
    public float pressedDeltaHeight = 0.01f;

    public float PopUpDelayMin = 0.5f;
    public float PopUpDelayMax = 2f;
    public float StayUpTimeMin = 0.5f;
    public float StayUpTimeMax = 1f;

    public UnityEvent onPress;
    public UnityEvent onRelease;
    public UnityEvent onPopup;

    private GameObject presser;

    private bool isPressed;
    public bool isActive;

    private Vector3 initialLocalPosition;
    private Vector3 pressedLocalPosition;

    // Start is called before the first frame update
    private void Start()
    {
        isPressed = true;
        isActive = false;
        initialLocalPosition = molePrefab.transform.localPosition;

        //Debug.Log(initialLocalPosition);

        pressedLocalPosition = molePrefab.transform.localPosition - new Vector3(0f, pressedDeltaHeight, 0f);


        //Debug.Log(pressedLocalPosition);

        molePrefab.transform.localPosition = pressedLocalPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isActive) { return; }

        if (other.GetComponent<InteractableItem>() == null 
            || other.GetComponent<InteractableItem>().ItemID != "WhackHammer"
            || other.GetComponentInChildren<InteractableItem>().ItemID != "WhackHammer"
            ) { return; }

        if (!isPressed)
        {
            FallDown();
            presser = other.gameObject;
            onPress.Invoke();
        }
    }

    IEnumerator PopUpCo()
    {
        yield return new WaitForSeconds(Random.Range(PopUpDelayMin, PopUpDelayMax));
        PopUp();
    }

    IEnumerator FallDownCo()
    {
        yield return new WaitForSeconds(Random.Range(StayUpTimeMin, StayUpTimeMax));
        FallDown();
    }

    /*
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == presser)
        {
            molePrefab.transform.localPosition = initialLocalPosition;
            onRelease.Invoke();
            isPressed = false;
        }    
    }
    */

    public void PopUp()
    {
        onPopup.Invoke();
        molePrefab.transform.localPosition = initialLocalPosition;
        StartCoroutine(DelayColliderCo());


        if (isActive)
        {
            StartCoroutine(FallDownCo());
        }
    }

    IEnumerator DelayColliderCo()
    {
        yield return new WaitForSeconds(0.1f);
        isPressed = false;
    }

    public void FallDown()
    {
        molePrefab.transform.localPosition = pressedLocalPosition;
        isPressed = true;

        if (isActive)
        {
            StartCoroutine(PopUpCo());
        }
    }

    public void Deactivate()
    {
        StopAllCoroutines();
    }
}
