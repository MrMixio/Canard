﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamerMother : MonoBehaviour
{

    public Rigidbody _rb;

    [SerializeField]
    private int  _randNumber;

    public int _range;

    public float _timerPress;
    public float _timeSavePress;

    public float _timerActiveAggro;
    public float _timeMaxActiveAggro;

    public bool _isAggro;
    public MotherBehavior _scriptMother;


    // Start is called before the first frame update
    void Start()
    {
        _timeSavePress = _timerPress;
        _timeMaxActiveAggro = _timerActiveAggro;
        _rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (_timerActiveAggro <= 0)
        {
            if (!_isAggro)//si pas en aggro
                _randNumber = Random.Range(1, _range);//range non inclu


            if (_randNumber == 5)
            {
                _isAggro = true;
                _scriptMother.isScreaming(true);

            }

            if (_isAggro)
            {
                _timerPress -= Time.deltaTime;
            }

            if (_timerPress <= 0)
            {
                _scriptMother.updateTrigger(true);
            }
        }
        else
        {
            _timerActiveAggro -= Time.deltaTime;
        }


        if (Input.GetKey(KeyCode.B) && Input.GetKey(KeyCode.N) && _timerPress > 0)
        {
            _isAggro = false;
            _timerPress = _timeSavePress;
            _timerActiveAggro = _timeMaxActiveAggro;
            _scriptMother.RotateTowardsPlayer(_scriptMother.getCurrentWaypoint());
            _scriptMother.isScreaming(false);

            // remettre rotation canard
        }


    }




}
