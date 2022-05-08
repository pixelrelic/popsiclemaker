using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//script will be attached to each fruit
//and it will store current fruit id 
//so when clicked it will know which fruit is selected by user

public class Fruit : MonoBehaviour
{   
    public int fruitID;
    public string fruitName;

    public GameObject ChoppingBoard;

    public GameObject fruitSlice;
    public int numberOfSlices;

    //public List<GameObject> slices;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Knife")
        Debug.Log("Knife hit fruit");

        //instantiate and spawn gameobjects at cut position accoring to their number
        for(int i = 0 ; i < numberOfSlices; i++)
        {
           GameObject temp =  Instantiate(fruitSlice, transform.position, transform.rotation);
           PlateManagment.instance.cutPieces.Add(temp);
           //temp.transform.SetParent(ChoppingBoard.transform);
        }

        Destroy(gameObject);
        
    }
}
