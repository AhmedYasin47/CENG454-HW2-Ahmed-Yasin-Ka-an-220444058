using UnityEngine;
using System.Collections;

public class DangerZoneController : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;
    [SerializeField] private MissileLauncher missileLauncher; 
    [SerializeField] private float missileDelay = 5f;
    [SerializeField] private AudioSource warningAudioSource; 
    
    [Header("Gorsel Ayarlar")]
    [SerializeField] private Material solidMaterial;
    [SerializeField] private Material glassMaterial; 
    
    private Coroutine activeCountdown;
    private MeshRenderer zoneRenderer;

    void Start()
    {
        zoneRenderer = GetComponent<MeshRenderer>();
        
        if (zoneRenderer != null && solidMaterial != null)
        {
            zoneRenderer.material = solidMaterial;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // İÇİNE GİRİNCE TOPUN MATERYALİNİ "CAM" YAP
            if (zoneRenderer != null && glassMaterial != null)
            {
                zoneRenderer.material = glassMaterial;
            }

            examManager.EnterDangerZone(); 
            
            if (warningAudioSource != null) warningAudioSource.Play();
            
            if (activeCountdown != null) StopCoroutine(activeCountdown);
            activeCountdown = StartCoroutine(LaunchCountdown(other.transform));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (zoneRenderer != null && solidMaterial != null)
            {
                zoneRenderer.material = solidMaterial;
            }

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