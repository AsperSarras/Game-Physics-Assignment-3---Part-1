using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Look Controls")]
    public float sensitivity = 25.0f;

    [Header("Movement")]
    public float maxSpeed = 10.0f;
    //public Vector3 velocity;

    private float xAxisRotation = 0.0f;
    private float yAxisRotation = 0.0f;

    private Vector2 mouse;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        MouseLook();
        Move();
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 moveForward = Vector3.MoveTowards(transform.position, transform.forward * maxSpeed, y * maxSpeed * Time.deltaTime);
        Vector3 moveSideways = Vector3.MoveTowards(transform.position, transform.right * maxSpeed, x * maxSpeed * Time.deltaTime);
        //transform.position = moveForward + moveSideways;
    }

    // Update is called once per frame
    void MouseLook()
    {
        mouse.x = Input.GetAxis("Mouse X") * sensitivity;
        mouse.y = Input.GetAxis("Mouse Y") * sensitivity;

        xAxisRotation -= mouse.y;
        xAxisRotation = Mathf.Clamp(xAxisRotation, -90.0f, 90.0f);
       
        yAxisRotation += mouse.x;
        yAxisRotation = Mathf.Clamp(yAxisRotation, -90.0f, 90.0f);
        transform.localRotation = Quaternion.Euler(xAxisRotation,yAxisRotation, 0.0f);





    }
}
