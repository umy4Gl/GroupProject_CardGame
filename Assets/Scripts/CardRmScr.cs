using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardRmScr : MonoBehaviour
{
    public FieldType Ftype;
    public GamePointsScr CostToRm;
    public GamePointsScr RmMnozh;

    public void Rm()
    {
        if(Ftype == FieldType.SELF_FIELD)
        {
            CostToRm.CurrentPoints -= 20000;
            RmMnozh.CurrentMnozh -= this.GetComponent<CardInfoScr>().SelfCard.Mnozh;
            Destroy(this.gameObject);
        }
        if(Ftype != FieldType.SELF_FIELD)
        {
            return;
        }
    }
}
