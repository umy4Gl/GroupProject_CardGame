using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game
{
    public List<Card> EnemyDeck, PlayerDeck;
    public List<Base> PlayerBases, EnemyBases;

    public Game()
    {
        EnemyDeck = GiveDeckCard();
        PlayerDeck = GiveDeckCard();
        PlayerBases = SetUpBases();
        EnemyBases = SetUpBases();

    }

    List<Card> GiveDeckCard()
    {
        List<Card> list = new List<Card>();
        for (int i = 0; i < 100; i++)
            list.Add(CardManager.AllCards[Random.Range(0, CardManager.AllCards.Count)]);
        return list;
    }

    List<Base> SetUpBases()
    {
        List<Base> list = new List<Base>();
        for (int i = 0; i < BaseManager.AllBases.Count; i++)
        {
           // Debug.Log(i);
            list.Add(BaseManager.AllBases[i]);
        }
        return list;
    }
}

public class GameManagerScr : MonoBehaviour
{

    public Game CurrentGame; //���������� ��� ����������� �������
    public Transform EnemyHand, PlayerHand, PlayerBasePlacement, EnemyBasePlacement; //���������� ��� ���� �������
    public GameObject CardPref, BasePref; //������� �������

    public List<CardInfoScr> PlayerHandCards = new List<CardInfoScr>(), 
                             PlayerFieldCards = new List<CardInfoScr>(),
                             EnemyHandCards = new List<CardInfoScr>(),
                             EnemyFieldCards = new List<CardInfoScr>(); //���������� ��� ����� ����

    public List<BaseInfoscr> PlayerBaseNow = new List<BaseInfoscr>(),
                             EnemyBaseNow = new List<BaseInfoscr>(); //���������� ��� ����� ���
    public GamePointsScr pustBudet;
    public GameObject PreviousBase;
    int k = 0; //�������
    public bool flag = true;
    

    void Start() 
    {
        CurrentGame = new Game();

        GiveHandCards(CurrentGame.EnemyDeck, EnemyHand); //����� ������� ��� ���������� ���� ������
        GiveHandCards(CurrentGame.PlayerDeck, PlayerHand); //����� ������� ��� ���������� ���� ������
        SetUpNewBase(CurrentGame.PlayerBases, PlayerBasePlacement); //����� ������� ��� ��������� ����� ����
        SetUpNewBase(CurrentGame.EnemyBases, EnemyBasePlacement);
    }

    public void SetUpNewBase(List<Base> allBases, Transform currentBase) //����������� ������� � ������
    {

        if (allBases.Count > k && (pustBudet.CurrentPoints >= 100000 || flag==true))
        {
            // allBases[k - 1] = null;
            Debug.Log(k);

            Base _base = allBases[k];

            if (flag == false)
            {
                pustBudet.CurrentPoints -= 100000;
                //pustBudet.CurrentPoints -= allBases[k-1].PriceToUp;
            }
            
            
            flag = false;


            if (PreviousBase != null)
            {
                Destroy(PreviousBase);
            }

            GameObject BaseGo = Instantiate(BasePref, currentBase, false);
            PreviousBase = BaseGo;

            

            if(currentBase == EnemyBasePlacement)
            {
                BaseGo.GetComponent<BaseInfoscr>().ShowBaseInfo(_base);
                EnemyBaseNow.Add(BaseGo.GetComponent<BaseInfoscr>());
            }

            else 
            { 
                BaseGo.GetComponent<BaseInfoscr>().ShowBaseInfo(_base);
                PlayerBaseNow.Add(BaseGo.GetComponent<BaseInfoscr>());
            }
           

            allBases.RemoveAt(0);

            pustBudet.CurrentBase = BaseGo.GetComponent<BaseInfoscr>().SelfBase;
         
            k++;
           // Debug.Log(k);
        }

       // if (allBases.Count < k) return;
    
    }

    void GiveHandCards(List<Card> deck, Transform hand) //������� ��� ���������� ���� ������ 4�� �������
    {
        int i = 0; 
        while (i++ < 4)
            GiveCardToHand(deck, hand);
    }

    public void GiveCardToHand(List<Card> deck, Transform hand) //������� ��� ������ ������ �����
    {
        Card card = deck[0]; //������ ����� �� ����

        GameObject cardGO = Instantiate(CardPref, hand, false); //��� � ���� 

        if (hand == EnemyHand) //�������� ������ ������ �������� �����
        {
            cardGO.GetComponent<CardInfoScr>().HideCardInfo(card); //�������� ���� � ������ ����� �� ����
            EnemyHandCards.Add(cardGO.GetComponent<CardInfoScr>()); //������ ����� ��������
        }
        else
        {
            cardGO.GetComponent<CardInfoScr>().ShowCardInfo(card); //�������� ���� � ������ ����� �� ����
            PlayerHandCards.Add(cardGO.GetComponent<CardInfoScr>()); //������ ����� ������
        }
        deck.RemoveAt(0); //�������� ������� ����� � ����
    }

    public void GiveNewCards()
    {
        GiveCardToHand(CurrentGame.PlayerDeck, PlayerHand);
        GiveCardToHand(CurrentGame.EnemyDeck, EnemyHand);
    }
  
}
