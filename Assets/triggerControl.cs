using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class triggerControl : MonoBehaviour
{
    public List<Vector3> cargoP = new List<Vector3>();
    public bool b=false;
    Vector3 pos;
    void Start()
    {
    }

    void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Player")
        {
            if (!b)
            {
                pos = this.transform.parent.GetChild(1).transform.position;
                cargoP.Add(pos);
                for (int i = 0; i < cargoP.Count; i++)
                {
                    if (StackControl.instance.childList.Count>4)
                    {
                        StackControl.instance.jump();

                        StackControl.instance.childList[StackControl.instance.childList.Count - 1].
                        transform.DOJump(cargoP[i], 5, 1, 1.5f, false);

                    }
                    else
                    {
                        Debug.Log("allah belaný versin duygularýmla oynadýn pezevenk");
                    }

                }
                
                b = true;
            }
        }
    }
}
