using UnityEngine;
using TMPro;

public class FlightExamManager : MonoBehaviour
{
    [SerializeField] private TMP_Text statusText;
    [SerializeField] private TMP_Text missionText; 
    
    public bool hasTakenOff = false;
    public bool threatCleared = false;
    public bool missionComplete = false;

    void Start()
    {
        if (missionText != null) missionText.text = ""; 
    }

    public void EnterDangerZone()
    {
        missionText.text = "Entered a Dangerous Zone!";
        missionText.color = Color.red;
    }

    public void ExitDangerZone()
    {
        threatCleared = true;
        missionText.text = "Threat Cleared! Safe to Land.";
        missionText.color = Color.green;
    }

    public void MissionFailed()
    {
        missionText.text = "MISSION FAILED! YOU WERE HIT.";
        missionText.color = Color.red;
        threatCleared = false;
    }
}