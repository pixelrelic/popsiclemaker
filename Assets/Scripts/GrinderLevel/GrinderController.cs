using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrinderController : MonoBehaviour
{

    public GameObject _grinder;
    public bool ISGRINDERON;
    // Start is called before the first frame update
    public Animator grinderanimator;
    void Start()
    {
        ISGRINDERON = false;
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetButtonDown("Jump"))
            {   
                OnOffGrinder();
            }
    }

    void OnOffGrinder()
    {
        if(ISGRINDERON)
        {
            ISGRINDERON = !ISGRINDERON;
            //do not shake
            //set grinder animtion to idle
            grinderanimator.SetBool("ON",false);
        }
        else
        {
            ISGRINDERON = !ISGRINDERON;   
            //shake
            //set grinder animation to shake
            grinderanimator.SetBool("ON",true);
        }
    }
}
