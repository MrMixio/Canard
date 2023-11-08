using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherFrontViewDetection1 : MonoBehaviour
{
    public MotherBehavior motherBehavingScript;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            motherBehavingScript.SeeingObstacle(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            motherBehavingScript.StopSeeingObstacle(true);
        }
    }
}
