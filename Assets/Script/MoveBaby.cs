using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBaby : MonoBehaviour
{
    public Transform _motherDuck;
    public float _limite;

    public float _speed;

    private Rigidbody _rb;
    public float _smoothVelocity;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 _distCalc = _motherDuck.position - transform.position;

        //Debug.Log(_distCalc);
        Debug.DrawLine(transform.position, _motherDuck.position);

        Vector3 _limiteWithMother = _distCalc.normalized * (_distCalc.magnitude - _limite);


        _rb.velocity = _limiteWithMother * _speed;

        //rotation 
        float _targetAngle = Mathf.Atan2(_distCalc.x, _distCalc.z) * Mathf.Rad2Deg;
        float _angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetAngle, ref _smoothVelocity, 0.1f);

        transform.rotation = Quaternion.Euler(0f, _angle, 0f);


    }



    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(_motherDuck.position, _limite);
    }
}
