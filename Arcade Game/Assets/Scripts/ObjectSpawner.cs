using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject SpawnedObject;
    public int Quantity = 1;
    public float spawnDelay = 0.1f;

    private int spawnedQuantity = 0;

    public void SpawnObject()
    {
        spawnedQuantity = 0;
        if (SpawnedObject == null) { return; }

        StartCoroutine(SpawnedObjectCo());
    }

    IEnumerator SpawnedObjectCo()
    {
        while (spawnedQuantity < Quantity)
        {
            Instantiate(SpawnedObject, this.transform.position, Quaternion.Euler(Vector3.zero));
            spawnedQuantity++;
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
