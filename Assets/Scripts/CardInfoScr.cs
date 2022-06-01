using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardInfoScr : MonoBehaviour
{
    public Card SelfCard;//���������� ���������� ����� �����
    public Image Logo;//���������� �������� �����
    public TextMeshProUGUI Name, Mana, Mnozh;//��������� ���������� ���������� � �����
    public GameObject HideObj;

    public void HideCardInfo(Card card) //������� ��� ������� ���������� �����
    {
        SelfCard = card;
        HideObj.SetActive(true);
    }

    public void ShowCardInfo(Card card) //������� ��� ������ ���������� � �����
    {
        SelfCard = card;
        HideObj.SetActive(false);

        Logo.sprite = card.Logo;
        //Logo.preserveAspect = true;
        Name.text = card.Name;

        Mana.text = SelfCard.Mana.ToString();
        Mnozh.text = SelfCard.Mnozh.ToString();
    }


    private void Start() //������ �������� �������, ������� ����� ����
    {
       // ShowCardInfo(CardManager.AllCards[transform.GetSiblingIndex()]);
    }
}
