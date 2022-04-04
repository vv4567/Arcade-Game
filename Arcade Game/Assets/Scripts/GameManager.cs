using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public double gameTime = 0;
    private double deltaTime = 0;
    private int lastTimeUpdate = -1;
    private double pauseTime = 0;
    private double pauseTimeStart = -1;

    public Text timerText;
    public Text gameOverText;
    public GameObject player;
    public GameObject playerFirstPerson;

    public bool GameStart = false;
    public bool GamePause = false;
    public bool GameEnd = false;

    public UnityEvent OnGameStart;
    public UnityEvent OnGamePause;
    public UnityEvent OnGameEnd;


    private void OnEnable()
    {
        if (gameOverText != null)
        {
            gameOverText.text = "";
        }
    }

    public string SecondToTimeText(double timeInSeconds)
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
        }

        if (deltaTime <= 0 && !GameEnd)
        {
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

            OnGameEnd.Invoke();
        }
    }
}
