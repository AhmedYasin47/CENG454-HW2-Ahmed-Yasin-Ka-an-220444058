using UnityEngine;

public class LandingZoneController : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (examManager != null)
            {
                examManager.CompleteMission();
            }
        }
    }
}