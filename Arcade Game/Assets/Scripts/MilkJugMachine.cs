using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkJugMachine : GameMachine
{
    public ObjectSpawner BallSpawner;
    public ObjectSpawner BottleSpawner;

    public GameObject[] BallCounter;
    public GameObject[] BottleStackCounter;

    private int numberOfBottlesFallen = 0;
    private int numberOfBallUsed = 0;

    public int NumberOfBottles = 6;
    public int NumberOfBalls = 4;


    protected override void Start()
    {
        base.Start();
        BallCounter = new GameObject[NumberOfBalls];
        BottleStackCounter = new GameObject[1];
        //BallSpawner = GetComponentInChildren<ObjectSpawner>();
        //BottleSpawner = GetComponentInChildren<ObjectSpawner>();
    }

    public override void StartMachine()
    {
        if (_isRunning) { return; }

        base.StartMachine();

        if (BottleStackCounter[0] != null)
        { 
            Destroy(BottleStackCounter[0]);
            BottleStackCounter[0] = null;
        }

        //spawn balls
        SpawnBalls(NumberOfBalls);
        SpawnBottleStack();
    }

    public void SpawnBalls(int quantity)
    {
        if (BallSpawner == null || !_isRunning) { return; }

        BallSpawner.SetQuantity(quantity);
        BallSpawner.SpawnObject(BallCounter);
    }

    public void SpawnBottleStack()
    {
        if (BottleSpawner == null || !_isRunning) { return; }
        BottleSpawner.SetQuantity(1);
        BottleSpawner.SpawnObject(BottleStackCounter);
    }

    public void UpdateNumberOfBottles(int numberOfBottle)
    {
        numberOfBottlesFallen += numberOfBottle;

        if (numberOfBottlesFallen >= NumberOfBottles)
        {
            numberOfBottlesFallen = 0;
            StopMachine();
        }
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

    public override void StopMachine()
    {
        base.StopMachine();

        for (int i = 0; i < NumberOfBalls; ++i)
        {
            if (BallCounter[i] != null)
            {
                Destroy(BallCounter[i]);
            }
            BallCounter[i] = null;
        }
    }
}
