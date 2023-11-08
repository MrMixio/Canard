using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherViewDetection : MonoBehaviour
{
    public MotherBehavior motherBehavingScript;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            motherBehavingScript.SeeingObstacle(false);
            //Debug.Log("Obstacle");
        }

        if (other.CompareTag("Wall"))
        {
            motherBehavingScript.SeeingWall();
            Debug.Log("WallBang !");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            motherBehavingScript.StopSeeingObstacle(false);
        }      

        if (other.CompareTag("Wall"))
        {
            motherBehavingScript.SeeingWall();
            Debug.Log("WallBang !");
        }
    }
}
