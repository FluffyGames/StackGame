using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraShake : MonoBehaviour
{
    public static CameraShake instance;
    Vector3 v;
    private void Awake() { if (!instance) { instance = this; } }

    void Start()
    {
        
    }

    void Update()
    {
    }

    public void DoShakeControl()
    {
        v = new Vector3(0.5f, 0, 0.5f);
        transform.DOShakePosition(1, v, 5, 0, true);


    }
}
