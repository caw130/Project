using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �巡�׸� �����ϴ� �������̽�
/// </summary>
public interface ICanDrag
{
    /// <summary>
    /// �巡�� �����Ѱ�?
    /// </summary>
    bool Dragable { get; set; }

    /// <summary>
    /// �巡�� ����
    /// </summary>
    void OnBeginDrag();

    /// <summary>
    /// �巡�� ��
    /// </summary>
    /// <param name="pos">���콺�� ��ġ</param>
    void OnDrag(Vector2 pos);

    /// <summary>
    /// �巡�� ��
    /// </summary>
    void OnDrop();
}
