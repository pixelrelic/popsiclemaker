using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public CinemachineVirtualCamera customerCam,fruitsCam,chopperCam,glassCam,fridgeCam,blenderCam,customerCam2,popsicleCam;


    //global static variable
    public static CameraManager cameraManager;

    GameObject spawnedPopsicle;
    void Awake()
    {

        cameraManager = this;
    }


    void Start()
    {
        SwitchToCutomerCam2();
    }


    public void SwitchToCutomerCam()
    {   
        //Debug.Log("A pressed");
        customerCam.Priority = 5;
        fruitsCam.Priority = 1;
        chopperCam.Priority = 2;
        fridgeCam.Priority = 3;
        blenderCam.Priority = 0;
        glassCam.Priority = 4;
        popsicleCam.Priority = 1;
    }
    public void SwitchToCutomerCam2()
    {   
        //Debug.Log("Switching to customer cam");
        customerCam2.Priority = 6;
        fruitsCam.Priority = 1;
        chopperCam.Priority = 2;
        fridgeCam.Priority = 3;
        blenderCam.Priority = 0;
        customerCam2.Priority = 4;
        glassCam.Priority = 2;
        popsicleCam.Priority = 1;
    }

     public void SwitchToFruitsCam()
    {
        //Debug.Log("B pressed");
        customerCam.Priority = 1;
        fruitsCam.Priority = 6;
        chopperCam.Priority = 2;
        fridgeCam.Priority = 3;
        blenderCam.Priority = 0;
        customerCam2.Priority = 4;
        glassCam.Priority = 5;
        popsicleCam.Priority = 1;
    }

     public void SwitchToChopperCam()
    {
        //Debug.Log("C pressed");
        customerCam.Priority = 2;
        fruitsCam.Priority = 1;
        chopperCam.Priority = 6;
        fridgeCam.Priority = 3;
        blenderCam.Priority = 0;
        customerCam2.Priority = 4;
        glassCam.Priority = 5;
        popsicleCam.Priority = 1;
    }

     public void SwitchToGlassCam()
    {
        //Debug.Log("D pressed");
        customerCam.Priority = 3;
        fruitsCam.Priority = 1;
        chopperCam.Priority = 2;
        fridgeCam.Priority = 5;
        blenderCam.Priority = 0;
        customerCam2.Priority = 4;
        glassCam.Priority = 6;
        popsicleCam.Priority = 1;
    }

     public void SwitchToFridgeCam()
    {
        //Debug.Log("D pressed");
        customerCam.Priority = 3;
        fruitsCam.Priority = 1;
        chopperCam.Priority = 2;
        fridgeCam.Priority = 6;
        blenderCam.Priority = 0;
        customerCam2.Priority = 4;
        glassCam.Priority = 5;
        popsicleCam.Priority = 1;
    }

     public void SwitchToBlenderCam()
    {
        //Debug.Log("E pressed");
        customerCam.Priority = 0;
        fruitsCam.Priority = 1;
        chopperCam.Priority = 2;
        fridgeCam.Priority = 3;
        blenderCam.Priority = 6;
        customerCam2.Priority = 4;
        glassCam.Priority = 5;
        popsicleCam.Priority = 1;
    }

    public void SwitchToPopscileCam()
    {   
        popsicleCam.LookAt = spawnedPopsicle.transform;
        customerCam.Priority = 0;
        fruitsCam.Priority = 1;
        chopperCam.Priority = 2;
        fridgeCam.Priority = 3;
        blenderCam.Priority = 6;
        customerCam2.Priority = 4;
        glassCam.Priority = 5;
        popsicleCam.Priority = 7;
    }


    public void SetSpawnedPopsicle(GameObject popsicle)
    {
        spawnedPopsicle = popsicle;
    }

}
