using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���콺�� �ν��ϴ� �������̽�
/// </summary>
interface ICanHover 
{
    /// <summary>
    /// ���콺�� �ν� �ϴ°�?
    /// </summary>
    bool Hoverable { get; set; }

    /// <summary>
    /// ���콺�� ���� ���� ��
    /// </summary>
    void HoverIn();

    /// <summary>
    /// ���콺�� ��������
    /// </summary>
    void HoverOut();
}
