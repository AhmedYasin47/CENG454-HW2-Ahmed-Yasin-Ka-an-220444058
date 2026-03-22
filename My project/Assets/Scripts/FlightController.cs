// FlightController.cs 
// CENG 454 – HW1: Sky-High Prototype 
// Author: AHMED YASİN KAÇAN | Student ID: 220444058

using UnityEngine; 
public class FlightController : MonoBehaviour 
{ 
 [SerializeField] private float pitchSpeed = 45f;
 [SerializeField] private float yawSpeed = 45f;
 [SerializeField] private float rollSpeed = 45f;
 [SerializeField] private float thrustSpeed = 20f;


 private Rigidbody rb;

 
    void Start() 
    { 
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    } 

    void Update()
    { 
    HandleRotation(); 
    HandleThrust(); 
    } 
    private void HandleRotation() 
    { 
        float pitch = 0f, yaw = 0f, roll = 0f;

        if (Input.GetKey(KeyCode.W)) pitch = pitchSpeed;
        else if (Input.GetKey(KeyCode.S)) pitch = -pitchSpeed;

        if (Input.GetKey(KeyCode.A)) yaw = -yawSpeed;
        else if (Input.GetKey(KeyCode.D)) yaw = yawSpeed;
        
        if (Input.GetKey(KeyCode.Q)) roll = rollSpeed;
        else if (Input.GetKey(KeyCode.E)) roll = -rollSpeed;
        
        transform.Rotate(pitch * Time.deltaTime, yaw * Time.deltaTime, roll * Time.deltaTime);
    }
    private void HandleThrust() 
    { 
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.forward * thrustSpeed * Time.deltaTime, ForceMode.VelocityChange);
        }
    } 
}

