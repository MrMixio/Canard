using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamerMother : MonoBehaviour
{

    public Rigidbody _rb;

    [SerializeField]
    private int  _randNumber;

    public int _range;

    public float _timerPress;
    public float _timeSave;


    public bool _isTrigger;
    public MoveMother _scriptMother;


    // Start is called before the first frame update
    void Start()
    {
        _timeSave = _timerPress;
        _rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if(!_isTrigger)
            _randNumber = Random.Range(1, _range);//range non inclu


        if(_randNumber == 5)
        {
            _isTrigger = true;
            _scriptMother.isScreaming(true);

        }

        if (_isTrigger)
        {
            _timerPress -= Time.deltaTime;
        }

        if (_timerPress <= 0)
        {
            _scriptMother.updateTrigger(true);
        }

        if (Input.GetKey(KeyCode.B) && _timerPress > 0)
        {
            _isTrigger = false;
            _timerPress = _timeSave;
            _scriptMother.isScreaming(false);

            // remettre rotation canard
        }


    }




}
