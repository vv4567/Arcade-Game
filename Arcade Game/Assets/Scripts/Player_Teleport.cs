using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Player_Teleport : MonoBehaviour
{
    public Vector3 PositionToTeleport;
    public GameObject Player;

    public bool LockMovement = true;
    public LocomotionSystem locomotionSystem;

    private void Start()
    {
        if (Player == null)
        {
            Player = gameObject;
        }
    }

    public void Teleport()
    {
        if (locomotionSystem != null && LockMovement)
        {
            locomotionSystem.enabled = false;
        }

        Player.transform.position = PositionToTeleport;
    }
}
