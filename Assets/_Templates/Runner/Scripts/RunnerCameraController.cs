using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerCameraController : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;
    public float sensitivity = 0.05f;

    private void Start()
    {
        offset = transform.position - player.transform.position;
    }

    private void FixedUpdate()
    {
        Vector3 plyr = player.transform.position; plyr.z = 0; offset.z = 0;
        Vector3 pos = plyr + offset;
        pos.z = 16.92f;
        transform.position = Vector3.Lerp(transform.position, pos, sensitivity);
        //Debug.Log(pos);
    }
}
