using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] ActionManager _actionManager;
    void Start()
    {
        _actionManager.Enable();
        GameEvent.GameRestart += Restart;
        Restart();
    }

    public void Restart()
    {
        _actionManager.RestartGame();
    }

}
