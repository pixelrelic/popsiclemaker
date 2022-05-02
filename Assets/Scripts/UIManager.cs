using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script will manage with UI screen to show and update text values
//main manager/level manager/game manager will call functions in this script to update data

public class UIManager : MonoBehaviour
{

    //global variable 
    public static UIManager uiManager;

    //all UI screen references 
    public GameObject startScreen,commonScreen,fruitSelectionScreen,choppingsectionScreen,blendingSectionScreen,FreezSectionScreen,endScreen;
    
    //screen wise variables to control

    //1. common screen or HUD
    public Text orderidtext , scoreText;

    //2. Start Screen Information
    public Text orderText;

    void Awake()
    {
            uiManager = this;
    }

    public void UpdateHUD(int orderid, int scoretext)
    {
        orderidtext.text = "Order " + orderid;
        scoreText.text = "" + scoretext;
    }

    public void UpdateCurrentOrderName(string fruitname)
    {
        orderText.text = fruitname + " popsicle please";
    }
}
