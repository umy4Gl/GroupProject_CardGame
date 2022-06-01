using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBaseScr : MonoBehaviour
{
    public GameManagerScr Click;
 

    public void ok()
    {
        Click.SetUpNewBase(Click.CurrentGame.PlayerBases, Click.PlayerBasePlacement);
       
    }
}
