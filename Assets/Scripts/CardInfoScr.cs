using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardInfoScr : MonoBehaviour
{
    public Card SelfCard;
    public Image Logo;
    public TextMeshProUGUI Name, Mana, Mnozh;

    public void HideCardInfo(Card card)
    {
        SelfCard = card;
        Logo.sprite = null;
        //ShowCardInfo(card); // проверка на баги рандомной выдачи карт из колоды
       Name.text = "";
        Mana.text = "";
        Mnozh.text = "";
    }

    public void ShowCardInfo(Card card)
    {
        SelfCard = card;

        Logo.sprite = card.Logo;
        //Logo.preserveAspect = true;
        Name.text = card.Name;

        Mana.text = SelfCard.Mana.ToString();
        Mnozh.text = SelfCard.Mnozh.ToString();
    }


    private void Start()
    {
       // ShowCardInfo(CardManager.AllCards[transform.GetSiblingIndex()]);
    }
}
