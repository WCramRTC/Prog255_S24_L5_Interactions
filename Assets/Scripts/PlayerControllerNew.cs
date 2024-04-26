using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControllerNew : MonoBehaviour
{

    // Data Annotation
    // [Command]
    // [SerializedField]
    [SerializeField]
    float speed = 2;

    [SerializeField]
    float magnitudeOfImpact = 5;

    [SerializeField]
    float impactOnOther = 50;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        // When the object first starts
        // Look though all of the Compnents that are attached to 
        // The current game object
        // And assign the reference to our rb variable
        rb = GetComponent<Rigidbody>();
    }

    // Collisions and physics
    // Collisions happen in Unity
    // When two colliders interact with one another
    // There different shapes and sizes of colliders
    // Choose the "most efficent one" for your geometry 

    // Event: OnCollisionEnter()
    private void OnCollisionEnter(Collision other) {
        GameObject go = other.gameObject;

        // How do I make my character blast of into space
        // Two ways to impart movement
        // Vector and Physics
        // Get the RigidBody of the object you want to impart force on

        // Add Force calls a method that will impart a 
        // A magnitude of force in a particular direction based on
        // Vector 3 space,
        // Also take a force mode that will tell the game how to
        // distrube that for
        // new Vector3(0,1,0);

        // Condition, that checks what object we collided with
        // And if that is the same object, respond with code
        // if(go.name == "Building") {
        //     Debug.Log("This collision has triggered");
        //     Rigidbody collisionObjectRigidBody = go.GetComponent<Rigidbody>();

        //     Vector3 impactOnCollision = new Vector3(0,1,1) * impactOnOther ;
        //     collisionObjectRigidBody.AddForce(impactOnCollision);

        //     rb.AddForce(Vector3.up * magnitudeOfImpact, ForceMode.Impulse);
        // }

        Rigidbody collisionObjectRigidBody = go.GetComponent<Rigidbody>();

            Vector3 impactOnCollision = new Vector3(0,1,1) * impactOnOther ;
            collisionObjectRigidBody.AddForce(impactOnCollision);

            rb.AddForce(Vector3.up * magnitudeOfImpact, ForceMode.Impulse);

        Debug.Log($"You have collided with the {go.name}");
    }


    // Update is called once per frame
    void Update()
    {
        //   // Movement
        // float x = Input.GetAxis("Horizontal");
        // float z = Input.GetAxis("Vertical");
        // Vector3 movement = new Vector3(x,0,z) * speed * Time.deltaTime;
        // transform.Translate(movement);

        // Object : Input ( Input Manager )
        // Method : GetAxis (string), realted to controls in the input manager
        // Returns : If a direction is pressed, as a -1 to 1 value
        // 0 if it neutral
        // 1 or -1 depending on direction pressed
        // Vertical is up and down, or w and s
        // Horizontal is a and d, or left and right

        float x = Input.GetAxis("Vertical");
        float z = Input.GetAxis("Horizontal");

        // Time.deltaTime is a fraction that is the time between the last frame
        // and the current frame
        // This normalizes move speed across different applications
        // It's always behind a frame
    
        Vector3 movement = new Vector3(x,0,-z) * speed * Time.deltaTime;
             // Object: transform
        // Method: .Translate
        // Argument: Vector3 with how far we want to move

        transform.Translate(movement);

    }
}
