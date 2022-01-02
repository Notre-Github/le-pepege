using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float playerMoveSpeed;
    public float jumpForce;
    public CharacterController control;

    private Vector3 moveDirection;

    public float gravityScale;

    public Transform Camsyo;

    public Transform RotationDirCam;
    public Transform RotationPlayer;

    // Start is called before the first frame update
    void Start()
    {
        control = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //moveDirection = new Vector3(Input.GetAxis("Horizontal") * playerMoveSpeed, moveDirection.y, Input.GetAxis("Vertical") * playerMoveSpeed);
        float yStore = moveDirection.y;

        //if(Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        //{
        //    RotationPlayer.rotation = Quaternion.Euler(RotationPlayer.eulerAngles.x, Camsyo.eulerAngles.y, RotationPlayer.eulerAngles.z);
        //    RotationDirCam.rotation = Quaternion.Euler(0,0,0);
        //}

        moveDirection = (transform.forward * (Input.GetAxis("Vertical") * playerMoveSpeed)) + (transform.right * (Input.GetAxis("Horizontal") * playerMoveSpeed));
        moveDirection = moveDirection.normalized * playerMoveSpeed;
        moveDirection.y = yStore;

        if(control.isGrounded)
        {
            moveDirection.y = 0f;

            if(Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
            }
        }

        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        control.Move(moveDirection * Time.deltaTime);
    }
}
