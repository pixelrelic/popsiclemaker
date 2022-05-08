using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    
    //global reference variable 
    public static LevelManager levelManager; 

    //level variables
    public Popsicles currentPospsicle;

    public Animator customerDanceAnimator;

    //variable to know in which state game is currently
    //and according to that we need to handle inputs in update function 
    public int currentSection = 0; // 0 start, 1 fruit selection, 2 chopping, 3 blending, 4 freez,  5 last screen 
    void Awake()
    {
        levelManager = this;
    }


    public void LoadCurrentLevel(Popsicles popsicle,int orderID,int currentScore)
    {   
        customerDanceAnimator.SetBool("Dance",false);
        Destroy(PutGlassInFridge.instance.popsicle);
        currentSection = 0;
        currentPospsicle = popsicle;
        //goto first screen
        CameraManager.cameraManager.SwitchToCutomerCam2();
        //load level data like order number score and level fruit name
        UIManager.uiManager.UpdateHUD(orderID,currentScore);
        UIManager.uiManager.UpdateCurrentOrderName(currentPospsicle.fruitName);

        //and show screens
        UIManager.uiManager.startScreen.SetActive(true);
        UIManager.uiManager.commonScreen.SetActive(true);
    }

    //user presses start button after loading of level so this
    //function is wriiten in levelManager
    
    //start button action
    public void StartGame()
    {   
        customerDanceAnimator.SetBool("Dance",false);

        //delete old popsicle
        //Destroy(PutGlassInFridge.instance.popsicle);

        currentSection = 1;
        //need to go to fruit selection screen
        CameraManager.cameraManager.SwitchToFruitsCam();

        //reset fruit selectionBar
        UIManager.uiManager.SetFruitSelectionBarValues(currentPospsicle.requiredFruits);
        //reset plate menager
        PlateManagment.instance.ResetPlateManager();

        //move plate infront of froot selection screen
        PlateManagment.instance.MovePlateToEndPos();

        //hide opening screen UI
        UIManager.uiManager.startScreen.SetActive(false);
        //show fruit selection UI
        UIManager.uiManager.fruitSelectionScreen.SetActive(true);


        //show message
        UIManager.uiManager.SetMessageText("collect "+ currentPospsicle.requiredFruits+" "+currentPospsicle.fruitName+"s. Tap on them to collect");
    }

    //Next button action is directly linked to load next level function in game manager 
    
    //fruit selection is complete
    //load chopping section
    public void LoadChoppingSection()
    {   
        StartCoroutine("Waiting",1);
        currentSection = 2;
        //reset chopping section
        KnifeController.instance.ResetChoppingSection();
        UIManager.uiManager.SetMessageText("Tap on all fruits on dish first to take them for chopping.");
        //reset fruit selectionBar
        UIManager.uiManager.SetFruitCuttingBarValues(currentPospsicle.choppingTime);
        //need to go to Chopping screen
        CameraManager.cameraManager.SwitchToChopperCam();
        //move plate on Chopping table
        PlateManagment.instance.MovePlateToStartPos();
        //Hide fruit selection UI
        UIManager.uiManager.fruitSelectionScreen.SetActive(false);
        //show chopping screen UI
        UIManager.uiManager.choppingsectionScreen.SetActive(true);    
    }

    IEnumerator Waiting(float time)
    {
        yield return new WaitForSeconds(time);
    }


    //Chopping is complete
    //load Blending section
    public void LoadBlendingSection()
    {   
        UIManager.uiManager.SetMessageText("");
        UIManager.uiManager.FillFruitCuttingBar(0);
        UIManager.uiManager.chopBtn.SetActive(false);
        //reset Grinder
        GrinderController.instance.ResetGrindingSection();

        currentSection = 3;
        //set blending bar values
        //blending time is hardcoded here
        //change later
        UIManager.uiManager.SetBlendingBarValues(5);
        //need to go to Blending screen
        CameraManager.cameraManager.SwitchToBlenderCam();
        //move pieces to blender
        PlateManagment.instance.MoveCutPiecesToBlender();
        //Hide Chopping selection UI
        UIManager.uiManager.choppingsectionScreen.SetActive(false);
        //show blenderCam screen UI
        UIManager.uiManager.blendingSectionScreen.SetActive(true);    
    }

    //blending is complete
    //load Glass pouring section
    public void LoadGlassPouringSection()
    {   
        UIManager.uiManager.SetMessageText("");
        //Debug.Log("Loading glass section");
        currentSection = 4;
        //reset blending section
        GrinderController.instance.ResetGrindingSection();
        //remove fruit pieces from blender
        PlateManagment.instance.RemoveCutPiecesFromBlender();

        UIManager.uiManager.SetGlassFillingBarValues(3);

        //need to go to glass pour  screen
        CameraManager.cameraManager.SwitchToGlassCam();
        //Hide Blender selection UI
        UIManager.uiManager.blendingSectionScreen.SetActive(false);
        //show Glass filling screen UI
        UIManager.uiManager.GlassFillingScreen.SetActive(true);    
    }

    //puoring into glass is complete
    //load freez section
    public void LoadFreezingSection()
    {   
        UIManager.uiManager.SetMessageText("");
        currentSection = 5;
        UIManager.uiManager.SetFreezingBarValues(currentPospsicle.freezTime);
        //need to go to freez screen
        CameraManager.cameraManager.SwitchToFridgeCam();
        //Hide Glass filling selection UI
        UIManager.uiManager.GlassFillingScreen.SetActive(false);
        //show freez screen UI
        UIManager.uiManager.FreezSectionScreen.SetActive(true);    
    }

    //on completion of level
    //go to customer camera again
    //and show some animation based on results
    public void LevelComplete()
    {   
        //play dance animation
        customerDanceAnimator.SetBool("Dance",true);
        UIManager.uiManager.SetMessageText("");
        currentSection = 6;
        //reset glass
        FillGlass.instance.ResetGlass();

        //need to go to Customer screen
        CameraManager.cameraManager.SwitchToCutomerCam();
        //hide freez screen UI
        UIManager.uiManager.FreezSectionScreen.SetActive(false);
        //show end screen UI
        UIManager.uiManager.endScreen.SetActive(true);
        PopsicleGameManager.popsicleGameManager.totalScore += 100;
        UIManager.uiManager.UpdateHUD(PopsicleGameManager.popsicleGameManager.currentDay,PopsicleGameManager.popsicleGameManager.totalScore);

    }
}
