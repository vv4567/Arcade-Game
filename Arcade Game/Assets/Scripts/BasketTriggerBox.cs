using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class BasketTriggerBox : MonoBehaviour
{ 
    public List<string> ItemList;
    public List<int> ScoreList;
    public GameMachine GameMachine;
    public List<UnityEvent> OnScoredList;

    public bool shouldDestroyObject = true;

    private void Start()
    {
        while (ItemList.Count > ScoreList.Count)
        {
            ScoreList.Add(0);
        }
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<InteractableItem>() != null)
        {
            foreach (string item in ItemList)
            {
                if (item == other.GetComponent<InteractableItem>().ItemID)
                {
                    GameMachine.AddScore(ScoreList[ItemList.IndexOf(item)]);

                    if (shouldDestroyObject)
                    { Destroy(other.gameObject); }

                    OnScoredList[ItemList.IndexOf(item)].Invoke();
                    //GameMachine.SpawnBalls(1);

                    //Debug.Log(totalScore);
                    return;
                }
            }
        }
    }
}
