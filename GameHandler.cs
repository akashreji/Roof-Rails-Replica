using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class GameHandler : MonoBehaviour
{
    public static GameHandler current;
    private void Awake()
    {
        current = this;
    }

    public event Action gameHasStarted;
    public event Action gameHasEnded;
    public event Action<String> playerTriggeredEvent;
    public void PlayerTriggered(String item)
    {
        playerTriggeredEvent?.Invoke(item);
    }

    public void GameHasEndedFunc()
    {
        gameHasEnded?.Invoke();
    }


}
