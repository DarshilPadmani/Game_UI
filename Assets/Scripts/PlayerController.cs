using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float sensitivity = 5f;
    public float JumpForce = 10f;
    Rigidbody rb;
    public Camera cam;

    private void Start()
    {
        rb= GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        PlayerMovement();
        PlayerRotation();
    }
    void PlayerMovement()
    {
        float movX = Input.GetAxisRaw("Horizontal");
        float movZ = Input.GetAxisRaw("Vertical");
        Vector3 movePlayer = new Vector3(movX, 0f, movZ);
        transform.Translate( movePlayer * Time.deltaTime * speed,Space.Self);
        //rb.MovePosition(transform.position + movePlayer * Time.deltaTime * speed);
        if (Input.GetKey(KeyCode.Space))
        {
            //Jump
            rb.AddForce(Vector3.up*JumpForce);
        }
    }
    void PlayerRotation()
    {
        float rotateY = Input.GetAxisRaw("Mouse X");
        Vector3 rotation = new Vector3(0f, rotateY, 0f)*sensitivity;

        transform.Rotate(rotation);

        float rotateX = Input.GetAxisRaw("Mouse Y");
        Vector3 CameraRotation=new Vector3(rotateX, 0f, 0f)*sensitivity;
        cam.transform.Rotate(- CameraRotation);
        //rb.MoveRotation(rb.rotation*Quaternion.Euler(rotation));
    }
}
