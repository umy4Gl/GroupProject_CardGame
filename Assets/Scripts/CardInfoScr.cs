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
    public GameObject HideObj;

    public void HideCardInfo(Card card) //функци€ дл€ скрыти€ информаци€ карты
    {
        SelfCard = card;
        HideObj.SetActive(true);
    }

    public void ShowCardInfo(Card card) //функци€ дл€ показа информации о карте
    {
        SelfCard = card;
        HideObj.SetActive(false);

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
