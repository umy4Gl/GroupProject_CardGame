using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardInfoScr : MonoBehaviour
{
    public Card SelfCard;//объ€вление переменной новой карты
    public Image Logo;//переменна€ картинки карты
    public TextMeshProUGUI Name, Mana, Mnozh;//об€вление переменных информации о карте

    public void HideCardInfo(Card card) //функци€ дл€ скрыти€ информаци€ карты
    {
        SelfCard = card;
        Logo.sprite = null;
        //ShowCardInfo(card); // проверка на баги рандомной выдачи карт из колоды
       Name.text = "";
        Mana.text = "";
        Mnozh.text = "";
    }

    public void ShowCardInfo(Card card) //функци€ дл€ показа информации о карте
    {
        SelfCard = card;

        Logo.sprite = card.Logo;
        //Logo.preserveAspect = true;
        Name.text = card.Name;

        Mana.text = SelfCard.Mana.ToString();
        Mnozh.text = SelfCard.Mnozh.ToString();
    }


    private void Start() //стара€ ненужна€ функци€, оставил чтобы было
    {
       // ShowCardInfo(CardManager.AllCards[transform.GetSiblingIndex()]);
    }
}
