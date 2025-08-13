using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] SoundManager _soundManager;
    [SerializeField] SceneChanger _sceneChanger;
    [SerializeField] OptionMenu _optionMenu;

    public static GameManager Instance { get; set; }

    public SoundManager SoundManager => _soundManager;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);

        }

        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        _soundManager.Initailize();
    }

    public void ChangeScene(int num)
    {
        _optionMenu.Close();
        _sceneChanger.SceneChange(num);
        
    }
    public Tween Hide()
    {
        return _sceneChanger.GetHide();
    }

    public void Show()
    {
        _sceneChanger.Show();
    }

    public void ShowOption()
    {
        _optionMenu.Open();
    }
    public void HideOption()
    {
        _optionMenu.Close();
    }
}
