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
    public ManaScr PlayerMana; // ManaScr это место из которого мы берем данные, то есть отдельный тип данных, а  PlayerMana - это переменная, которая после объявления может хранить в себе данные из ManaScr
    public float ManaCost;
    public GameManagerScr GameManager;
     int AmountOndeck = 0; //костыль надо фиксить

    public void OnDrop(PointerEventData eventData)
    {
        if (Type != FieldType.SELF_FIELD)
            return;  


        CardMovementScr card = eventData.pointerDrag.GetComponent<CardMovementScr>();

        ManaCost = eventData.pointerDrag.GetComponent<CardInfoScr>().SelfCard.Mana; //

        

        if (card && ManaCost*10 <= PlayerMana.ManaAmount && AmountOndeck<4) //костыль надо фиксить
        {
            card.DefaultParent = transform;
            PlayerMana.ReduceMana(true, card.GetComponent<CardInfoScr>().SelfCard.Mana * 10); //??
            GameManager.GiveCardToHand(GameManager.CurrentGame.PlayerDeck, GameManager.PlayerHand); //хз, вроде норм, но потом через GiveCards надо будет делать
            AmountOndeck++;//костыль надо фиксить
        }
           
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null || Type == FieldType.ENEMY_FIELD || Type == FieldType.ENEMY_HAND || AmountOndeck>=4) //костыль, надо фиксить
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
