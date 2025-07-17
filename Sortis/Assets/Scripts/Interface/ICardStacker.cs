using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface ICardStacker
{
    List<Card> SplitStackFrom(Card startCard);

    // ī�带 ���� ��� ����
    void AddCard(Card card);

    // ī�带 ��������� ��� ����
    void AddCard(List<Card> cards);

    // ī�带 ���� �� ��� ����
    void RemoveCard(Card card);

    // ����� �ڽ� ��ü�� �ޱ� ���� Transform�� ������ �����ؾ���
    Transform transform { get; }
}
