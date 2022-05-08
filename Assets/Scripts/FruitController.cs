using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitController : MonoBehaviour
{
    void Update()
    {
       HandleInputPC();
       //HandleInputMobile();
    }

    void HandleInputPC()
    {
         //need to handle click here
        //to select fruit
        //if current section is fruit section then only process fruit clicks
        if (Input.GetMouseButtonDown(0) && LevelManager.levelManager.currentSection == 1)
        {   
            //Debug.Log("Touch Detetcted");
            GameObject fruitSelected =  GetClickedGameObject();
            if(fruitSelected != null)
            {   
                //validation section
                //what to validate here
                //as we are selecting fruits and we have required numbers
                //1. we need to check if right fruit is selcted or not
                //2. if required quantity is fullfilled or not for current popsicle order
                //if all condition met move fruit to plate
                //and if all fruits collected move to chopping section

                int fruitid = LevelManager.levelManager.currentPospsicle.fruitID;
                int requiredFruits = LevelManager.levelManager.currentPospsicle.requiredFruits;
                //Debug.Log("Required fruit id is : "+fruitid+" and clicked fruit id is : "+fruitSelected.GetComponent<Fruit>().fruitID);
                if(fruitid == fruitSelected.GetComponent<Fruit>().fruitID)
                {   
                    // Debug.Log("correct fruit selected");
                    // Debug.Log(" current object count : "+ PlateManagment.instance.currentObjectCount+ " required fruits : "+ requiredFruits);
                    //correct fruit clicked/selected
                    if(PlateManagment.instance.currentObjectCount-1 < requiredFruits ) //plate is empty
                    {   

                        //move object into plate
                        PlateManagment.instance.MoveObjectToPlate(fruitSelected);
                        if(PlateManagment.instance.currentObjectCount == requiredFruits)
                        {
                            //required fruits collected
                            //move to chopping section
                            LevelManager.levelManager.LoadChoppingSection();
                            PlateManagment.instance.MovePlateToStartPos();
                        }
                    }   
                }
                else
                {
                    Debug.Log("Wrong fruit selected");
                }

                //Debug.Log(fruitSelected.GetComponent<Fruit>().fruitName +" Fruit selected.");
            }   
        }


        else if(Input.GetMouseButtonDown(0) && LevelManager.levelManager.currentSection == 2) //chopping section
            {
                // Debug.Log("Clicked on fruit when its in plate for chopping");
                GameObject fruitSelectedAgain =  GetClickedGameObject();
                if(fruitSelectedAgain != null)
                {
                    //move fruit on chopper
                    PlateManagment.instance.MoveObjectOutOfPlate(fruitSelectedAgain);

                } 

            }
    }

    void HandleInputMobile()
    {
         //need to handle click here
        //to select fruit
        //if current section is fruit section then only process fruit clicks
        if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began && LevelManager.levelManager.currentSection == 1)
        {   
            //Debug.Log("Touch Detetcted");
            GameObject fruitSelected =  GetClickedGameObjectMobile();
            if(fruitSelected != null)
            {   
                //validation section
                //what to validate here
                //as we are selecting fruits and we have required numbers
                //1. we need to check if right fruit is selcted or not
                //2. if required quantity is fullfilled or not for current popsicle order
                //if all condition met move fruit to plate
                //and if all fruits collected move to chopping section

                int fruitid = LevelManager.levelManager.currentPospsicle.fruitID;
                int requiredFruits = LevelManager.levelManager.currentPospsicle.requiredFruits;
                //Debug.Log("Required fruit id is : "+fruitid+" and clicked fruit id is : "+fruitSelected.GetComponent<Fruit>().fruitID);
                if(fruitid == fruitSelected.GetComponent<Fruit>().fruitID)
                {   
                    // Debug.Log("correct fruit selected");
                    // Debug.Log(" current object count : "+ PlateManagment.instance.currentObjectCount+ " required fruits : "+ requiredFruits);
                    //correct fruit clicked/selected
                    if(PlateManagment.instance.currentObjectCount-1 < requiredFruits ) //plate is empty
                    {   

                        //move object into plate
                        PlateManagment.instance.MoveObjectToPlate(fruitSelected);
                        if(PlateManagment.instance.currentObjectCount == requiredFruits)
                        {
                            //required fruits collected
                            //move to chopping section
                            LevelManager.levelManager.LoadChoppingSection();
                            PlateManagment.instance.MovePlateToStartPos();
                        }
                    }   
                }
                else
                {
                    Debug.Log("Wrong fruit selected");
                }

                //Debug.Log(fruitSelected.GetComponent<Fruit>().fruitName +" Fruit selected.");
            }   
        }


        else if(Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began && LevelManager.levelManager.currentSection == 2) //chopping section
            {
                // Debug.Log("Clicked on fruit when its in plate for chopping");
                GameObject fruitSelectedAgain =  GetClickedGameObjectMobile();
                if(fruitSelectedAgain != null)
                {
                    //move fruit on chopper
                    PlateManagment.instance.MoveObjectOutOfPlate(fruitSelectedAgain);

                } 

            }
    }
    GameObject GetClickedGameObject() 
    { 
        // Builds a ray from camera point of view to the mouse position
         
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
            RaycastHit hit; 
            // Casts the ray and get the first game object hit 
            if (Physics.Raycast(ray, out hit, Mathf.Infinity)) 
            {
                //Debug.Log("Object found");
                //places clickMarker at hit.point. This isn't needed, just there for visualisation.
                if(hit.transform.gameObject.tag == "Fruit") 
                return hit.transform.gameObject;

                else
                return null;

            }
            else 
                return null; 
       
    }

    GameObject GetClickedGameObjectMobile() 
    { 
        // Builds a ray from camera point of view to the mouse position
         
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position); 
            RaycastHit hit; 
            // Casts the ray and get the first game object hit 
            if (Physics.Raycast(ray, out hit, Mathf.Infinity)) 
            {
                //Debug.Log("Object found");
                //places clickMarker at hit.point. This isn't needed, just there for visualisation.
                if(hit.transform.gameObject.tag == "Fruit") 
                return hit.transform.gameObject;

                else
                return null;

            }
            else 
                return null; 
       
    }
}
