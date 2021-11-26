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
        transform.position = Vector3.Lerp(transform.position, player.transform.position + offset, sensitivity);
    }
}
