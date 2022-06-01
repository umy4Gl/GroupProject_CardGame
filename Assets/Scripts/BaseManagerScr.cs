using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//здесь вообще все то же самое, что и для карт, но уже с базами

[System.Serializable] 
public struct Base 
{
    public string BaseName;
    public int BaseMnozh, PriceToUp;
    public Sprite BaseLogo;

    public Base(string _basename, string _logoBase, int _baseMnozh, int _priceToUp)
    {
        BaseName = _basename;
        BaseLogo = Resources.Load<Sprite>(_logoBase);
        BaseMnozh = _baseMnozh;
        PriceToUp = _priceToUp;
    }
}

public static class BaseManager
{
    public static List<Base> AllBases = new List<Base>();
}

public class BaseManagerScr : MonoBehaviour
{
    public void Awake()
    {
        BaseManager.AllBases.Add(new Base("1", "Sprites/Bases/1", 1, 100000));
        BaseManager.AllBases.Add(new Base("2", "Sprites/Bases/2", 2, 200));
        BaseManager.AllBases.Add(new Base("2", "Sprites/Bases/2", 2, 100000));
        BaseManager.AllBases.Add(new Base("4", "Sprites/Bases/4", 4, 400));
        BaseManager.AllBases.Add(new Base("3", "Sprites/Bases/3", 3, 0));
    }
}