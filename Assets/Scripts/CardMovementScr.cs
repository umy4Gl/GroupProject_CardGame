using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; //подключение библиотек юнити

public class CardMovementScr : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler //подключение интерфейсов юнити
{
    Camera MainCamera; //объявление главной камеры
    Vector3 offset; //переменная для отслеживания перемецения
    public Transform DefaultParent, DefaultTempCardParent; //объявление родителей
    GameObject TempCardGo; //переменная для обозначения объекта игры
    public bool IsDraggable; //переменная для проверки на возможность перемещения
   
    void Awake() //функция для объявления главных объектов игры
    {
        MainCamera = Camera.allCameras[0];
        TempCardGo = GameObject.Find("TempCardGO");
    }

    public void OnBeginDrag(PointerEventData eventData) //функция начала движения
    {
        offset = transform.position - MainCamera.ScreenToWorldPoint(eventData.position); //проверка позиции

        DefaultParent = DefaultTempCardParent = transform.parent; //смена родителя

        IsDraggable = DefaultParent.GetComponent<DropPlaceScr>().Type == FieldType.SELF_HAND; //присвоение переменной значения
   
       if (!IsDraggable) //проверка на возможность поднятия
                return;
            


        TempCardGo.transform.SetParent(DefaultParent);
        TempCardGo.transform.SetSiblingIndex(transform.GetSiblingIndex());

        transform.SetParent(DefaultParent.parent);  //
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        
    }
    public void OnDrag(PointerEventData eventData) //функция для карты в движении
    {
        if (!IsDraggable) //еще раз проверка
            return;

        Vector3 newPos = MainCamera.ScreenToWorldPoint(eventData.position); //движение карты
        transform.position = newPos + offset; //тоже движение

        if (TempCardGo.transform.parent != DefaultTempCardParent)//проверка
            TempCardGo.transform.SetParent(DefaultTempCardParent);//движение фоновой карты

        CheckPosition();//вызов функции для красивой анимации перетаскивания карты
    }
    public void OnEndDrag(PointerEventData eventData)//функция окончания движения карты
    {
        if (!IsDraggable) //и снова проверка
            return;

        transform.SetParent(DefaultParent); 
        GetComponent<CanvasGroup>().blocksRaycasts = true; //прикрепление карты к новой позиции

        transform.SetSiblingIndex(TempCardGo.transform.GetSiblingIndex());
        TempCardGo.transform.SetParent(GameObject.Find("Canvas").transform); //для всременной карты
        TempCardGo.transform.localPosition = new Vector3(1092, 0); //временная карта(которая еще фоновая) возврат на место
    }

    void CheckPosition() //функция для красивой анимации
    {
        int newIndex = DefaultTempCardParent.childCount;

        for(int i = 0; i < DefaultTempCardParent.childCount; i++)
        {
            if(transform.position.x < DefaultTempCardParent.GetChild(i).position.x)
            {
                newIndex = i;

                if(TempCardGo.transform.GetSiblingIndex() < newIndex)
                    newIndex--;

                break;
            }
        }

        TempCardGo.transform.SetSiblingIndex(newIndex);
    }

}

