using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//this is game manager which will manage loading of levels

public class PopsicleGameManager : MonoBehaviour
{
    //static variable 
    public static PopsicleGameManager popsicleGameManager;


    public Popsicles[] popsicles;
    public int totalScore;
    public int currentDay; // may change to order number
    public int  currentLevel; //starts from 0 


    //calculation variables
    int totalPopsicles;
    

    void Awake()
    {
        popsicleGameManager = this;
    }

    
    void Start()
    {   totalPopsicles = popsicles.Length;
        //load currentLevel
        LevelManager.levelManager.LoadCurrentLevel(popsicles[currentLevel],currentDay,totalScore);
    }

    public void LoadNextLevel()
    {
        currentLevel = (currentLevel + 1) % totalPopsicles ;
        LevelManager.levelManager.LoadCurrentLevel(popsicles[currentLevel],currentDay,totalScore);
    }

}
