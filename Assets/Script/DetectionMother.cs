using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionMother : MonoBehaviour
{
    private GameObject[] _listBaby;
    private GameObject _further;

    public Transform _mother;
    private Vector3 _distFurther;

    public float _saveTime = 2f;
    [SerializeField]
    private float _timer;
    public bool _activeTimer;
    public MoveMother _scriptMother;

    // Start is called before the first frame update
    void Start()
    {
        _listBaby = GameObject.FindGameObjectsWithTag("Baby");
        _timer = _saveTime;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        foreach(GameObject _baby in _listBaby)
        {
            if((_mother.position - _baby.transform.position).magnitude > _distFurther.magnitude)
            {
                _distFurther = _mother.position - _baby.transform.position;
                _further = _baby;
            }
        }

        Debug.Log(_further.name);

        transform.position = _further.transform.position;
        */



        if (_activeTimer)
        {
            _timer -= Time.deltaTime;
        }

        if (_timer <= 0)
        {

            //_timer = _saveTime;
            _scriptMother.updateTrigger(true);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TimerReset();

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && !_scriptMother._isTrigger)
        {
            TimerReset();
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !_scriptMother._isTrigger)
        {
            _activeTimer = true; // on met en marche le timer
        }
    }

    private void TimerReset()
    {
        _timer = _saveTime; // reset du timer
        _activeTimer = false;
    }
}
