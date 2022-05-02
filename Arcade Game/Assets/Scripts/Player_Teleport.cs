using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class Player_Teleport : MonoBehaviour
{
    public Vector3 PositionToTeleport;
    public GameObject Player;

    public bool LockMovement = true;
    public ContinuousMoveProviderBase locomotionSystem;

    public bool AutoTeleport = false;
    public float AutoTeleportDelay = 0f;

    public float TeleportDelay = 0;

    public FadeScreen TransitionScreen;
    public Color TransitionColor;

    public string NextSceneName;

    private void Start()
    {
        if (Player == null)
        {
            Player = gameObject;
        }

        if (AutoTeleport && AutoTeleportDelay > 0)
        {
            StartCoroutine(AutoTeleportCo());
        }
    }

    IEnumerator AutoTeleportCo()
    {
        yield return new WaitForSeconds(AutoTeleportDelay);
        Teleport();
    }

    public void Teleport()
    {
        if (locomotionSystem != null && LockMovement)
        {
            locomotionSystem.enabled = false;
        }

        if (TransitionScreen != null)
        {
            TransitionScreen.FadeTo(TransitionColor);
        }

        if (TeleportDelay > 0)
        {
            StartCoroutine(TeleportCo());
            return;
        }

        Player.transform.position = PositionToTeleport;
    }

    IEnumerator TeleportCo()
    {
        yield return new WaitForSeconds(TeleportDelay);
        Player.transform.position = PositionToTeleport;
        Player.transform.rotation = Quaternion.identity;
        SceneManager.LoadScene(NextSceneName);
        //TransitionScreen.Fade(FadeScreen.FadeType.FadeOut);
    }
}
