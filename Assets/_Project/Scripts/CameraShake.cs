using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraShake : MonoBehaviour
{
    public static CameraShake instance;
    Vector3 v;
    private void Awake() { if (!instance) { instance = this; } }
    public void DoShakeControl()
    {
        v = new Vector3(1, 0, 1);
        transform.DOShakePosition(1, v, 15, 0, true);
    }
}
