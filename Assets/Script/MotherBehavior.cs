using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;


public class MotherBehavior : MonoBehaviour
{
    [SerializeField] private Waypoints _scriptWaypoints;

    [Header("Movement")]
    private bool _isMoving;
    public float _motherSpeed = 5f;
    private Rigidbody _rb;
    public float _smoothVelocity;//rotation
    public float _smoothTurnWaypoint = 0.02f;

    [Header("Waypoints")]
    private Transform _currentWaypoint;
    private Vector3 directWaypoint;
    public float _waypointDistanceTreshold = 1f;


    [Header("Aggro")]
    public bool _isAggro;
    public bool _isScream;
    public Transform _player;


    void Start()
    {
        StartMoving();

        _rb = GetComponent<Rigidbody>();

        _currentWaypoint = _scriptWaypoints.GetNextWaypoint(_currentWaypoint);
        transform.position = _currentWaypoint.position;

        _currentWaypoint = _scriptWaypoints.GetNextWaypoint(_currentWaypoint);
    }

    private void FixedUpdate()
    {

        if (!_isMoving) return;

        if (_isAggro) // on aggro de joueur
        {

            Vector3 _dir = RotateTowardsPlayer(_player);

            //_rb.AddForce(_moveDir.normalized * _speed * Time.deltaTime);
            _rb.velocity = _dir * _motherSpeed;

        }
        else if(!_isScream)
        {
            _rb.velocity = Vector3.zero;
            //transform.position = Vector3.MoveTowards(transform.position, _currentWaypoint.position, motherSpeed / 4);
            directWaypoint = _currentWaypoint.position;
            Vector3 lerpedDirection = Vector3.RotateTowards(transform.forward, (_currentWaypoint.position - transform.position).normalized, 0.1f, 1);
            transform.rotation = Quaternion.LookRotation(lerpedDirection);
            transform.position = Vector3.MoveTowards(transform.position, _currentWaypoint.position, _motherSpeed / 30);
            

            if (Vector3.Distance(transform.position, _currentWaypoint.position) < _waypointDistanceTreshold)
            {
                _currentWaypoint = _scriptWaypoints.GetNextWaypoint(_currentWaypoint);
            }
        }

        if (_isScream)
        {
            Scream();
        }

    }
    private void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * 5, Color.magenta);
        Debug.DrawRay(transform.position, directWaypoint - transform.position, Color.white);
    }

    public void StartMoving()
    {
        _isMoving = true;
    }
    public void StopMoving()
    {
        _isMoving = false;
    }

    public void updateTrigger(bool _set)
    {
        _isAggro = _set;
    }

    public bool getTrigger()
    {
        return _isAggro;
    }

    public void isScreaming(bool _set = false)
    {
        _isScream = _set;
    }

    void Scream()
    {
        
        if (!_isAggro) // si cane va sur player, on ne met pas la velocite a 0
            _rb.velocity = Vector3.zero;
        
        RotateTowardsPlayer(_player); // pas stocké dans variable car on ne veut pas ajouter de la velocite
    }

    public Transform getCurrentWaypoint()
    {
        return _currentWaypoint;
    }

    public Vector3 RotateTowardsPlayer(Transform _posTarget)
    {
        Vector3 _dir = _posTarget.position - transform.position;
        float _targetAngle = Mathf.Atan2(_dir.x, _dir.z) * Mathf.Rad2Deg;
        float _angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetAngle, ref _smoothVelocity, 0.1f);

        transform.rotation = Quaternion.Euler(0f, _angle, 0f);

        return _dir;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && _isAggro)
        {
            SceneManager.LoadScene("Game_Over");

        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(directWaypoint, 3);
    }
}
