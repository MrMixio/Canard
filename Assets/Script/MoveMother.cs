using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMother : MonoBehaviour
{
    private bool _isMoving;
    private Transform _dirPos;
    private Vector3 _dirPosVec;

    public float _speed;

    private Rigidbody _rb;

    public bool _isAggro;
    public Transform _player;
    public float _smoothVelocity;//rotation

    public bool _isScream;


    [Header("Waypoints")]
    private Transform currentWaypoint;
    private Vector3 directWaypoint;
    public float waypointDistanceTreshold = 1f;
    //public Transform[] _wayPoints;
    // public int _index = 0;


    // Start is called before the first frame update
    void Start()
    {
        StartMoving();
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isMoving) return;


        if (_isAggro) // on aggro de joueur
        {
            /*
            Vector3 _dir = _player.position - transform.position;
            float _targetAngle = Mathf.Atan2(_dir.x, _dir.z) * Mathf.Rad2Deg;
            float _angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetAngle, ref _smoothVelocity, 0.1f);

            transform.rotation = Quaternion.Euler(0f, _angle, 0f);

            */
            Vector3 _dir = RotateTowardsPlayer(_player);

            //_rb.AddForce(_moveDir.normalized * _speed * Time.deltaTime);
            _rb.velocity = _dir * _speed;


// WAYPOINT MARIU

        }
        else
        {

            //transform.Translate(Vector3.forward * Time.deltaTime);
            _rb.velocity = Vector3.forward * _speed;

            /*
            Vector3 oldPosition = transform.position;
            transform.position = Vector3.MoveTowards(transform.position, _wayPoints[_index].position, _speed * Time.deltaTime);

            Vector3 displacement = transform.position - oldPosition;

            /*

            foreach (Transform obj in _wayPoints)
            {
                if (obj.transform.position.y <= transform.position.y) continue;

                obj.transform.position += displacement;
            }
            /
            transform.position += displacement;
            */
        }

        if (_isScream)
        {
            Scream();
        }
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


    public void isScreaming(bool _set = false)
    {
        _isScream = _set;
    }

    void Scream()
    {
        if(!_isAggro) // si cane va sur player, on ne met pas la velocité à 0
            _rb.velocity = Vector3.zero;

        RotateTowardsPlayer(_player); // pas stocké dans variable car on ne veut pas ajouter de la velocité
    }

    public Vector3 RotateTowardsPlayer(Transform _posTarget)
    {
        Vector3 _dir = _posTarget.position - transform.position;
        float _targetAngle = Mathf.Atan2(_dir.x, _dir.z) * Mathf.Rad2Deg;
        float _angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetAngle, ref _smoothVelocity, 0.1f);

        transform.rotation = Quaternion.Euler(0f, _angle, 0f);

        return _dir;
    }

}
