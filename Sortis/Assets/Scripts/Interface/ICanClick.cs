using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ŭ���� �����ϴ� �������̽�
/// </summary>
interface ICanClick
{
    /// <summary>
    /// Ŭ�� �����Ѱ�?
    /// </summary>
    bool Clickable { get; set; }

    /// <summary>
    /// ������Ʈ�� Ŭ�� �Ǿ��� ��
    /// </summary>
    void OnClicked();
}
