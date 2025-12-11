using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 클릭이 가능한 오브젝트
/// </summary>
interface ICanClick
{
    // 해당 오브젝트가 클릭이 가능한지 아닌지 설정
    bool Clickable { get; set; }

    // 해당 오브젝트가 클릭이 된다면 실행
    void OnClicked();
}
