using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class dojumpdeneme : MonoBehaviour
{
    public GameObject finishpos;
    Vector3 pos;
    void Start()
    {
        pos = finishpos.transform.position;
        transform.DOJump(pos,6,1,1.5f,false);
    }

    void Update()
    {
        
    }

    
}
