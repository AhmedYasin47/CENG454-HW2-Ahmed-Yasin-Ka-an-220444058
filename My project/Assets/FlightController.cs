// FlightController.cs 
// CENG 454 – HW1: Sky-High Prototype 
// Author: AHMED YASİN KAÇAN | Student ID: 220444058

using UnityEngine; 
public class FlightController : MonoBehaviour 
{ 
 [SerializeField] private float pitchSpeed = 45f;
 [SerializeField] private float yawSpeed = 45f;
 [SerializeField] private float rollSpeed = 45f;
 [SerializeField] private float thrustSpeed = 5f;


 private Rigidbody rb;
 
    void Start() 
    { 
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    } 

    void Update()// or FixedUpdate() 
    { 
    HandleRotation(); 
    HandleThrust(); 
    } 
    private void HandleRotation() 
    { 

    } 
    private void HandleThrust() 
    { 

    } 
}

