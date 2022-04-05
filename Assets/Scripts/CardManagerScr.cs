using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct Card
{
    public string Name;
    public Sprite Logo;
    public int Mana;
    public int Mnozh;

    public Card(string name, string logoPath, int mnozh, int mana)
    {
        Name = name;
        Logo = Resources.Load<Sprite>(logoPath);
        Mnozh = mnozh;
        Mana = mana;
    }
}

public static class CardManager
{
    public static List<Card> AllCards = new List<Card>();
}

public class CardManagerScr : MonoBehaviour
{

    public void Awake()
    {
        CardManager.AllCards.Add(new Card("Povarenok", "Sprites/Cards/Povarenok", 10, 1));
        CardManager.AllCards.Add(new Card("Suchief", "Sprites/Cards/Suchief", 20, 2));
        CardManager.AllCards.Add(new Card("Chief", "Sprites/Cards/Chief", 30, 3));
        CardManager.AllCards.Add(new Card("Feya", "Sprites/Cards/Feya", 100, 10));

    }
}
