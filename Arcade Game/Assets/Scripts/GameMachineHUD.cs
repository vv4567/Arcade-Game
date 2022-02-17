using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMachineHUD : MonoBehaviour
{
    //public int timer;
    public Text Timer;
    public Text Score;

    public GameMachine gameMachine;

    private void Start()
    {
        Timer.text = "Score: 00";
        Timer.text = "Timer: 00:00";
    }

    public string SecondToTimeText(double timeInSeconds)
    {
        string stringBuilder = "";
        int h = 0, m = 0, s = 0;

        h = (int)(timeInSeconds / 3600);
        m = (int)((timeInSeconds - h * 3600) / 60);
        s = (int)(timeInSeconds - h * 3600 - m * 60);

       /* if (h < 10)
        {
            stringBuilder += "0";
        }

        stringBuilder += h.ToString() + ":";
       */
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

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (gameMachine == null) { return; }

        double doubleTime = (double)gameMachine.getRemainingTime();

        if (Timer != null)
        { Timer.text = "Timer: " + SecondToTimeText(doubleTime); }

        if (Score != null)
        { Score.text = "Score: " + gameMachine.GetScore(); }
    }
}
