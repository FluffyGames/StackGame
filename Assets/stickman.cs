using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stickman : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            this.transform.GetChild(0).GetChild(0).GetComponent<Animator>().enabled = true;
            this.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Animator>().enabled = true;
            this.transform.GetChild(0).GetComponent<Animator>().enabled = false;
            this.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<ragdollStick>().b = true;
        }
    }
}
