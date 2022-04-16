using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Game Settings")]
    public double gameTime = 0;
    private double deltaTime = 0;
    private static int lastTimeUpdate = -1;
    private double pauseTime = 0;
    private double pauseTimeStart = -1;

    [Header("Player Settings")]
    public bool FirstPersonMode = false;
    public GameObject playerOVR;
    public GameObject playerFirstPerson;

    [Header("UI")]
    public TextMeshPro timerText;
    public TextMeshPro gameOverText;

    public static bool GameStart { get; set; }
    public static bool GamePause { get; set; }
    public static bool GameEnd { get; set; }

    public static int TimeLeft
    {
        get
        {
            return (lastTimeUpdate > 0 ? lastTimeUpdate : 0);
        }
    }

    [Header("Game Events")]
    public UnityEvent OnGameStart;
    public UnityEvent OnGamePause;
    public UnityEvent OnGameEnd;
    public UnityEvent OnTimeOut;

    private void OnEnable()
    {
        
        if (gameOverText != null)
        {
            gameOverText.text = "";
        }


        if (playerFirstPerson != null)
        {
            playerFirstPerson.SetActive(FirstPersonMode);
        }

        if (playerOVR != null)
        {
            playerOVR.SetActive(!FirstPersonMode);
        }
        GameEnd = false;
        GameStart = false;
        GamePause = false;
        //gameTime = 0;
        deltaTime = 0;
        lastTimeUpdate = -1;
        pauseTime = 0;
        pauseTimeStart = -1;
}

    public static string SecondToTimeText(double timeInSeconds)
    {
        string stringBuilder = "";
        int h = 0, m = 0, s = 0;

        h = (int)(timeInSeconds / 3600);
        m = (int)((timeInSeconds - h * 3600) / 60);
        s = (int)(timeInSeconds - h * 3600 - m * 60);

        if (h < 10)
        {
            stringBuilder += "0";
        }

        stringBuilder += h.ToString() + ":";

        if (m < 10)
        {
            stringBuilder += "0";
        }

        stringBuilder += m.ToString() + ":";

        if (s < 10)
        {
            stringBuilder += "0";
        }

        stringBuilder += s.ToString();

        return stringBuilder;
    }

    private void Update()
    {
        if (deltaTime < 0 || !GameStart)
        {
            return;
        }

        if (deltaTime > 0 && GameEnd)
        {
            if (gameOverText != null)
            {
                gameOverText.text = "You Win";
            }

            OnGameEnd.Invoke();

            return;
        }


        if (lastTimeUpdate == -1)
        {
            gameTime += Time.fixedUnscaledTimeAsDouble;
            lastTimeUpdate = 0;
            OnGameStart.Invoke();
        }

        if (GamePause)
        {
            if (pauseTimeStart == -1)
            {
                pauseTimeStart = Time.fixedUnscaledTimeAsDouble;
                OnGamePause.Invoke();
            }
            pauseTime += Time.fixedUnscaledTimeAsDouble - pauseTimeStart;
        }
        else
        {
            pauseTimeStart = -1;
        }

        deltaTime = gameTime - Time.fixedUnscaledTimeAsDouble + pauseTime;

        if (lastTimeUpdate != (int)deltaTime)
        {
            lastTimeUpdate = (int)deltaTime;
            //Debug.Log(lastTimeUpdate);

            if (timerText != null)
            {
                timerText.text = "Timer: " + " " + SecondToTimeText(lastTimeUpdate);

            }
            else { Debug.Log("Timer: " + " " + SecondToTimeText(lastTimeUpdate)); }

            if (lastTimeUpdate <= 300 && MrCruz.WarningCount == 0)
            {
                MrCruz.PlayVoiceOver(DialogTypes.FiveMinWarning);
                MrCruz.WarningCount++;
            }
            else if (lastTimeUpdate <= 60 && MrCruz.WarningCount == 1)
            {
                MrCruz.PlayVoiceOver(DialogTypes.OneMinWarning);
                MrCruz.WarningCount++;
            }
        }

        if (deltaTime <= 0 && !GameEnd)
        {
            MrCruz.PlayVoiceOver(DialogTypes.BadEnding);
            
            GameEnd = true;

            deltaTime = -1;

            if (timerText != null)
            {
                timerText.text = "";
            }

            if (gameOverText != null)
            {
                gameOverText.text = "You Lose";
            }

            OnTimeOut.Invoke();
        }
    }
}
