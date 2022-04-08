using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game
{
    public List<Card> EnemyDeck, PlayerDeck;
    public List<Base> PlayerBases;

    public Game()
    {
        EnemyDeck = GiveDeckCard();
        PlayerDeck = GiveDeckCard();
        PlayerBases = SetUpBases();

    }

    List<Card> GiveDeckCard()
    {
        List<Card> list = new List<Card>();
        for (int i = 0; i < 10; i++)
            list.Add(CardManager.AllCards[Random.Range(0, CardManager.AllCards.Count)]);
        return list;
    }

    List<Base> SetUpBases()
    {
        List<Base> list = new List<Base>();
        for(int i = 0; i < BaseManager.AllBases.Count; i++)
            list.Add(BaseManager.AllBases[i]);
        return list;
    }
}

public class GameManagerScr : MonoBehaviour
{

    public Game CurrentGame;
    public Transform EnemyHand, PlayerHand, PlayerBasePlacement;
    public GameObject CardPref, BasePref;

    public List<CardInfoScr> PlayerHandCards = new List<CardInfoScr>(),
                             PlayerFieldCards = new List<CardInfoScr>(),
                             EnemyHandCards = new List<CardInfoScr>(),
                             EnemyFieldCards = new List<CardInfoScr>();

    public List<BaseInfoscr> PlayerBaseNow = new List<BaseInfoscr>();
    int k = 0;

    void Start()
    {
        CurrentGame = new Game();

        GiveHandCards(CurrentGame.EnemyDeck, EnemyHand);
        GiveHandCards(CurrentGame.PlayerDeck, PlayerHand);
        SetUpNewBase(CurrentGame.PlayerBases, PlayerBasePlacement);
    }

    public void SetUpNewBase(List<Base> allBases, Transform currentBase)
    {

        if (allBases.Count >= k)
        {
            Base _base = allBases[k];

            GameObject BaseGo = Instantiate(BasePref, currentBase, false);

            BaseGo.GetComponent<BaseInfoscr>().ShowBaseInfo(_base);
            PlayerBaseNow.Add(BaseGo.GetComponent<BaseInfoscr>());

            allBases.RemoveAt(0);

            k++;
        }

        else
            return;
    
    }

    void GiveHandCards(List<Card> deck, Transform hand)
    {
        int i = 0;
        while (i++ < 4)
            GiveCardToHand(deck, hand);
    }

    public void GiveCardToHand(List<Card> deck, Transform hand)
    {
        Card card = deck[0];

        GameObject cardGO = Instantiate(CardPref, hand, false);

        if (hand == EnemyHand)
        {
            cardGO.GetComponent<CardInfoScr>().HideCardInfo(card);
            EnemyHandCards.Add(cardGO.GetComponent<CardInfoScr>());
        }
        else
        {
            cardGO.GetComponent<CardInfoScr>().ShowCardInfo(card);
            PlayerHandCards.Add(cardGO.GetComponent<CardInfoScr>());
        }
        deck.RemoveAt(0);
    }

    public void GiveNewCards()
    {
        GiveCardToHand(CurrentGame.PlayerDeck, PlayerHand);
        GiveCardToHand(CurrentGame.EnemyDeck, EnemyHand);
    }
  
}
