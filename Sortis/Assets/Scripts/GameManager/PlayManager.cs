using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayManager : MonoBehaviour
{
    [SerializeField] ActionManager _actionManager;
    void Awake()
    {
        _actionManager.Enable();
        GameEvent.GameRestart += Restart;
        GameEvent.GoMain += GoToMain;
        _actionManager.GameStart();
        Restart();
    }

    public void Restart()
    {
        _actionManager.RestartGame();
    }

    void GoToMain()
    {
        _actionManager.Disable();
        GameEvent.GameRestart -= Restart;
        GameEvent.GoMain -= GoToMain;
        GameManager.Instance.ChangeScene(0);
    }

}
