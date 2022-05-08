using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Popsicle", menuName = "ScriptableObjects/PoplsicleScriptableObject", order = 1)]
public class Popsicles : ScriptableObject
{
    public int popsicleID;
    public int fruitID;
    public string fruitName; 
    public int requiredFruits;
    public int choppingTime;
    public float freezTime;

    public Material liquidMaterial;
    

}