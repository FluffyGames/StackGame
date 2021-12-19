using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Player")
        {
            this.gameObject.SetActive(false);
            Stack.instance.StartCoroutine(Stack.instance.stack(25));
        }
    }
}
