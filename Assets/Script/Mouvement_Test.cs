using UnityEngine;

public class Mouvement_Test : MonoBehaviour
{
    private Rigidbody _rb;
    public float _vitesse = 5.0f;
    public float _rotationSpeed = 45.0f;


    [SerializeField]
    private float _horizontalMovement;
    [SerializeField]
    private float _verticalMovement;

    Vector3 _moveDirection;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _horizontalMovement = Input.GetAxisRaw("Horizontal"); //raw = -1/0/1
        _verticalMovement = Input.GetAxisRaw("Vertical");

        _moveDirection = transform.forward * _verticalMovement + transform.right * _horizontalMovement;
        //_moveDirection = transform.forward * _verticalMovement + transform.right * _horizontalMovement;

        _rb.velocity = _moveDirection.normalized * _vitesse ;
    }
}

/*
using UnityEngine;

public class Mouvement : MonoBehaviour
{
    private Rigidbody rb;
    public float vitesse = 5.0f;
    public float rotationSpeed = 45.0f;

    [SerializeField]
    private int _nouvelInputL = 0;
    [SerializeField]
    private int _dernierInputL = 0;

    [SerializeField]
    private int _nouvelInputR = 0;
    [SerializeField]
    private int _dernierInputR = 0;


    public float deceleration = 3f;
    [SerializeField]
    private Vector3 moveDirection = Vector3.zero;
    private float rotationSpeedRight = 0.0f;
    private float rotationSpeedLeft = 0.0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //moveDirection = Vector3.zero;

        //mvt gauche
        if (Input.GetKeyDown(KeyCode.A))
        {
            _nouvelInputL = 1;
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            _nouvelInputL = 2;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            _nouvelInputL = 3;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            _nouvelInputL = 4;
        }

        //mvt droite
        if (Input.GetKeyDown(KeyCode.T))
        {
            _nouvelInputR = 5;
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            _nouvelInputR = 6;
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            _nouvelInputR = 7;
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            _nouvelInputR = 8;
        }


        //gestion gauche

        if (_nouvelInputL > _dernierInputL || (_nouvelInputL == 0 && _dernierInputL == 4))
        {
            moveDirection = transform.forward * vitesse;
            rotationSpeedRight = -rotationSpeed; // rotation gauche
            /*
            if (_nouvelInputL > 4)
            {
                rotationSpeedLeft = 0.0f;
            } 
            /
        }

        if (_nouvelInputL < _dernierInputL || (_nouvelInputL == 4 && _dernierInputL == 0))
{
    moveDirection = -transform.forward * vitesse;
    rotationSpeedRight = -rotationSpeed; // rotation gauche
    /*
    if (_nouvelInputL > 4)
    {
        rotationSpeedLeft = 0.0f;
    } 
    /
}



// gestion droit

if (_nouvelInputR > _dernierInputR || (_nouvelInputR == 5 && _dernierInputR == 8))
{

    moveDirection = transform.forward * vitesse;
    rotationSpeedLeft = rotationSpeed;
    /*
    if (_nouvelInputR <= 4)
    {
        rotationSpeedRight = 0.0f;
    }
     /
}

if (_nouvelInputR < _dernierInputR || (_nouvelInputR == 8 && _dernierInputR == 5))
{

    moveDirection = -transform.forward * vitesse;
    rotationSpeedLeft = rotationSpeed;
    /*
    if (_nouvelInputR <= 4)
    {
        rotationSpeedRight = 0.0f;
    }
     /
}


rotationSpeedRight = Mathf.Lerp(rotationSpeedRight, 0, deceleration * Time.deltaTime);
rotationSpeedLeft = Mathf.Lerp(rotationSpeedLeft, 0, deceleration * Time.deltaTime);

transform.Rotate(Vector3.up, (rotationSpeedRight + rotationSpeedLeft) * Time.deltaTime);

if (moveDirection != Vector3.zero)
{
    rb.velocity = moveDirection;
}
else
{
    rb.velocity *= 1f - deceleration * Time.deltaTime;
}


_dernierInputL = _nouvelInputL;
_dernierInputR = _nouvelInputR;

    }
}

*/