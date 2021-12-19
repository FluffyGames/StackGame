using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerFinish : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            LevelManager.instance.LevelCompleted();
            RunnerPlayerController.instance.isFinish = true;
            //unnerPlayerController.instance.GameStartAndStop(false);
        }
    }
}
