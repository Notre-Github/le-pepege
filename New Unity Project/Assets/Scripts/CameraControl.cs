using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target;
    public Transform RotationDamogus;
    public Vector3 offset;

    public bool useOffsetValues;

    public float rotateSpeed;

    public Transform pivot;

    // Start is called before the first frame update
    void Start()
    {
        if(!useOffsetValues)
        {
            offset = target.position - transform.position;
        }
        pivot.transform.position = target.transform.position;
        pivot.transform.parent = target.transform;

        Cursor.lockState = CursorLockMode.Locked;
    }

    // LateUpdate is called once per frame after Update
    void LateUpdate()
    {

        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        //if(Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0)
        //{
            target.Rotate(0, horizontal, 0);
        //}

        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed; 
        pivot.Rotate(-vertical, 0, 0);

        float desiredXAngle = pivot.eulerAngles.x;

    //   if(Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
     //   {
            float desiredYAngle = RotationDamogus.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);
            transform.position = RotationDamogus.position - (rotation * offset);

            if(transform.position.y < RotationDamogus.position.y - 0.8f)
            {
                transform.position = new Vector3(transform.position.x, RotationDamogus.position.y - 0.8f, transform.position.z);
            }
            
            transform.LookAt(RotationDamogus);
    //    }
    //    else
      //  {
//            float desiredYAngle = target.eulerAngles.y;
            Quaternion rotation2 = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);
            transform.position = target.position - (rotation2 * offset);

            if(transform.position.y < target.position.y - 0.8f)
            {
                transform.position = new Vector3(transform.position.x, target.position.y - 0.8f, transform.position.z);
            }
            
            transform.LookAt(target);
   //     }

        

  //      if(Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
 //       {
            RotationDamogus.Rotate(0, horizontal, 0);
            //target.rotation = Quaternion.Euler(0,-horizontal,0);
 //       }
    }
}