using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerFinish : MonoBehaviour
{
    public GameObject particle;
    public GameObject particle2;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            RunnerPlayerController.instance.isFinish = true;
            StackControl.instance.totalR = StackControl.instance.coinCount * StackControl.instance.jumpCount;
            StackControl.instance.totalReward.text = StackControl.instance.totalR.ToString();
            particle.SetActive(true);
            particle2.SetActive(true);
            //RunnerPlayerController.instance.GameStartAndStop(false);
            StartCoroutine(FinishNum(other));
        }
    }

    IEnumerator FinishNum(Collider other)
    {
        yield return new WaitForSeconds(2);
        other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        LevelManager.instance.LevelCompleted();

    }
}
