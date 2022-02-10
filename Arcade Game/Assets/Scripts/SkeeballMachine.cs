using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeeballMachine : GameMachine
{
    private ObjectSpawner ballSpawner;

    protected override void Start()
    {
        base.Start();
        ballSpawner = GetComponentInChildren<ObjectSpawner>();
    }

    public override void StartMachine()
    {

        base.StartMachine();

        //spawn balls
        SpawnBalls(4);
    }

    public void SpawnBalls(int quantity)
    {
        if (ballSpawner == null || !_isRunning) { return; }

        ballSpawner.SetQuantity(quantity);
        ballSpawner.SpawnObject();
    }

}
