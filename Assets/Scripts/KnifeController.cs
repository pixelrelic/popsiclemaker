using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeController : MonoBehaviour
{
    public GameObject _knife;
    public Vector3 startpos,endpos;
    public float knifeSpeed = 1f;


    void Start()
    {
        _knife = this.gameObject;
    }
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            //move knife only in y direction
            StartCoroutine("Chop");
        }   
    }

    IEnumerator Chop()
    {   
        Debug.Log("endpos : " + endpos.y);
        _knife.transform.position = new Vector3(transform.position.x,endpos.y,transform.position.z);

        yield return new WaitForSeconds(knifeSpeed);
        _knife.transform.position = new Vector3(transform.position.x,startpos.y,transform.position.z);
    }
}
