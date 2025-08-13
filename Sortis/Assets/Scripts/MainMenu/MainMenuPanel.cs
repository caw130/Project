using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuPanel : MonoBehaviour
{
    bool _gameStart = false;
    public void GameStart()
    {
        if (_gameStart) return;
        GameManager.Instance.ChangeScene(1);
        _gameStart = true;
    }
    public void OptionOpen()
    {
        GameManager.Instance.ShowOption();
    }
    public void GameQuit()
    {
        Application.Quit();
    }
}
