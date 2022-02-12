using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleControl : MonoBehaviour
{
    public GameObject particle;
    public GameObject particle2;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Player")
        {
            particle.transform.SetParent(null);
            particle.SetActive(true);
            this.gameObject.SetActive(false);

            particle2.transform.SetParent(null);
            particle2.SetActive(true);
        }
    }

}
