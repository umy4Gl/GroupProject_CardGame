using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BaseInfoscr : MonoBehaviour
{
    public Base SelfBase;
    public Image LogoBase;
    public TextMeshProUGUI NameBase, Price, BaseMnozh;

    public void ShowBaseInfo(Base _base)
    {
        SelfBase = _base;

        LogoBase.sprite = _base.BaseLogo;
        //Logo.preserveAspect = true;
        NameBase.text = _base.BaseName;

        Price.text = SelfBase.PriceToUp.ToString();
        BaseMnozh.text = SelfBase.BaseMnozh.ToString();
    }


    private void Start()
    {
       // Debug.Log(transform.GetSiblingIndex()+1);
       //  ShowBaseInfo(BaseManager.AllBases[transform.GetSiblingIndex()]);
    }
}
