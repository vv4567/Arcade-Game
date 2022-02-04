using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeeballMachine : MonoBehaviour
{
    public int GameTimeInSeconds = 60;

    private bool isRunning = false;
    private int totalScore = 0;
    private ObjectSpawner ballSpawner;
    private float timeStarted = 0;
    private int timeCounter = 0;
    private string machineID;

    private void Start()
    {
        if (GetComponent<InteractableItem>() != null)
        {
            machineID = GetComponent<InteractableItem>().name;
        }
        ballSpawner = GetComponentInChildren<ObjectSpawner>();
    }

    public void StartMachine()
    {
        if (isRunning) { return; }

        isRunning = true;

        //reset machine score
        SetScore(0);

        //turn on light and other effect to let player know the machine is started

        //start game time
        timeStarted = Time.fixedUnscaledTime;
        StartCoroutine(StopMachineCo());

        //spawn balls
        SpawnBalls(4);
    }

    public void SpawnBalls(int quantity)
    {
        if (ballSpawner == null || !isRunning) { return; }

        ballSpawner.SetQuantity(quantity);
        ballSpawner.SpawnObject();
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

    public void AddScore(int score)
    {
        if (!isRunning) { return; }

        totalScore += score;
        Debug.Log(machineID + " Total Score: " + totalScore);
    }

    public void SetScore(int score)
    {
        if (!isRunning) { return; }

        totalScore = score;
    }

    private void Update()
    {
        if (isRunning)
        {
            if ((int)(Time.fixedUnscaledTime - timeStarted) != timeCounter)
            {
                timeCounter = (int)(Time.fixedUnscaledTime - timeStarted);
                Debug.Log(machineID + " Time Remaining: " + (GameTimeInSeconds - timeCounter));
            }

        }
    }
}
