using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack : MonoBehaviour
{
    public static Stack instance;

    public List<Transform> childList = new List<Transform>();
    public int loopCount = 0;
    public int count = 0;
    public GameObject cube;
    public float distance;
    private void Awake()
    {
        if (!instance)
            instance = this;
    }
    void Start()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            childList.Add(this.transform.GetChild(i));
            this.transform.GetChild(i).GetComponent<MeshRenderer>().enabled = false;
        }
    }

    public IEnumerator stack(int value)
    {
        for (int i = 0; i < value; i++)
        {
            Vector3 pos = childList[count].position;
            pos.y += (loopCount * distance);
            Instantiate(cube, pos, Quaternion.identity,this.transform);
            count++;
            if (count >= childList.Count)
            {
                count = 0;
                loopCount++;
            }
            yield return new WaitForSeconds(0.25f);
        }
    }

   
}
