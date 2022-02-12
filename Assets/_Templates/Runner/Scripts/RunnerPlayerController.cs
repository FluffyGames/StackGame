using DG.Tweening;
//using MoreMountains.NiceVibrations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RunnerPlayerController : MonoBehaviour
{
    public static RunnerPlayerController instance;
    //public bool isStart,isFinish;
    /*public*/ ParticleSystem crashEffect; // ben kapattým 

    //-----
    public Rigidbody rb;
    public Animator animator;

    public Camera fixedCamera;

    public float movementSpeed = 5f;
    public float slidingSpeed = 8f;

    public bool movementStopper = false, isStart, isFinish;

    //-----
    private void Awake() { if (!instance) { instance = this; } }
    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        //crashEffect.Stop();  ben kapattým 
    }

    private void FixedUpdate()
    {
        if ((GameManager.instance._gameState == GameManager.GameState.Started) && !movementStopper)
            rb.velocity = new Vector3(-movementSpeed, 0, 0);
    }

    Vector3 firstTouchPos;
    Vector3 firstPlayerPos;

    private void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == null && !movementStopper && (GameManager.instance._gameState != GameManager.GameState.GameOver && GameManager.instance._gameState != GameManager.GameState.Win))
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (GameManager.instance._gameState == GameManager.GameState.NotStarted)
                    UIManager.instance.PlayArea();

                firstTouchPos = fixedCamera.ScreenToWorldPoint(Input.mousePosition - new Vector3(0, 0, 1));
                firstPlayerPos = transform.localPosition;

               // MMVibrationManager.Haptic(HapticTypes.Selection);
            }
            else if (Input.GetMouseButton(0))
            {
                Vector3 movementVector = fixedCamera.ScreenToWorldPoint(Input.mousePosition - new Vector3(0, 0, 1)) - firstTouchPos;

                float finalXPos = firstPlayerPos.z - movementVector.z * slidingSpeed;
                finalXPos = Mathf.Clamp(20.2f, 13.8f, finalXPos);

                if (finalXPos < 13.8f)
                    finalXPos = 13.8f;
                transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(transform.localPosition.x, transform.localPosition.y, finalXPos), Time.fixedDeltaTime * 10f);
            }
            else if (Input.GetMouseButtonUp(0))
            {
               // MMVibrationManager.Haptic(HapticTypes.LightImpact);
            }

        }
    }
}