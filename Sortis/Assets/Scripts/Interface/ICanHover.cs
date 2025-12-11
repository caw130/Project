using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 호버가 가능한 오브젝트
/// </summary>
interface ICanHover 
{
    // 해당 오브젝트가 호버가 가능한지 확인
    bool Hoverable { get; set; }

    // 마우스가 올라오면 실행
    void HoverIn();

    // 마우스가 나가면 실행
    void HoverOut();
}
