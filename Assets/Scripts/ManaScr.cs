using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ManaScr : MonoBehaviour //в этом классе мы делаем шкалу количества маны
{
    public Image ManaBar; //картинка уровня маны
    public float ManaAmount = 0; //переменная для кол-ва маны
    public float SecondsToFull = 10f; //переменная для кол-ва секунд до заполнения шкалы

    void Start() //функция, которая срабатывает при запуске игры
    {
        ManaBar.fillAmount = ManaAmount / 100; //начальное значение маны
        
    }

    void Update() //функция, которая срабатывает каждый кадр
    { 

        if(ManaAmount < 100) //проверка количества маны
        {
           ManaAmount += 100 / SecondsToFull * Time.deltaTime; //подсчет кол-ва маны
            ManaBar.fillAmount = ManaAmount / 100; //заполнение шкалы на основании кол-ва маны
        }
     
        
    }

    public void ReduceMana(bool PlayerMana, float _manacost) //функция для вычета маны
    {
        if (PlayerMana) //проверка на количество маны
            ManaAmount = Mathf.Clamp(ManaAmount - _manacost, 0, int.MaxValue); //вычет маны
     // else
     //     ManaAmount = ManaAmount;
    }


}
