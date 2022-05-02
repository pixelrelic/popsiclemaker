using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    
    //global reference variable 
    public static LevelManager levelManager; 

    //level variables
    Popsicles currentPospsicle;

    //variable to know in which state game is currently
    //and according to that we need to handle inputs in update function 
    int currentSection = 0; // 0 start, 1 fruit selection, 2 chopping, 3 blending, 4 freez,  5 last screen 
    void Awake()
    {
        levelManager = this;
    }

    void update()
    {   
        //HandleInput();
    }

    //function to handle input according to current game state
    void HandleInput()
    {
        if(currentSection == 0)
        {
            Debug.Log("Start Screen");
        }
        else if(currentSection == 1)
        {
            Debug.Log("Fruit selection Screen");
        }
        else if(currentSection == 2)
        {
            Debug.Log("Chopping Screen");
        }
        else if(currentSection == 3)
        {
            Debug.Log("Blending Screen");
        }
        else if(currentSection == 4)
        {
            Debug.Log("Freez Screen");
        }
        else if(currentSection == 5)
        {
            Debug.Log("End Screen");
        }
    }

    public void LoadCurrentLevel(Popsicles popsicle,int orderID,int currentScore)
    {   
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
        currentSection = 1;
        //need to go to fruit selection screen
        CameraManager.cameraManager.SwitchToFruitsCam();
        //hide opening screen UI
        UIManager.uiManager.startScreen.SetActive(false);
        //show fruit selection UI
        UIManager.uiManager.fruitSelectionScreen.SetActive(true);
    }

    //Next button action is directly linked to load next level function in game manager 
    
    //fruit selection is complete
    //load chopping section
    void LoadChoppingSection()
    {   
        currentSection = 2;
        //need to go to Chopping screen
        CameraManager.cameraManager.SwitchToChopperCam();
        //Hide fruit selection UI
        UIManager.uiManager.fruitSelectionScreen.SetActive(false);
        //show chopping screen UI
        UIManager.uiManager.choppingsectionScreen.SetActive(true);    
    }

    //Chopping is complete
    //load Blending section
    void LoadBlendingSection()
    {   
        currentSection = 3;
        //need to go to Blending screen
        CameraManager.cameraManager.SwitchToBlenderCam();
        //Hide Chopping selection UI
        UIManager.uiManager.choppingsectionScreen.SetActive(false);
        //show blenderCam screen UI
        UIManager.uiManager.blendingSectionScreen.SetActive(true);    
    }

    //blending is complete
    //load freez section
    void LoadFreezingSection()
    {
        currentSection = 4;
        //need to go to freez screen
        CameraManager.cameraManager.SwitchToFridgeCam();
        //Hide Blender selection UI
        UIManager.uiManager.blendingSectionScreen.SetActive(false);
        //show freez screen UI
        UIManager.uiManager.FreezSectionScreen.SetActive(true);    
    }

    //on completion of level
    //go to customer camera again
    //and show some animation based on results
    void LevelComplete()
    {   
        currentSection = 5;    
        //need to go to Customer screen
        CameraManager.cameraManager.SwitchToCutomerCam2();
        //hide freez screen UI
        UIManager.uiManager.FreezSectionScreen.SetActive(false);
        //show end screen UI
        UIManager.uiManager.endScreen.SetActive(true); 
    }

}
