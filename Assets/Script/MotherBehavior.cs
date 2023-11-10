using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class MotherBehavior : MonoBehaviour
{
    [SerializeField] private Waypoints waypoints;

    public float motherSpeed = 5f;
    public float waypointDistanceTreshold = 1f;

    private Transform currentWaypoint;
    private Vector3 directWaypoint;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        transform.position = currentWaypoint.position;

        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
    }

    private void FixedUpdate()
    {
        directWaypoint = currentWaypoint.position;
        Vector3 lerpedDirection = Vector3.RotateTowards(transform.forward, (currentWaypoint.position - transform.position).normalized, 0.1f, 1);
        transform.rotation = Quaternion.LookRotation(lerpedDirection);
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, motherSpeed / 30);

        //Vector3 Direction = Vector3.RotateTowards(transform.forward, (currentWaypoint.position - transform.position).normalized, 0.01f, 1);
        //float lerpedDirection = Mathf.Lerp(Dire);
        //transform.rotation = Quaternion.Euler(0, transform.forward.y + Direction.y, 0);
        //Debug.Log(transform.rotation.y + Direction.y);

        //Vector3 lerpedDirection = Vector3.RotateTowards(transform.forward, (directWaypoint - transform.position), 0.02f, 1);
        //transform.rotation = Quaternion.LookRotation(lerpedDirection);

        //Vector3 rotateAngle = Vector3.RotateTowards(transform.forward, directWaypoint - transform.position, 10, 1);
        //Debug.Log(rotateAngle);
        //transform.rotation = Quaternion.Euler(0,rotateAngle.y,0);
        //rb.velocity = transform.forward * motherSpeed * 5;

        if (Vector3.Distance(transform.position, currentWaypoint.position) < waypointDistanceTreshold)
        {
            currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        }
    }

    private void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * 5, Color.magenta);
        Debug.DrawRay(transform.position, directWaypoint - transform.position, Color.white);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(directWaypoint, 3);
    }
}
