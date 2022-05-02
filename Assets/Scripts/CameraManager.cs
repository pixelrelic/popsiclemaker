using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public CinemachineVirtualCamera customerCam,fruitsCam,chopperCam, fridgeCam,blenderCam,customerCam2;


    //global static variable
    public static CameraManager cameraManager;

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
        Debug.Log("A pressed");
        customerCam.Priority = 4;
        fruitsCam.Priority = 1;
        chopperCam.Priority = 2;
        fridgeCam.Priority = 3;
        blenderCam.Priority = 0;
    }
    public void SwitchToCutomerCam2()
    {   
        //Debug.Log("A pressed");
        customerCam2.Priority = 5;
        fruitsCam.Priority = 1;
        chopperCam.Priority = 2;
        fridgeCam.Priority = 3;
        blenderCam.Priority = 0;
        customerCam2.Priority = 4;
    }

     public void SwitchToFruitsCam()
    {
        //Debug.Log("B pressed");
        customerCam.Priority = 1;
        fruitsCam.Priority = 5;
        chopperCam.Priority = 2;
        fridgeCam.Priority = 3;
        blenderCam.Priority = 0;
        customerCam2.Priority = 4;
    }

     public void SwitchToChopperCam()
    {
        //Debug.Log("C pressed");
        customerCam.Priority = 2;
        fruitsCam.Priority = 1;
        chopperCam.Priority = 5;
        fridgeCam.Priority = 3;
        blenderCam.Priority = 0;
        customerCam2.Priority = 4;
    }

     public void SwitchToFridgeCam()
    {
        //Debug.Log("D pressed");
        customerCam.Priority = 3;
        fruitsCam.Priority = 1;
        chopperCam.Priority = 2;
        fridgeCam.Priority = 5;
        blenderCam.Priority = 0;
        customerCam2.Priority = 4;
    }

     public void SwitchToBlenderCam()
    {
        //Debug.Log("E pressed");
        customerCam.Priority = 0;
        fruitsCam.Priority = 1;
        chopperCam.Priority = 2;
        fridgeCam.Priority = 3;
        blenderCam.Priority = 5;
        customerCam2.Priority = 4;
    }


   void Update()
   {
    //HandleInputs();
   }

    //handing testing inputs for camera movements
   void HandleInputs()
   {
       if(Input.GetKeyDown(KeyCode.A))
       {
           SwitchToCutomerCam();
       }

       else if(Input.GetKeyDown(KeyCode.B))
       {
           SwitchToFruitsCam();
       }

       else if(Input.GetKeyDown(KeyCode.C))
       {
           SwitchToChopperCam();
       }

       else if(Input.GetKeyDown(KeyCode.D))
       {
           SwitchToFridgeCam();
       }

       else if(Input.GetKeyDown(KeyCode.E))
       {
           SwitchToBlenderCam();
       }
   }

}
