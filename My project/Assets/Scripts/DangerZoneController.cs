using UnityEngine;
using System.Collections;

public class DangerZoneController : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;
    [SerializeField] private float missileDelay = 5f;
    
    private Coroutine activeCountdown;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            examManager.EnterDangerZone(); 
            
            if (activeCountdown != null) StopCoroutine(activeCountdown);
            activeCountdown = StartCoroutine(LaunchCountdown(other.transform));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (activeCountdown != null)
            {
                StopCoroutine(activeCountdown);
                activeCountdown = null;
            }
            
            examManager.ExitDangerZone();
        }
    }

    private IEnumerator LaunchCountdown(Transform target)
    {
        yield return new WaitForSeconds(missileDelay);
        Debug.Log("5 Saniye doldu, füze fırlatma komutu çalıştı!");
    }
}