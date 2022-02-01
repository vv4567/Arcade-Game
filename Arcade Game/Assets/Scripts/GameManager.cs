using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public double gameTime = 0;
    private double deltaTime = 0;
    private int lastTimeUpdate = -1;

    public Text timerText;
    public Text gameOverText;
    public GameObject player;
    public GameObject playerFirstPerson;

    private void Awake()
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
        if (deltaTime < 0)
        {
            return;
        }

        if (lastTimeUpdate == -1)
        {
            gameTime += Time.fixedUnscaledTimeAsDouble;
            lastTimeUpdate = 0;
        }

        deltaTime = gameTime - Time.fixedUnscaledTimeAsDouble;

        if (lastTimeUpdate != (int)deltaTime)
        {
            lastTimeUpdate = (int)deltaTime;
            //Debug.Log(lastTimeUpdate);

            if (timerText != null)
            {
                timerText.text = "Timer: " + " " + SecondToTimeText(lastTimeUpdate);
            }
        }

        if (deltaTime <= 0)
        {
            //Debug.Log("Time Out!");
            deltaTime = -1;

            if (timerText != null)
            {
                timerText.text = "";
            }

            if (gameOverText != null)
            {
                gameOverText.text = "Game Over";
            }

            if (player != null)
            {
                player.SetActive(false);
            }

            if (playerFirstPerson != null)
            {
                playerFirstPerson.SetActive(false);
            }
        }
    }
}
