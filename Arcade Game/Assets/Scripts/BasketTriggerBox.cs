using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BasketTriggerBox : MonoBehaviour
{ 
    public List<string> itemList;
    public List<int> scoreList;
    public int totalScore = 0;

    private void Start()
    {
        while (itemList.Count > scoreList.Count)
        {
            scoreList.Add(0);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<InteractableItem>() != null)
        {
            foreach (string item in itemList)
            {
                if (item == other.GetComponent<InteractableItem>().ItemID)
                {
                    totalScore += scoreList[itemList.IndexOf(item)];
                    Debug.Log(totalScore);
                    return;
                }
            }
        }
    }
}
