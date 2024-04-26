using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{
    public float speed = 3;
    public float jumpHeight = 5;
    public float mouseXSensitivity = 5;
    public Rigidbody rb;
    public GameObject camera;

    [Header("Camera Controls")]
    public Transform playerLocation;
    public float cameraOffsetX;
    public float cameraOffsetY;
    public float cameraOffsetZ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Mouse Rotation
        float mouseX = Input.GetAxis("Mouse X");
        Debug.Log(mouseX);

        Vector3 mouseRotate = new Vector3(0, mouseX * mouseXSensitivity, 0 );
        transform.Rotate(mouseRotate);

        // Movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(x,0,z) * speed * Time.deltaTime;
        transform.Translate(movement);

        // Jump
        if(Input.GetButtonDown("Jump")) {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }

        // // Camera
        // if(camera != null) {
        //     camera.transform.position = playerLocation.position + new Vector3(cameraOffsetX, cameraOffsetY, cameraOffsetZ);
        // }
  
        

    }
}
