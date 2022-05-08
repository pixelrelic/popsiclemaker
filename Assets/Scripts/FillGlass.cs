using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillGlass : MonoBehaviour
{   

    public static FillGlass instance;
    public bool isGlassFilling;
    public Animator glassFillingAnimator;
    public GameObject glassFill;

    float glassFillTime;

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        isGlassFilling = false;
        glassFillTime = 0f;
        glassFill.GetComponent<Renderer>().material = LevelManager.levelManager.currentPospsicle.liquidMaterial; 
    }

    void Update()
    {
        if(isGlassFilling && glassFillingAnimator.speed == 1)
        {
            glassFillTime += Time.deltaTime;
            //fill bar
            UIManager.uiManager.FillGlassFillingBar(glassFillTime);
            //check if glass full and load next section
            //time is hardcoded here for assignment purpose only , change it later
            if(glassFillTime >= 3f)
            {
                isGlassFilling = false;
                glassFillingAnimator.speed = 0;
                LevelManager.levelManager.LoadFreezingSection();
            }

        }
    }

    public void ResetGlass()
    {
        isGlassFilling = false;
        glassFillTime = 0f;
        glassFill.GetComponent<Renderer>().material = LevelManager.levelManager.currentPospsicle.liquidMaterial;
        glassFillingAnimator.SetBool("FillGlass",false); 
    }

    public void StartFillingGlass()
    {   
            glassFill.GetComponent<Renderer>().material = LevelManager.levelManager.currentPospsicle.liquidMaterial;
            if(LevelManager.levelManager.currentSection == 4)
            {
                if(!isGlassFilling)
                {
                    glassFillingAnimator.speed = 1;
                    isGlassFilling = true;
                    glassFillingAnimator.SetBool("FillGlass",true);
                }
                else
                {
                    glassFillingAnimator.speed = 1;
                }
            }
        
    }
    public void StopFillingGlass()
    {   
        if(LevelManager.levelManager.currentSection == 4)
        {
            glassFillingAnimator.speed = 0;
        }
    }
}
