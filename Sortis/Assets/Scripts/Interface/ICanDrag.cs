using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 드레그가 가능한 오브젝트
/// </summary>
public interface ICanDrag
{
    // 해당 오브젝트가 드래그가 가능한지 아닌지 설정
    bool Dragable { get; set; }

    // 해당 오브젝트가 드래그가 시작되면 실행
    void OnBeginDrag();

    // 해당 오브젝트가 
    void OnDrag(Vector2 pos);

    void OnDrop();
}
