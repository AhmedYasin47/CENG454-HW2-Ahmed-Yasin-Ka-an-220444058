// FlightController.cs 
// CENG 454 – HW1/HW2: Sky-High Prototype 
// Author: AHMED YASİN KAÇAN | Student ID: 220444058

using UnityEngine; 

public class FlightController : MonoBehaviour 
{ 
    [SerializeField] private float pitchSpeed = 45f;
    [SerializeField] private float yawSpeed = 45f;
    [SerializeField] private float rollSpeed = 45f;
    [SerializeField] private float thrustSpeed = 20f;

    private Rigidbody rb;
    
    private float currentPitch = 0f;
    private float currentYaw = 0f;
    private float currentRoll = 0f;

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
        float targetPitch = 0f, targetYaw = 0f, targetRoll = 0f;

        if (Input.GetKey(KeyCode.W)) targetPitch = pitchSpeed;
        else if (Input.GetKey(KeyCode.S)) targetPitch = -pitchSpeed;

        if (Input.GetKey(KeyCode.A)) targetYaw = -yawSpeed;
        else if (Input.GetKey(KeyCode.D)) targetYaw = yawSpeed;
        
        if (Input.GetKey(KeyCode.Q)) targetRoll = rollSpeed;
        else if (Input.GetKey(KeyCode.E)) targetRoll = -rollSpeed;
        
        // Lerp fonksiyonu hedefe aniden değil, yumuşakça (soft) geçiş yapar
        currentPitch = Mathf.Lerp(currentPitch, targetPitch, Time.deltaTime * 5f);
        currentYaw = Mathf.Lerp(currentYaw, targetYaw, Time.deltaTime * 5f);
        currentRoll = Mathf.Lerp(currentRoll, targetRoll, Time.deltaTime * 5f);
        
        transform.Rotate(currentPitch * Time.deltaTime, currentYaw * Time.deltaTime, currentRoll * Time.deltaTime);
    }

    private void HandleThrust() 
    { 
        if (Input.GetKey(KeyCode.Space))
        {
            // Orijinal itme kodun
            rb.AddRelativeForce(Vector3.forward * thrustSpeed * Time.deltaTime, ForceMode.VelocityChange);
        }

        if (rb.linearVelocity.magnitude > 0.1f)
        {
            rb.linearVelocity = transform.forward * rb.linearVelocity.magnitude;
        }
    } 
}