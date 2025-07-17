using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface ICardStacker
{
    List<Card> SplitStackFrom(Card startCard);

    // 카드를 놓을 경우 실행
    void AddCard(Card card);

    // 카드를 여러장놓을 경우 실행
    void AddCard(List<Card> cards);

    // 카드를 제거 할 경우 실행
    void RemoveCard(Card card);

    // 대상을 자식 객체로 받기 위해 Transform은 무조건 존재해야함
    Transform transform { get; }
}
