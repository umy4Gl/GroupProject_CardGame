using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public struct Card //структура для переменных информации карты
{
    public string Name; //имя карты
    public Sprite Logo; //картинка карты
    public float Mana; //мана карты
    public int Mnozh; //множитель карты

    public Card(string name, string logoPath, int mnozh, int mana) //функция для определения переменных карты
    {
        Name = name;
        Logo = Resources.Load<Sprite>(logoPath);
        Mnozh = mnozh;
        Mana = mana;
    }
}

public static class CardManager //класс для определения карт
{
    public static List<Card> AllCards = new List<Card>();
}

public class CardManagerScr : MonoBehaviour
{

    public void Awake() //конструктор со всеми картами
    {
        CardManager.AllCards.Add(new Card("Povarenok", "Sprites/Cards/Povarenok", 2, 1));
        CardManager.AllCards.Add(new Card("Suchief", "Sprites/Cards/Suchief", 3, 2));
        CardManager.AllCards.Add(new Card("Chief", "Sprites/Cards/Chief", 4, 3));
        CardManager.AllCards.Add(new Card("Feya", "Sprites/Cards/Feya", 5, 10));

    }
}
