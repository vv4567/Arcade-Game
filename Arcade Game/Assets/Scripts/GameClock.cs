using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameClock : MonoBehaviour
{
    public TextMeshPro time;
    // Start is called before the first frame update
    void Start()
    {
      //  time = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (time != null)
        {
        time.text = GameManager.SecondToTimeText(GameManager.TimeLeft);
        }
        
    }
}
