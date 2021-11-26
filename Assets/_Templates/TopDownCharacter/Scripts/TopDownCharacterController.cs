using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacterController : MonoBehaviour
{
    //component
    private CharacterController _characterController;
    private Transform meshPlayer;// _characterController in ilk child i karakterimiz onu atiyoruz
    public UltimateJoystick ultimateJoystick;
    Animator animator;
    //move
    private float inputX, inputZ;
    public float moveSpeed;
    private Vector3 v_movement;
    private float gravity = 0.5f; //yapay yer cekimi
    public float rotSpeed;

    private void Start()
    {
        _characterController = this.GetComponent<CharacterController>();
        meshPlayer = this.transform.GetChild(0);
        animator = meshPlayer.GetComponent<Animator>();
    }

    private void Update()
    {
        inputX = ultimateJoystick.GetHorizontalAxis(); inputZ = ultimateJoystick.GetVerticalAxis();
        if (inputX == 0 && inputZ == 0)
            animator.SetBool("run", false);
        else
            animator.SetBool("run", true);
    }
    private void FixedUpdate()
    {
        //gravity
        if (_characterController.isGrounded)
            v_movement.y = 0;
        else
            v_movement.y -= gravity * Time.deltaTime;

        //movement
        v_movement = new Vector3(inputX * moveSpeed, v_movement.y, inputZ * moveSpeed);
        _characterController.Move(v_movement);

        //mesh rotate
        if ((inputX != 0 || inputZ != 0))
        {
            Vector3 lookDir = new Vector3(v_movement.x * rotSpeed, 0, v_movement.z * rotSpeed);
            Quaternion rotation = Quaternion.LookRotation(lookDir);
            meshPlayer.rotation = Quaternion.Slerp(meshPlayer.rotation, rotation, Time.deltaTime * rotSpeed);
        }

    }
}
