using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 드래그를 관리하는 인터페이스
/// </summary>
public interface ICanDrag
{
    /// <summary>
    /// 드래그 가능한가?
    /// </summary>
    bool Dragable { get; set; }

    /// <summary>
    /// 드래그 시작
    /// </summary>
    void OnBeginDrag();

    /// <summary>
    /// 드래그 중
    /// </summary>
    /// <param name="pos">마우스의 위치</param>
    void OnDrag(Vector2 pos);

    /// <summary>
    /// 드래그 끝
    /// </summary>
    void OnDrop();
}
