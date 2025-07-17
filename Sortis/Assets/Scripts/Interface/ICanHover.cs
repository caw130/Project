using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 마우스를 인식하는 인터페이스
/// </summary>
interface ICanHover 
{
    /// <summary>
    /// 마우스를 인식 하는가?
    /// </summary>
    bool Hoverable { get; set; }

    /// <summary>
    /// 마우스가 위에 있을 때
    /// </summary>
    void HoverIn();

    /// <summary>
    /// 마우스가 떠났을때
    /// </summary>
    void HoverOut();
}
