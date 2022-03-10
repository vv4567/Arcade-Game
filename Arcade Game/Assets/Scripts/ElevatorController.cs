using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    public List<GameObject> Players;
    //use this when the ElevatorFBX is a child of another prefab
    public GameObject Elevator;

    //position of the current level
    private float CurrentLevelPos;
    //position of the next level
    public float NextLevelPos;
    public float ElevatorSpeed = 0.1f;
    public float ElevatorDoorSpeed = 0.2f;

    private bool IsMoving = false;
    private bool IsOpeningDoors = false;

    public GameObject RDoor;
    public float RDoorPos_Open;
    private float RDoorPos;

    public GameObject LDoor;
    public float LDoorPos_Open;
    private float LDoorPos;

    public bool DoOnce = true;
    public bool AutoStart = false;
    private bool done = false;

    private void Start()
    {
        if (Elevator == null)
        {
            Elevator = gameObject;
        }

        CurrentLevelPos = Elevator.transform.position.y;
        RDoorPos = RDoor.transform.localPosition.x;
        LDoorPos = LDoor.transform.localPosition.x;

        if (AutoStart)
        {
            StartElevator();
        }
    }

    public void StartElevator()
    {
        if (DoOnce && done) { return; }

        if (!IsMoving) 
        { 
            IsMoving = true;
            foreach (GameObject player in Players)
            {
                if (player != null)
                {
                    player.transform.SetParent(Elevator.transform);
                }
            }
        }
    }

    public void OpenDoor()
    {
        if (!IsOpeningDoors) 
        { 
            IsOpeningDoors = true;
            done = true;
        }
    }

    public float Move(float currentPos, float targetPos, float speed)
    {
        if (currentPos > targetPos && Mathf.Abs(currentPos - targetPos) >= speed * Time.deltaTime)
        {
            currentPos -= speed * Time.deltaTime;
        }
        else if (currentPos < targetPos && Mathf.Abs(currentPos - targetPos) >= speed * Time.deltaTime)
        {
            currentPos += speed * Time.deltaTime;
        }
        else { currentPos = targetPos; }
        return currentPos;
    }

    private void Update()
    {
        if (IsMoving)
        {
            if (NextLevelPos != CurrentLevelPos)
            {
                CurrentLevelPos = Move(Elevator.transform.position.y, NextLevelPos, ElevatorSpeed);
            }
            else
            {
                IsMoving = false;
                IsOpeningDoors = true;
            }
            
            Elevator.transform.position = new Vector3(Elevator.transform.position.x, CurrentLevelPos, Elevator.transform.position.z);

        }

        if (IsOpeningDoors)
        {


            if (RDoorPos_Open != RDoorPos)
            {
                RDoorPos = Move(RDoor.transform.localPosition.x, RDoorPos_Open, ElevatorDoorSpeed);
                LDoorPos = Move(LDoor.transform.localPosition.x, LDoorPos_Open, ElevatorDoorSpeed);
            }
            else
            {
                IsOpeningDoors = false;

                foreach (GameObject player in Players)
                {
                    if (player != null)
                    {
                        player.transform.SetParent(null);
                    }
                }
            }

            RDoor.transform.localPosition = new Vector3(RDoorPos, RDoor.transform.localPosition.y, RDoor.transform.localPosition.z);
            LDoor.transform.localPosition = new Vector3(LDoorPos, LDoor.transform.localPosition.y, LDoor.transform.localPosition.z);
        }
    }
}