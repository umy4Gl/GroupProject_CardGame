using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; //библиотеки юнити

public enum FieldType //тип полей
{
    SELF_HAND,
    SELF_FIELD,
    ENEMY_HAND,
    ENEMY_FIELD
}

public class DropPlaceScr : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler //подключаем интерфейсы из библиотек юнити
{
    public FieldType Type; //переменна€ дл€ пита пол€
    public ManaScr PlayerMana; // ManaScr это место из которого мы берем данные, то есть отдельный тип данных, а  PlayerMana - это переменна€, котора€ после объ€влени€ может хранить в себе данные из ManaScr
    public float ManaCost; //мана стоимость карты 
    public GameManagerScr GameManager; //переменна€ типа GamrManagerScr
    public GamePointsScr MnozhNow; //ѕеременна€ “ипа GamePointScr
    int AmountOndeck = 0; //костыль надо фиксить

    public void OnDrop(PointerEventData eventData) //функци€ срабатывающа€ в момент подн€ти€ карты
    {
        if (Type != FieldType.SELF_FIELD) //проверка на поле в момент подн€ти€
            return;

        CardMovementScr card = eventData.pointerDrag.GetComponent<CardMovementScr>(); //переменна€ дл€ определени€ движени€ карты
        
        ManaCost = eventData.pointerDrag.GetComponent<CardInfoScr>().SelfCard.Mana; //переменна€ дл€ определени€ мана стоимости карты

        if(card.DefaultParent != transform) //нагл€дный if дл€ фикса проблемы с подн€тием карты со стола
        {
            if (card && ManaCost*10 <= PlayerMana.ManaAmount && AmountOndeck<4) //костыль надо фиксить, а так же проверка на наличие необходимого кол-ва маны и возможностью ее подн€ти€
                  {
                      card.DefaultParent = transform; //смена позиции карты
                      PlayerMana.ReduceMana(true, card.GetComponent<CardInfoScr>().SelfCard.Mana * 10); //вызов функции на уменьшение маны
                      GameManager.GiveCardToHand(GameManager.CurrentGame.PlayerDeck, GameManager.PlayerHand); //хз, вроде норм, но потом через GiveCards надо будет делать
                      //Debug.Log(card.GetComponent<CardInfoScr>().SelfCard.Mnozh);
                     // MnozhNow.SetNewCardMnozh(card.GetComponent<CardInfoScr>().SelfCard.Mnozh);
                      AmountOndeck++;//костыль надо фиксить
        }
        }

      
           
    }

    public void OnPointerEnter(PointerEventData eventData) //функци€ на перетаскивание карты 
    {
        if (eventData.pointerDrag == null || Type == FieldType.ENEMY_FIELD || Type == FieldType.ENEMY_HAND || AmountOndeck>=4) //костыль, надо фиксить, а так же проверка на пол€, возможность положить карту не была продемонстрирована
            return;

        CardMovementScr card = eventData.pointerDrag.GetComponent<CardMovementScr>();

        if (card)
            card.DefaultTempCardParent = transform; //временна€ карта мен€ет позицию
    }

    public void OnPointerExit(PointerEventData eventData) //функци€ при отпускании карты
    {
        if (eventData.pointerDrag == null) //если карту невозможно положить, фон убираетс€
            return;

        CardMovementScr card = eventData.pointerDrag.GetComponent<CardMovementScr>();

        if (card && card.DefaultTempCardParent == transform)
            card.DefaultTempCardParent = card.DefaultParent;
    }
}
