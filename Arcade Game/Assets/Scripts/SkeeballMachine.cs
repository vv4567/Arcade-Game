using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeeballMachine : GameMachine
{
    public ObjectSpawner ballSpawner;
    private int numberOfBallUsed = 0;

    public int NumberOfBalls = 7;
    public GameObject[] BallCounter;

    protected override void Start()
    {
        base.Start();
        if (ballSpawner == null)
        { ballSpawner = GetComponentInChildren<ObjectSpawner>(); }

        BallCounter = new GameObject[NumberOfBalls];
    }

    public override void StartMachine()
    {
        if (_isRunning) { return; }

        base.StartMachine();

        //spawn balls
        SpawnBalls(NumberOfBalls);
    }

    public void SpawnBalls(int quantity)
    {
        if (ballSpawner == null || !_isRunning) { return; }

        ballSpawner.SetQuantity(quantity);
        ballSpawner.SpawnObject(BallCounter);
    }

    public void UpdateNumberOfBalls(int numberOfBall)
    {
        numberOfBallUsed += numberOfBall;

        if (numberOfBallUsed >= NumberOfBalls)
        {
            numberOfBallUsed = 0;
            StopMachine();
        }
        
    }


}
