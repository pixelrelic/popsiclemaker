using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BzKovSoft.ObjectSlicer;

public class Slicer : MonoBehaviour
{

    public GameObject _target;

    // Start is called before the first frame update
    void Start()
    {
       var slicable =  _target.GetComponent<IBzSliceableAsync>();

       if(slicable != null)
       {
           slicable.Slice(new Plane(Vector3.up,0),0,null);
       } 
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
