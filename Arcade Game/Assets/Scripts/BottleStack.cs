using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BottleStack : MonoBehaviour
{
    public string KeyObjectName;
    private GameObject Key;

    public List<GameObject> Bottles;

    protected List<Vector3> BottlePositions;

    public bool knockedOver = false;

    private void OnEnable()
    {
        Key = GameObject.Find(KeyObjectName);

        if (Key == null)
        {
            Debug.LogWarning(KeyObjectName + " is missing from the level");
        }

        Key.SetActive(false);
    }

    private void Start()
    {
        StartCoroutine(RecordPositionCo());
    }

    IEnumerator RecordPositionCo()
    {
        yield return new WaitForSeconds(5);

        foreach (GameObject bottle in Bottles)
        {
            BottlePositions.Add(bottle.transform.position);
        }

        knockedOver = false;
    }

    private void Update()
    {

        if (knockedOver) { return; }

        for(int i = 0; i < Bottles.Count; ++i)
        {
            if (Bottles[i].transform.position != BottlePositions[i])
            {
                knockedOver = true;
                break;
            }
        }

        if (Key != null) { Key.SetActive(true); }
    }
}
