using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeeballMachine : GameMachine
{
    private ObjectSpawner ballSpawner;
    private int numberOfBallUsed = 0;

    public int NumberOfBalls = 7;

    protected override void Start()
    {
        base.Start();
        ballSpawner = GetComponentInChildren<ObjectSpawner>();
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
        ballSpawner.SpawnObject();
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
