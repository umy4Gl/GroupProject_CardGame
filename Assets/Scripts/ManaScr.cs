using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ManaScr : MonoBehaviour
{
    public Image ManaBar;
    public float ManaAmount = 0;
    public float SecondsToFull = 10f;

    void Start()
    {
        ManaBar.fillAmount = ManaAmount / 100;
        
    }

    void Update()
    { 

        if(ManaAmount < 100)
        {
           ManaAmount += 100 / SecondsToFull * Time.deltaTime;
            ManaBar.fillAmount = ManaAmount / 100;
        }
     
        
    }

    public void ReduceMana(bool PlayerMana, float _manacost)
    {
        if (PlayerMana)
            ManaAmount = Mathf.Clamp(ManaAmount - _manacost, 0, int.MaxValue);
     // else
     //     ManaAmount = ManaAmount;
    }


}
