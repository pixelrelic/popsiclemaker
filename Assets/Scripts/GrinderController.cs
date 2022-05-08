using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrinderController : MonoBehaviour
{

    public static GrinderController instance;
    public Text grinderBtnText;
    public bool ISGRINDERON;
    // Start is called before the first frame update
    public Animator grinderanimator;
    public Animator fillingAnimator;
    bool isFillingStarted = false;
    public GameObject filling;

    float blendigTimePassed = 0f;


    public GameObject onbtn,offbtn;


    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        ISGRINDERON = false;
        blendigTimePassed = 0f;
        fillingAnimator.speed = 0;
        isFillingStarted = false;
        grinderBtnText.text = "Start";
    }

    public void ResetGrindingSection()
    {
        ISGRINDERON = false;
        blendigTimePassed = 0f;
        fillingAnimator.speed = 0;
        isFillingStarted = false;
        UIManager.uiManager.FillBlendingBar(blendigTimePassed);
        grinderanimator.SetBool("ON",false);
        fillingAnimator.SetBool("Filling",false);
        grinderBtnText.text = "Start";
    }

    // Update is called once per frame
    void Update()
    {       
            // if(LevelManager.levelManager.currentSection == 3)
            // {
            //     if (Input.GetButtonDown("Jump"))
            //     {   
            //         OnOffGrinder();
            //     }

                if(ISGRINDERON)
                {
                    blendigTimePassed += Time.deltaTime;           
                    UIManager.uiManager.FillBlendingBar(blendigTimePassed);
                    //check for level completion value here
                    //again 5 is hardcoded here need to change it later
                    if(blendigTimePassed >= 5f)
                    {
                        //section completed
                        //stop blender
                        OnOffGrinder();
                        //stop filling animation
                        fillingAnimator.speed = 0;
                        //load next section
                        LevelManager.levelManager.LoadGlassPouringSection();
                    }
                }
                
            // }
            
    }

    public void GrinderONOFFBtn()
    {
        if(LevelManager.levelManager.currentSection == 3)
            {
                OnOffGrinder(); 
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
                if(hit.transform.gameObject.tag == "MixerBtn") 
                return hit.transform.gameObject;

                else
                return null;

            }
            else 
                return null; 
       
    }

    void OnOffGrinder()
    {
        if(ISGRINDERON)
        {
            ISGRINDERON = !ISGRINDERON;
            grinderBtnText.text = "Start";
            //do not shake
            //set grinder animtion to idle
            grinderanimator.SetBool("ON",false);
            fillingAnimator.speed = 0;
            //and also hide off button and show on button
            offbtn.SetActive(true);
            onbtn.SetActive(false);
        }
        else
        {
            ISGRINDERON = !ISGRINDERON;
            grinderBtnText.text = "Stop";   
            //shake
            //set grinder animation to shake
            grinderanimator.SetBool("ON",true);
            if(isFillingStarted)
            {
                fillingAnimator.speed = 1;
            }
            else
            {
                fillingAnimator.SetBool("Filling",true);
                fillingAnimator.speed = 1;
                isFillingStarted = true;
                //Assign material
                filling.GetComponent<Renderer>().material = LevelManager.levelManager.currentPospsicle.liquidMaterial; 
            }
            
            //and also hide on button and show off button
            offbtn.SetActive(false);
            onbtn.SetActive(true);
        }
    }
}
