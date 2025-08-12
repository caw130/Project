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
            Debug.Log("Hello");
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
}
