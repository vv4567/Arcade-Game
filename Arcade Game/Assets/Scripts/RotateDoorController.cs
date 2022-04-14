using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class RotateDoorController : MonoBehaviour
{
    [Header("Door Lock")]
    public List<GameObject> Key;
    public bool locked = true;
    public bool isOpen = false;
    public float DoorMovespeed = 0.005f;
    public List<LockHighlight> Locks;

    [Header("Left Door")]
    public GameObject LDoor;
    public float LDoor_YRotation_Open;
    public float LDoor_YRotation_Close;

    [Header("Right Door")]
    public GameObject RDoor;
    public float RDoor_YRotation_Open;
    public float RDoor_YRotation_Close;

    [Header("Door Events")]
    public UnityEvent OnNoKey;
    public UnityEvent OnUnlocked;
    public UnityEvent OnOpenStart;
    public UnityEvent OnOpenFinish;
    public UnityEvent OnCloseStart;
    public UnityEvent OnCloseFinish;

    private bool isOpening = false;
    private bool isClosing = false;

    AudioSource sound;

    private void Start()
    {
        sound = GetComponent<AudioSource>();

        if (isOpen)
        {
            if (LDoor != null)
            {
                LDoor.transform.localRotation = Quaternion.Euler(LDoor.transform.localRotation.eulerAngles.x, LDoor_YRotation_Open, LDoor.transform.localRotation.eulerAngles.z);
            }

            if (RDoor != null)
            {
                RDoor.transform.localRotation = Quaternion.Euler(RDoor.transform.localRotation.eulerAngles.x, RDoor_YRotation_Open, RDoor.transform.localRotation.eulerAngles.z);
            }
        }
        else
        {
            if (LDoor != null)
            {
                LDoor.transform.localRotation = Quaternion.Euler(LDoor.transform.localRotation.eulerAngles.x, LDoor_YRotation_Close, LDoor.transform.localRotation.eulerAngles.z);
            }

            if (RDoor != null)
            {
                RDoor.transform.localRotation = Quaternion.Euler(RDoor.transform.localRotation.eulerAngles.x, RDoor_YRotation_Close, RDoor.transform.localRotation.eulerAngles.z);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        foreach (GameObject key in Key)
        {
            if (other.gameObject == key)
            {
                if (locked)
                {
                    locked = false;

                    MrCruz.UpdateDialog();

                    OnUnlocked.Invoke();
                    return;
                }
            }
        }
        
        if (other.tag == "Player" && locked)
        {
            OnNoKey.Invoke();
        }
    }

    public void OpenDoors()
    {
        if (locked  || isOpen || isOpening) { return; }

        OnOpenStart.Invoke();
        isOpening = true;
        //sound.Play();

    }

    public void CloseDoors()
    {
        if (locked  || !isOpen || isClosing) { return; }

        OnCloseStart.Invoke();
        isClosing = true;
    }

    public void HighlightLocks(bool flag = true)
    {
        if (Locks != null && Locks.Count > 0)
        {
            foreach(LockHighlight lockHighlight in Locks)
            {
                if (flag)
                {
                    lockHighlight.Highlight();
                }
                else
                {
                    lockHighlight.Unhighlight();
                }
            }
        }
    }

    public bool RotateDoor(GameObject door, float targetYRotation, float speed)
    {
        float currentYRotation = door.transform.localRotation.eulerAngles.y;

        if (currentYRotation > targetYRotation && Mathf.Abs(currentYRotation - targetYRotation) >= speed * Time.deltaTime)
        {
            currentYRotation -= speed * Time.deltaTime;
        }
        else if (currentYRotation < targetYRotation && Mathf.Abs(currentYRotation - targetYRotation) >= speed * Time.deltaTime)
        {
            currentYRotation += speed * Time.deltaTime;
        }
        else
        {
            door.transform.localRotation = Quaternion.Euler(door.transform.localRotation.eulerAngles.x, targetYRotation, door.transform.localRotation.eulerAngles.z);
            return true;
        }

        door.transform.localRotation = Quaternion.Euler(door.transform.localRotation.eulerAngles.x, currentYRotation, door.transform.localRotation.eulerAngles.z);
        
        return false;

    }

    private void Update()
    {
        if (isOpening)
        {
            //If there is no door to open
            if (LDoor == null && RDoor == null) 
            {
                
                isOpening = false;
                OnOpenFinish.Invoke();
                return;
            }

            if (LDoor != null)
            {
                if (RotateDoor(LDoor, LDoor_YRotation_Open, DoorMovespeed))
                {
                    if (isOpening)
                    {
                        isOpening = false;
                    }
                }
            }

            if (RDoor != null)
            {
                if (RotateDoor(RDoor, RDoor_YRotation_Open, DoorMovespeed))
                {
                    if (isOpening)
                    {
                        isOpening = false;
                    }
                }
            }

            if (!isOpening)
            {
                isOpen = true;
                OnOpenFinish.Invoke();
            }
            return;
        }

        if (isClosing)
        {
            //If there is no door to open
            if (LDoor == null && RDoor == null)
            {
                isClosing = false;
                OnCloseFinish.Invoke();
                return;
            }

            if (LDoor != null)
            {
                if (RotateDoor(LDoor, LDoor_YRotation_Close, DoorMovespeed))
                {
                    if (isClosing)
                    {
                        isClosing = false;
                    }
                }
            }

            if (RDoor != null)
            {
                if (RotateDoor(RDoor, RDoor_YRotation_Close, DoorMovespeed))
                {
                    if (isClosing)
                    {
                        isClosing = false;
                    }
                }
            }

            if (!isClosing)
            {
                isOpen = false;
                OnCloseFinish.Invoke();
            }
        }
    }
}
