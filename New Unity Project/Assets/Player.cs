using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public Camera cam;

    public float rotateSpeed = 5f;
    public float movespd;

    public float cameraRotationLimit = 80f;

    public Rigidbody rb;

    private Vector3 rotation = Vector3.zero;
    private float cameraRotation = 0f;
    private float currentCameraRotation = 0f;

    public bool move = true;


    private void Start()
    {
        
    }

    void Update()
    {
        if (move)
        {
            CamRotate();
        }
            
        RayCast();

    }

    private void CamRotate()
    {
        float yRot = Input.GetAxisRaw("Mouse X");
        float xRot = Input.GetAxisRaw("Mouse Y");

        rotation = new Vector3(0f, yRot, 0f) * rotateSpeed; //x
        cameraRotation = xRot * rotateSpeed; //y (카메라만 위로 돌아감)
    }

    private void RayCast()
    {
        Ray ray = new Ray();
        ray.origin = cam.transform.position;
        ray.direction = cam.transform.forward;
        Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red, 0.1f);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.name == "handle_obj")
            {
                

            }
            //Debug.Log(hit.transform.name);
        }
    }




    void FixedUpdate() //Movement Rotation
    {
        if (move)
        {
            PreformRotation();
            playerMove();

        }
    }

    void playerMove()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0, 0, movespd * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, 0, movespd * Time.deltaTime * -1));
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(movespd * Time.deltaTime * -1, 0, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(movespd * Time.deltaTime, 0, 0));
        }
    }

    void PreformRotation() //X, Y회전
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        if (cam != null)
        {
            currentCameraRotation -= cameraRotation;
            currentCameraRotation = Mathf.Clamp(currentCameraRotation, -cameraRotationLimit, cameraRotationLimit);
            cam.transform.localEulerAngles = new Vector3(currentCameraRotation, 0f, 0f);
        }
    }
}
