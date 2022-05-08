using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutGlassInFridge : MonoBehaviour
{
    public static PutGlassInFridge instance;    
    //glass putting animation is 3 sec
    //open fridge put glass in 
    //and close fridge

    float timer,freezTimer;
    bool isFreezing = false;

    public Vector3 startPosition;
    public Vector3 initialScale;
    public Vector3 finalScale;
    public Animator glassFillAnimator,FridgeDooranimator,serveAnimator;

    public GameObject cookedPopsicle;
    public Transform cookedPopsiclePosition;
    bool isPOpsicleSpawned = false;
    public float serveTimer = 0f;
    public GameObject popsicle;

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        timer = 0;
        freezTimer = 0;
        isPOpsicleSpawned = false;
        serveTimer = 0f;
    }

    void Update()
    {
        if(LevelManager.levelManager.currentSection == 5 && !isPOpsicleSpawned )
        {
            //start timer and start animations
            //1. open fridge
            OpenFridge();
            //2. put glass in fridge
            GlassInFridge();
            timer += Time.deltaTime;

            //TODO : time here is hardcoded change later
            if(timer >=  3)
            {
                //close fridge and stop glass animation
                CloseFridge();
                glassFillAnimator.speed = 0;
                //start Freezing
                isFreezing = true;
            }

            if(isFreezing)
            {
                freezTimer += Time.deltaTime;
                //fill bar
                UIManager.uiManager.FillFreezinggBar(freezTimer);

                if(freezTimer >= LevelManager.levelManager.currentPospsicle.freezTime)
                {   
                    Debug.Log("Show Popsicle");    
                    popsicle =  Instantiate(cookedPopsicle,cookedPopsiclePosition);
                    popsicle.GetComponent<ChangeFlavour>().ChangeFlavourOfPopscile(LevelManager.levelManager.currentPospsicle.liquidMaterial);


                    //section complete
                    LevelManager.levelManager.LevelComplete();
                    ResetGlass();
                    //put popsicle at the place of glass in fridge
                    // if(!isPOpsicleSpawned)
                    // {
                    //     popsicle =  Instantiate(cookedPopsicle,transform);
                    //     popsicle.GetComponent<ChangeFlavour>().ChangeFlavourOfPopscile(LevelManager.levelManager.currentPospsicle.liquidMaterial);
                    //     popsicle.transform.position = new Vector3(0,0,0)
                    //     //get animator
                    //     popsicle.GetComponent<Animator>().SetBool("Serve",true);

                    //     CameraManager.cameraManager.SetSpawnedPopsicle(popsicle.transform.GetChild(0).transform.GetChild(1).gameObject);
                    //     CameraManager.cameraManager.SwitchToPopscileCam();

                    //     isPOpsicleSpawned = true;
                    //     //popsicle.transform.localScale = finalScale;
                    //     //ResetGlass();
                    //     //now open fridge
                    //     OpenFridge();
                    // }                                        
                } 
            }
        }
        // else if(LevelManager.levelManager.currentSection == 5 && isPOpsicleSpawned)
        // {
        //     serveTimer += Time.deltaTime;
        //     if(serveTimer >= 8)
        //     {
        //         //level Complete
        //         LevelManager.levelManager.LevelComplete();
        //         Destroy(popsicle);
        //     }
        // }
        
    }

    public void ResetGlass()
    {
        transform.position = startPosition;
        transform.localScale = initialScale;
        glassFillAnimator.SetBool("PutGlass",false);
        glassFillAnimator.speed = 1;
        timer = 0;
        freezTimer = 0;
        isFreezing = false;
        isPOpsicleSpawned = false;
        serveTimer = 0f;

    }

    public void OpenFridge()
    {
        FridgeDooranimator.SetBool("IsFridgeOpen",true);
        Debug.Log("Fridge Open");
    }

    public void CloseFridge()
    {
        FridgeDooranimator.SetBool("IsFridgeOpen",false);
    }

    public void GlassInFridge()
    {
        glassFillAnimator.SetBool("PutGlass",true);
    }
}
