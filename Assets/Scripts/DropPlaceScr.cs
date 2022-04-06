using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum FieldType
{
    SELF_HAND,
    SELF_FIELD,
    ENEMY_HAND,
    ENEMY_FIELD
}

public class DropPlaceScr : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public FieldType Type;
    public ManaScr PlayerMana; // ManaScr ��� ����� �� �������� �� ����� ������, �� ���� ��������� ��� ������, �  PlayerMana - ��� ����������, ������� ����� ���������� ����� ������� � ���� ������ �� ManaScr
    public float ManaCost;
    public GameManagerScr GameManager;
   // public CardManagerScr GiveAT;

    public void OnDrop(PointerEventData eventData)
    {
        if (Type != FieldType.SELF_FIELD)
            return;  


        CardMovementScr card = eventData.pointerDrag.GetComponent<CardMovementScr>();

        ManaCost = eventData.pointerDrag.GetComponent<CardInfoScr>().SelfCard.Mana; //

        if (card && ManaCost*10 <= PlayerMana.ManaAmount)
        {
            card.DefaultParent = transform;
            PlayerMana.ReduceMana(true, card.GetComponent<CardInfoScr>().SelfCard.Mana * 10); //??
          //  GameManager.GiveCardToHand(GameManager.CurrentGame.PlayerDeck, GameManager.PlayerHand);
        }
           
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null || Type == FieldType.ENEMY_FIELD || Type == FieldType.ENEMY_HAND)
            return;

        CardMovementScr card = eventData.pointerDrag.GetComponent<CardMovementScr>();

        if (card)
            card.DefaultTempCardParent = transform;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
            return;

        CardMovementScr card = eventData.pointerDrag.GetComponent<CardMovementScr>();

        if (card && card.DefaultTempCardParent == transform)
            card.DefaultTempCardParent = card.DefaultParent;
    }
}
