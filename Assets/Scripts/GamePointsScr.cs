using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//в разработке

public class GamePointsScr : MonoBehaviour
{
    public Base CurrentBase;
    public int _currentBase = 1;
    public int CurrentMnozh =0;
    public float CurrentPoints = 0;
    public TextMeshProUGUI _currentPoints;
    public static GamePointsScr Points;

    private void Start()
    {
        Points = this;
    }

    void Update()
    {
        _currentBase = CurrentBase.BaseMnozh;
       // CurrentPoints = CurrentPoints + 1;
        CurrentPoints = CurrentPoints + _currentBase * CurrentMnozh;
        
        //Debug.Log(CurrentBase.BaseMnozh);
        //Debug.Log(CurrentMnozh);
        _currentPoints.text = CurrentPoints.ToString();
    }

   public void SetNewCardMnozh(int _cardMnozh)
    {
        CurrentMnozh += _cardMnozh;
    }

 
}
