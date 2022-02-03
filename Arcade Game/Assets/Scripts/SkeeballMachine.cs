using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeeballMachine : MonoBehaviour
{
    public int GameTimeInSeconds = 60;

    private bool isRunning = false;
    private int totalScore = 0;
    private ObjectSpawner ballSpawner;
    private float currentTime = 0;

    private void Start()
    {
        ballSpawner = GetComponentInChildren<ObjectSpawner>();
    }

    public void StartMachine()
    {
        if (isRunning) { return; }

        isRunning = true;
        //turn on light and other effect to let player know the machine is started

        //start game time
        currentTime = Time.fixedUnscaledTime;
        StartCoroutine(StopMachineCo());

        //spawn balls
        if (ballSpawner != null)
        {
            ballSpawner.Quantity = 4;
            ballSpawner.spawnDelay = 1f;
            ballSpawner.SpawnObject();
        }
    }

    IEnumerator StopMachineCo()
    {
        yield return new WaitForSeconds(GameTimeInSeconds);
        StopMachine();
    }

    public void StopMachine()
    {
        isRunning = false;
        //turn off light and other effect to let player know the machine is turned off

        //spawn tickets
    }
}
