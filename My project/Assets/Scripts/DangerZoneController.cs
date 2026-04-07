using UnityEngine;
using System.Collections;

public class DangerZoneController : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;
    [SerializeField] private MissileLauncher missileLauncher; 
    [SerializeField] private float missileDelay = 5f;
    [SerializeField] private AudioSource warningAudioSource;
    
    private Coroutine activeCountdown;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            examManager.EnterDangerZone(); 
            
            // UYARI SESİNİ ÇAL
            if (warningAudioSource != null) warningAudioSource.Play();
            
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

            if (missileLauncher != null)
            {
                missileLauncher.DestroyActiveMissile();
            }
        }
    }

    private IEnumerator LaunchCountdown(Transform target)
    {
        yield return new WaitForSeconds(missileDelay);
        
        if (missileLauncher != null)
        {
            missileLauncher.Launch(target);
        }
    }
}