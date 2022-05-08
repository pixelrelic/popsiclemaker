using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateManagment : MonoBehaviour
{
    
    public static PlateManagment instance;

    public Transform[] slots,outSlots;
    public Transform plateposStart,plateposEnd;

    public List<GameObject> cutPieces;
    public GameObject BlenderSpawnPoint;
    public GameObject mixer;
    
    public int currentObjectCount = 0;
    int maxObjectCount = 4;
    bool ISPLATEFULL = false;
    public bool ISPLATEMPTY = true;


    float elapsedTime = 0f;
    public float requiredTime = 3f;
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        maxObjectCount = 4;
        ISPLATEFULL = false;
        elapsedTime = 0f;
        currentObjectCount = 0;
    }

    public void ResetPlateManager()
    {
        maxObjectCount = 4;
        ISPLATEFULL = false;
        elapsedTime = 0f;
        currentObjectCount = 0;
        cutPieces.Clear();
    }

    //make both of these movements smooth later on
    public void MovePlateToEndPos()
    {   
        Transform[] paramsAtoB = new Transform[2]{plateposStart,plateposEnd};
        //transform.position = plateposEnd.position;
        elapsedTime = 0f;
        //StartCoroutine("MoveFromAtoB",paramsAtoB);
        while(elapsedTime <= requiredTime )
        {   
            //Debug.Log("Elapsed time : "+elapsedTime+" Required time :"+ requiredTime);
            elapsedTime += Time.deltaTime;
            float percentTime = elapsedTime / requiredTime;
            //Debug.Log("Time : "+ elapsedTime);
            transform.position = Vector3.Lerp(plateposStart.position,plateposEnd.position,percentTime);
        }
    }

    IEnumerator MoveFromAtoB(Transform[] Params)
    {    
        //Debug.Log("Moving object"); 
        while(elapsedTime <= requiredTime )
        {   
            
            //Debug.Log("Elapsed time : "+elapsedTime+" Required time :"+ requiredTime);
           
            yield return null;
            elapsedTime += Time.deltaTime / requiredTime;
            //float percentTime = elapsedTime / requiredTime;
            //Debug.Log("Time : "+ elapsedTime);
            transform.position = Vector3.Lerp(Params[0].position,Params[1].position,elapsedTime);
        }     
        //return null;
    }

    public void MovePlateToStartPos()
    {
        //transform.position = plateposStart.position;
        Transform[] paramsAtoB = new Transform[2]{plateposEnd,plateposStart};
        //transform.position = plateposEnd.position;
        elapsedTime = 0f;
        //StartCoroutine("MoveFromAtoB",paramsAtoB);
        while(elapsedTime <= requiredTime )
        {   
            //Debug.Log("Elapsed time : "+elapsedTime+" Required time :"+ requiredTime);
            elapsedTime += Time.deltaTime;
            float percentTime = elapsedTime / requiredTime;
            //Debug.Log("Time : "+ elapsedTime);
            transform.position = Vector3.Lerp(plateposEnd.position,plateposStart.position,percentTime);
        }
    }

    public void MoveObjectToPlate(GameObject gameObject)
    {
        if(!ISPLATEFULL)
        {
            gameObject.transform.position =  slots[currentObjectCount].position;
            gameObject.transform.SetParent(slots[currentObjectCount]);
            //gameObject.GetComponent<Fruit>().enabled = false;
            currentObjectCount += 1;
            UIManager.uiManager.FillFruitSelectionBar(currentObjectCount);
            ISPLATEMPTY = false;
        }
       if(currentObjectCount >= maxObjectCount)
       {
           ISPLATEFULL = true;
       }

    }

     public void MoveObjectOutOfPlate(GameObject gameObject)
    {
        if(!ISPLATEMPTY)
        {
            currentObjectCount -= 1;
            gameObject.transform.position =  outSlots[currentObjectCount].position;
            gameObject.transform.SetParent(outSlots[currentObjectCount]);
            ISPLATEFULL = false;
        }
       if(currentObjectCount <= 0)
       {
           ISPLATEMPTY = true;
           UIManager.uiManager.chopBtn.SetActive(true);
       }

    }


    //gets position of fruit from right to left, 1 is first fruit and so on
    public Vector3 GetFruitPosition(int i)
    {   
        // Debug.Log("In get fruit position method i is : " + i + " and fruit position indx is : " + (LevelManager.levelManager.currentPospsicle.requiredFruits - i));
        int fruitPos = LevelManager.levelManager.currentPospsicle.requiredFruits - i;
        if(fruitPos <= -1)
        {
            //section complete
            LevelManager.levelManager.LoadBlendingSection();
            return Vector3.up;
        }
        return outSlots[fruitPos].transform.position;
    }


    public void MoveCutPiecesToBlender()
    {
        foreach(GameObject piece in cutPieces)
        {
            piece.transform.position = BlenderSpawnPoint.transform.position;
            piece.transform.SetParent(mixer.transform);
        }
    }


    public void RemoveCutPiecesFromBlender()
    {
        foreach(GameObject piece in cutPieces)
        {   
            //cutPieces.Remove(piece);
            Destroy(piece);
        }
    }
}
