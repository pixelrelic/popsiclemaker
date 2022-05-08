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
    public GameObject startScreen,commonScreen,fruitSelectionScreen,choppingsectionScreen,blendingSectionScreen,GlassFillingScreen,FreezSectionScreen,endScreen,serveScreen;
    
    //screen wise variables to control

    //1. common screen or HUD
    public Text orderidtext , scoreText;

    //2. Start Screen Information
    public Text orderText;

    //3. fruit selection screen loading bar
    public GameObject fruitSelectionLoadingBar;
    public GameObject fruitCuttingBar;
    public GameObject blendingBar;
    public GameObject glassFillingBar;

    public GameObject freezingBar;

    //4. General screen 
    public Text messageText;

    //5. fruit cutting section
    public GameObject chopBtn;

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


    public void SetFruitSelectionBarValues(int max)
    {
        fruitSelectionLoadingBar.GetComponent<Slider>().maxValue = max;
        fruitSelectionLoadingBar.GetComponent<Slider>().value = 0;
    }

    public void SetFruitCuttingBarValues(int max)
    {
        fruitCuttingBar.GetComponent<Slider>().maxValue = max;
        fruitCuttingBar.GetComponent<Slider>().value = 0;
    }

    public void FillFruitSelectionBar(int val)
    {
        fruitSelectionLoadingBar.GetComponent<Slider>().value = val;
    }
    public void FillFruitCuttingBar(int val)
    {
        fruitCuttingBar.GetComponent<Slider>().value = val;
    }

    public void SetBlendingBarValues(int max)
    {
        blendingBar.GetComponent<Slider>().maxValue = max;
        blendingBar.GetComponent<Slider>().value = 0;
    }

     public void FillBlendingBar(float val)
    {
        blendingBar.GetComponent<Slider>().value = val;
    }

    public void SetGlassFillingBarValues(float max)
    {
        glassFillingBar.GetComponent<Slider>().maxValue = max;
        glassFillingBar.GetComponent<Slider>().value = 0;
    }

     public void FillGlassFillingBar(float val)
    {
        glassFillingBar.GetComponent<Slider>().value = val;
    }

    public void SetFreezingBarValues(float max)
    {
        freezingBar.GetComponent<Slider>().maxValue = max;
        freezingBar.GetComponent<Slider>().value = 0;
    }

     public void FillFreezinggBar(float val)
    {
        freezingBar.GetComponent<Slider>().value = val;
    }

    public void SetMessageText(string message)
    {
        messageText.text = message;
    }
}
