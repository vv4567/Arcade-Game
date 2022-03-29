using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class GameMachine : MonoBehaviour
{
    [Header("Machine Settings")]
    public int GameTimeInSeconds = 60;
    public ObjectSpawner ticketSpawner;
    public float NumberOfTicketsPerScore = 0.1f;

    [Header("Event")]
    public UnityEvent OnMachineStart;
    public UnityEvent OnMachineStop;
    public UnityEvent OnSpawningTickets;

    private int totalScore = 0;
    private float timeStarted = 0;
    private int timeCounter = 0;


    protected string _machineID;
    protected bool _isRunning = false;

    protected virtual void Start()
    {
        if (GetComponent<InteractableItem>() != null)
        {
            _machineID = GetComponent<InteractableItem>().name;
        }

        if (ticketSpawner == null)
        {
            ticketSpawner = GetComponentInChildren<ObjectSpawner>();
        }
    }

    public virtual void StartMachine()
    {
        if (_isRunning) { return; }
        _isRunning = true;

        OnMachineStart.Invoke();

        //reset machine score
        SetScore(0);

        //turn on light and other effect to let player know the machine is started

        //start game time
        timeStarted = Time.fixedUnscaledTime;

        if (GameTimeInSeconds != 0)
        { StartCoroutine(StopMachineCo()); }

        //spawn balls
        //SpawnBalls(4);
    }
    /*
    public void SpawnBalls(int quantity)
    {
        if (ballSpawner == null || !_isRunning) { return; }

        ballSpawner.SetQuantity(quantity);
        ballSpawner.SpawnObject();
    }
    */
    IEnumerator StopMachineCo()
    {
        yield return new WaitForSeconds(GameTimeInSeconds);
        StopMachine();
    }

    public virtual void StopMachine()
    {
        _isRunning = false;
        //turn off light and other effect to let player know the machine is turned off

        OnMachineStop.Invoke();

        if (totalScore == 0) { return; }

        OnSpawningTickets.Invoke();

        //spawn tickets
        ticketSpawner.SetQuantity(1);

        GameObject[] spawnedTicket = new GameObject[1];

        ticketSpawner.SpawnObject(spawnedTicket);

        if (spawnedTicket[0].GetComponent<Ticket>() != null)
        {
            spawnedTicket[0].GetComponent<Ticket>().setTicketValue((int)(totalScore * NumberOfTicketsPerScore));
        }
    }

    public virtual void AddScore(int score)
    {
        if (!_isRunning) { return; }

        totalScore += score;
        Debug.Log(_machineID + " Total Score: " + totalScore);
    }

    public virtual void SetScore(int score)
    {
        if (!_isRunning) { return; }

        totalScore = score;
    }

    public int GetScore()
    {
        return totalScore;
    }

    protected virtual void Update()
    {
        if (_isRunning && GameTimeInSeconds != 0)
        {
            if ((int)(Time.fixedUnscaledTime - timeStarted) != timeCounter)
            {
                timeCounter = (int)(Time.fixedUnscaledTime - timeStarted);
                Debug.Log(_machineID + " Time Remaining: " + (GameTimeInSeconds - timeCounter));
            }

        }
    }

    public int getRemainingTime()
    {
        return getRemainingTimeAsInterger();
    }

    public int getRemainingTimeAsInterger()
    {
        return (int)getRemainingTimeAsDouble();
    }

    public double getRemainingTimeAsDouble()
    {
        return (GameTimeInSeconds - timeCounter);
    }
}
