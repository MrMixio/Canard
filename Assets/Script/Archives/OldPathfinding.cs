using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldPathfinding : MonoBehaviour
{
    public GameObject directLine;
    public GameObject frontView;
    public GameObject frontSecondaryView;

    public float motherSpeed;
    public float motherTurnSpeed;
    public float motherViewRange;
    public float motherWaveIntervalMin;
    public float motherWaveIntervalMax;

    private float motherWaveTimer;
    private float escapeDirection;

    private Vector3 finishPos;
    private Vector3 directPoint;
    private Vector3 frontPoint;
    private Vector3 frontSecondaryPoint;

    private bool isWaving = false;
    private bool isSeeingObstacle = false;
    private bool isStillSeeingObstacle = false;
    private bool isFrontSeeingObstacle = false;
    private bool isSeeingWall = false;
    private bool isObstacleLooping = false;
    private Rigidbody _RB;

    void Start()
    {
        finishPos = directLine.transform.position;
        _RB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * 5, Color.red);
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(directPoint, 3);
        Gizmos.DrawSphere(frontPoint, 1);
    }
    void FixedUpdate()
    {
        //if (isWaving == false && isSeeingObstacle == false)
        {
            //Rotation de la mère canard lorsqu'elle ne wave pas et qu'elle ne vois pas d'obstacles
            directPoint = new Vector3(transform.position.x - 10, transform.position.y, finishPos.z);

            Vector3 lerpedDirection = Vector3.RotateTowards(transform.forward, (directPoint - transform.position).normalized, 0.005f, 1);
            transform.rotation = Quaternion.LookRotation(lerpedDirection);
        }

        //if (isSeeingObstacle)
        {
            isObstacleLooping = true;

            if (!isStillSeeingObstacle)
            {
                //décide de la direction du doge (droite ou gauche) jusqu'à atteindre un point sans 
                if (transform.position.z > directPoint.z)
                {
                    escapeDirection = 1;
                }
                if (transform.position.z <= directPoint.z)
                {
                    escapeDirection = -1;
                }
                isStillSeeingObstacle = true;
            }
        }

        //if (isObstacleLooping) 
        {
            Vector3 rotationValue = new Vector3(0, escapeDirection * motherTurnSpeed, 0);
            transform.rotation = Quaternion.Euler(rotationValue);
            if (transform.rotation.z < -170)
            {
                transform.rotation = Quaternion.Euler(0, -170, 0);
            }
            if (transform.rotation.z > -10)
            {
                transform.rotation = Quaternion.Euler(0, -10, 0);
            }

            if (isSeeingWall)
            {
                isObstacleLooping = false;
            }
        }

        frontPoint = transform.position + transform.forward * motherViewRange;
        frontView.transform.position = frontPoint;
        frontSecondaryPoint = new Vector3(transform.position.x - 10, transform.position.y, transform.position.z);
        frontSecondaryView.transform.position = frontSecondaryPoint;

        _RB.velocity = transform.forward * motherSpeed;
    }

    public void SeeingObstacle(bool isFrontView)
    {
        if (isFrontView)
        {
            isFrontSeeingObstacle = true;
        }
        else
        {
            isSeeingObstacle = true;
        }
    }
    public void StopSeeingObstacle(bool isFrontView)
    {
        if (isFrontView)
        {
            isFrontSeeingObstacle = false;
        }
        else
        {
            isSeeingObstacle = false;
        }
    }

    public void SeeingWall()
    {
        isSeeingWall = true;
    }
    public void StopSeeingWall()
    {
        isSeeingWall = false;
    }
}
