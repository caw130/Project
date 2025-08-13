using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionMenu : MonoBehaviour
{
    [SerializeField] GameObject _uiPanel;
    [SerializeField] Vector3 _hidepos;
    [SerializeField] Vector3 _showpos;
    [SerializeField] float _showtime;
    [SerializeField] Ease openEase;
    [SerializeField] Ease closeEase;
    public void Open()
    {
        _uiPanel.transform.DOKill();
        _uiPanel.SetActive(true);
        _uiPanel.transform.DOLocalMove(_showpos, _showtime).SetEase(openEase);
    }
    public void Close()
    {
        _uiPanel.transform.DOKill();
        _uiPanel.transform.DOLocalMove(_hidepos,_showtime).SetEase(closeEase).OnComplete(()=> _uiPanel.SetActive(false));
    }
}
