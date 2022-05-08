using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFlavour : MonoBehaviour
{
    public GameObject flavour;


    public void ChangeFlavourOfPopscile(Material mat)
    {
        flavour.GetComponent<Renderer>().material = mat;
    }
}
