using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeController : MonoBehaviour
{   
    public static KnifeController instance;
    public int SliceID { get; private set; }

    public GameObject _knife;
    public float displacement;
    public float knifeSpeed = 1f;

    [SerializeField]
    private Vector3 _direction = Vector3.up;
    Vector3 _prevPos;
	Vector3 _pos;

    public int choppingCount = 1;
    void Start()
    {   
        instance = this;
        _knife = this.gameObject;
        choppingCount = 1;
    }


    public void ResetChoppingSection()
    {
        choppingCount = 1;
    }

    void Update()
    {   

        //just for this demo :
        //position knife over fruit on plate
        //from where we can get positions 
        //plate management will return fruit position
        //from which we need to take only x and z position not y
        //we neet to keep count
        if(LevelManager.levelManager.currentSection == 2)
        {
            Vector3 knifePositionToBe = PlateManagment.instance.GetFruitPosition(choppingCount);
            transform.position = new Vector3(knifePositionToBe.x,transform.position.y,knifePositionToBe.z);

            // if(Input.GetButtonDown("Jump"))
            // {
            //     //move knife only in y direction
            //     //StartCoroutine("Chop");
            // }

            //Debug.Log("chopping count : "+choppingCount +" Chopping time : "+LevelManager.levelManager.currentPospsicle.choppingTime);
            _prevPos = _pos;
            _pos = transform.position;
            
            //what is max chopping count
            if(choppingCount >= LevelManager.levelManager.currentPospsicle.choppingTime+1)
            {
                //section comlpete, move to next section
                Debug.Log("chopping section complete chopping count : "+choppingCount +" CHopping Time : "+LevelManager.levelManager.currentPospsicle.choppingTime);
                LevelManager.levelManager.LoadBlendingSection();
            }
            
        }
           
    }

    public void ButtonChop()
    {   
        //check if all fruits on plate
        if(PlateManagment.instance.ISPLATEMPTY)
        {
            StartCoroutine("Chop");    
        }
        
    }

    IEnumerator Chop()
    {   
        
        _knife.transform.position = new Vector3(transform.position.x,transform.position.y+displacement,transform.position.z);
        UIManager.uiManager.FillFruitCuttingBar(choppingCount);
        yield return new WaitForSeconds(knifeSpeed);
        _knife.transform.position = new Vector3(transform.position.x,transform.position.y-displacement,transform.position.z);
        choppingCount += 1;
        
        
    }
    public Vector3 BladeDirection { get { return transform.rotation * _direction.normalized; } }
	public Vector3 MoveDirection { get { return (_pos - _prevPos).normalized; } }
    
    public void BeginNewSlice()
		{
			SliceID = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
		}
}
