using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ragdollStick : MonoBehaviour
{
    public bool b;
    public GameObject hips;
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {

            if (b)
            {
                this.transform.parent.GetComponent<Animator>().enabled = false;
                this.transform.parent.parent.GetComponent<Animator>().enabled = false;
                this.transform.GetComponent<Animator>().enabled = false;
                hips.GetComponent<Rigidbody>().AddForce(Vector3.left * 20900);
                //this.transform.GetChild(0).GetComponent<Rigidbody>().AddForce(Vector3.left * 1000,ForceMode.Force);

                StackControl.instance.packageDrop();
                b = false;
            }
            StartCoroutine(col(other));


        }

        IEnumerator col(Collider col)
        {
            col.gameObject.GetComponent<Collider>().enabled = false;
            yield return new WaitForSeconds(2);
            col.gameObject.GetComponent<Collider>().enabled = true;

        }
    }

}
