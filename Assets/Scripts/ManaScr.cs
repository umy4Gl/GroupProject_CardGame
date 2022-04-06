using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        ManaAmount += 100 / SecondsToFull * Time.deltaTime;
            ManaBar.fillAmount = ManaAmount / 100;
     /*   if(ManaAmount < 100)
        {
           
        }
        */
    }
}
