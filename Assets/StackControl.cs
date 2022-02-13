using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro; 
public class StackControl : MonoBehaviour
{
    public static StackControl instance;
    public List<Transform> childList = new List<Transform>();
    public GameObject stackObject;
    public Transform packageSample;
    public GameObject cargoPoint;
    int abc;
    GameObject packageParticle;
    public bool exit;
    public TextMeshProUGUI coinText;
    bool lerp=false;
    Rigidbody rb;
    int coinCount;
    public GameObject obstacleParticle;
    private void Awake()
    {
        if (!instance)
            instance = this;
    }
    private void Update()
    {
        Debug.Log(childList[childList.Count - 1]);
        if (lerp)
        {
            transform.position = Vector3.Lerp(transform.position,transform.position + new Vector3(2, 0, 0), Time.deltaTime );
        }
    }
    private void Start()
    {
        
        rb = this.GetComponent<Rigidbody>();
        for (int i = 0; i < this.transform.childCount; i++)
        {
            childList.Add(this.transform.GetChild(i));
            this.transform.GetChild(i).GetComponent<MeshRenderer>().enabled = false;
        }

    }

    public int count, loopCount; public float distance; GameObject a;
    public IEnumerator StackOpr(int value)
    {
        for (int i = 0; i < value; i++)
        {
            exit = true;
            Vector3 position = childList[count].position;
            position.y += (loopCount * distance);
            //Debug.Log("control" + (loopCount * distance));
            a = Instantiate(stackObject, position, packageSample.rotation, this.transform);
            childList.Add(a.transform);
            coinCount+=50;
            coinText.text = coinCount.ToString();
            a.transform.localScale = packageSample.transform.localScale;
            a.name = abc.ToString();
            abc++;


            count++;
            if (count >= 4)
            {
                count = 0; loopCount++;
            }
            //Debug.Log("stack : " + count);

            yield return new WaitForSeconds(0.25f);
        }
    }
    public void jump()
    {
        if(childList.Count>4)
        {
            childList[childList.Count - 1].parent = null;
            childList[childList.Count - 1].GetComponent<obstacle>().trail();
            //Debug.Log("jump : "+count);
            if (count == 0)
            {
                if (loopCount == 0)
                {
                    count = 1;
                }
                else
                {
                    loopCount--;
                    count = 3;
                }
            }
            else
            {
                count--;
            }
            childList.RemoveAt(childList.Count - 1);

            coinCount += 100;
            coinText.text = coinCount.ToString();
        }
        else
        {
            count = 0;
        }
        
    }

    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "obstacle")
        {
            CameraShake.instance.DoShakeControl();
            StartCoroutine(crash());
            packageDrop();

        }
    }
   

    public IEnumerator crash()
    {

        lerp = true;
        RunnerPlayerController.instance.enabled = false;
        RunnerPlayerController.instance.movementSpeed = 0;
        rb.velocity = Vector3.zero;
        
        //rb.AddForce(Vector3.right * 10000); 
        yield return new WaitForSeconds(1);

        lerp = false;
        RunnerPlayerController.instance.enabled = true;
        RunnerPlayerController.instance.movementSpeed = 10;

    }
    public void packageDrop()
    {
        Transform deletedObject = childList[childList.Count - 1];
        childList.RemoveAt(childList.Count - 1);
        deletedObject.parent = null;

        deletedObject.GetComponent<Rigidbody>().velocity = Vector3.right * 8;
        deletedObject.GetComponent<Rigidbody>().useGravity = true;
        deletedObject.GetComponent<Collider>().isTrigger = false;
        deletedObject.GetComponent<Rigidbody>().isKinematic = false;


    }


}

