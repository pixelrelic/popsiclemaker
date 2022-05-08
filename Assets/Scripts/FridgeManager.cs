using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeManager : MonoBehaviour
{
    
    public Animator fridgeAnimator;

    public void OpenFridge()
    {
        fridgeAnimator.SetBool("IsFridgeOpen",true);
    }

    public void CloseFridge()
    {
        fridgeAnimator.SetBool("IsFridgeOpen",false);
    }
}
