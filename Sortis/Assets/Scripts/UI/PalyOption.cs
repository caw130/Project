using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalyOption : MonoBehaviour
{
    [SerializeField] GameObject _optionPanel;
    [SerializeField] Vector3 _openPos;
    [SerializeField] Vector3 _closePos;
    [SerializeField] float _openSpeed;

    public void Show()
    {
        _optionPanel.transform.DOKill();
        _optionPanel.SetActive(true);
        _optionPanel.transform.DOLocalMove(_openPos,_openSpeed).SetEase(Ease.OutCubic);
    }
    public void Hide()
    {
        _optionPanel.transform.DOKill();
        _optionPanel.transform.DOLocalMove(_closePos,_openSpeed).OnComplete(()=> _optionPanel.SetActive(false));
    }

    public void OpenOption()
    {
        Hide();
        GameManager.Instance.ShowOption();
    }

    public void ChangeScene()
    {
        GameEvent.InvokeGoMain();
    }
}
