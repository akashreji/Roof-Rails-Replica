using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableManager : MonoBehaviour
{
   // public int id; //to identify which gameobject has player collided with
  // [SerializeField] public static float diamondsCollected;
    void Start()
    {
        //GameHandler.current.playerTriggeredEvent += PlayerCollectedDiamonds;
    }

    //private void PlayerCollectedDiamonds(string item)
    //{
    //    if(item=="Diamonds")
    //    {
    //        diamondsCollected += 50;
    //    }
    //}    
   
    void Update()
    {
        
    }
    private void OnDestroy()
    {
        //GameHandler.current.playerTriggeredEvent -= PlayerCollectedDiamonds;
    }
}
