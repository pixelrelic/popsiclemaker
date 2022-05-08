using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveKnife : MonoBehaviour
{
   public Transform _knife;


   public void MoveKnifeHorizontal(float x)
   {
        var pos = _knife.position;
        pos.x = x;
        _knife.position = pos;
   }
}
