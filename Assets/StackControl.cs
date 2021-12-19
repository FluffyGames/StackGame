using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackControl : MonoBehaviour
{
    public static StackControl instance;
    public List<Transform> childList = new List<Transform>();
    public Quaternion rot;
    public GameObject stackObject;
    private void Awake()
    {
        if (!instance)
            instance = this;
    }
    private void Start()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            childList.Add(this.transform.GetChild(i));
            this.transform.GetChild(i).GetComponent<MeshRenderer>().enabled = false;
        }

    }

    public int count, loopCount; public float distance;
    public IEnumerator StackOpr(int value)
    {
        for (int i = 0; i < value; i++)
        {

            Vector3 position = childList[count].position;
            position.y += (loopCount * distance);
            Instantiate(stackObject, position, Quaternion.identity, this.transform);

            count++;
            if (count >= childList.Count)
            {
                count = 0; loopCount++;
            }
            yield return new WaitForSeconds(0.25f);
        }
    }

}
