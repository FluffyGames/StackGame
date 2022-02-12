using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour
{
    public GameObject particle;
    public GameObject trailP;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Player")
        {
            particle.transform.SetParent(null);
            particle.SetActive(true);
            this.gameObject.SetActive(false);
            StackControl.instance.StartCoroutine(StackControl.instance.StackOpr(1));
        }
    }

    public void trail()
    {
        trailP.SetActive(true);
    }

}
