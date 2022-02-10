using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkJugMachine : GameMachine
{
    private ObjectSpawner ballSpawner;
    private ObjectSpawner bottleSpawner;
    private int numberOfBottlesFallen = 0;

    public int NumberOfBottles = 6;


    protected override void Start()
    {
        base.Start();
        ballSpawner = GetComponentInChildren<ObjectSpawner>();
        bottleSpawner = GetComponentInChildren<ObjectSpawner>();
    }

    public override void StartMachine()
    {

        base.StartMachine();

        //spawn balls
        SpawnBalls(1);
        SpawnBottleStack();
    }

    public void SpawnBalls(int quantity)
    {
        if (ballSpawner == null || !_isRunning) { return; }

        ballSpawner.SetQuantity(quantity);
        ballSpawner.SpawnObject();
    }

    public void SpawnBottleStack()
    {
        if (bottleSpawner == null || !_isRunning) { return; }

        bottleSpawner.SetQuantity(1);
        bottleSpawner.SpawnObject();
    }

    public void UpdateNumberOfBottles(int numberOfBottle)
    {
        numberOfBottlesFallen += numberOfBottle;
        if (numberOfBottlesFallen >= NumberOfBottles)
        {
            numberOfBottlesFallen = 0;
            SpawnBottleStack();
        }
    }
}
