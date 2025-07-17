using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 클릭을 관리하는 인터페이스
/// </summary>
interface ICanClick
{
    /// <summary>
    /// 클릭 가능한가?
    /// </summary>
    bool Clickable { get; set; }

    /// <summary>
    /// 오브젝트가 클릭 되었을 때
    /// </summary>
    void OnClicked();
}
