using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;

public class RunnerPlayerController : MonoBehaviour
{
    public static RunnerPlayerController instance;
    Rigidbody rb;
    Animator animator;
    public UltimateJoystick joystick;
    public float rightLimit, leftLimit, verticalSpeed, horizontalSpeed;
    public bool isStart,isFinish;

    private void Awake() { if (!instance) { instance = this; } }
    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        animator = this.GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        if(isStart)
        {
           rb.velocity = transform.forward * verticalSpeed;
           LeftAndRightMove();
        }
    }

    public void AnimatorSetBool(string id, bool value)
    {
        animator.SetBool(id, value);
    }

    public void GameStartAndStop(bool value)
    {
        isStart = value;
        AnimatorSetBool("run", value);
        joystick.gameObject.SetActive(value);
        if(!value & isFinish)
        {
            AnimatorSetBool("dance", true);
            rb.velocity = Vector3.zero;
        }
    }

    // !!! Oyunu yayinlarken update fonksiyonunu sil. UIManager icinden PlayArea fonksiyonuna GameStartAndStop(true) komutunu ekle.
    private void Update()
    {
        if (GameManager.instance._gameState == GameManager.GameState.Started && !isFinish)
            GameStartAndStop(true);
    }
    // !!! Oyunu yayinlarken update fonksiyonunu sil. UIManager icinden PlayArea fonksiyonuna GameStartAndStop(true) komutunu ekle.


    private void LeftAndRightMove()
    {
        if (joystick.HorizontalAxis > 0 && this.transform.localPosition.z !< rightLimit)
        {
            this.transform.Translate(Vector3.right * joystick.HorizontalAxis * horizontalSpeed * Time.deltaTime);
        }
        if (joystick.HorizontalAxis < 0 && this.transform.localPosition.z !> leftLimit)
        {
            this.transform.Translate(Vector3.right * joystick.HorizontalAxis * horizontalSpeed * Time.deltaTime);
        }
    }
}
