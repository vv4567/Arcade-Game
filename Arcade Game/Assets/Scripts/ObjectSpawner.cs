using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject SpawnedObject;

    public float SpawnDelay = 0.1f;
    private bool isSpawning = false;

    //the number of game objects to spawn, which will be added to the total if there are more objects need to be spawned
    private int spawnQuantity = 1;

    //the total number of game objects to spawn
    private int Quantity = 0;

    //the number of game objects have been spawned
    private int spawnedQuantity = 0;

    public void SetQuantity(int quantity)
    {
        spawnQuantity = quantity;
    }

    public void SpawnObject()
    {
        if (SpawnedObject == null) { return; }

        if (isSpawning)
        {
            Quantity += spawnQuantity;
            return;
        }

        spawnedQuantity = 0;
        Quantity = spawnQuantity;


        StartCoroutine(SpawnedObjectCo());
        isSpawning = true;
    }

    IEnumerator SpawnedObjectCo()
    {
        while (spawnedQuantity < Quantity)
        {
            Instantiate(SpawnedObject, this.transform.position, Quaternion.Euler(Vector3.zero));
            spawnedQuantity++;
            yield return new WaitForSeconds(SpawnDelay);
        }
        isSpawning = false;
    }
}
