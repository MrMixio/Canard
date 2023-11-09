
using UnityEngine;

public class Mouvement : MonoBehaviour
{
    private Rigidbody rb;
    public float vitesse = 5.0f;
    public float rotationSpeed = 45.0f;

    [Header("roulette gauche")]
    [SerializeField]
    private int _nouvelInputL;
    [SerializeField]
    private int _dernierInputL;

    [Header("roulette droite")]
    [SerializeField]
    private int _nouvelInputR;
    [SerializeField]
    private int _dernierInputR;


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

        Debug.Log("_nouvelInputR : " + _nouvelInputR + "\n _dernierInputR : " + _dernierInputR);

        //gestion gauche
        switch (_nouvelInputL)
        {
            case 1:
                if (_dernierInputL == 4)//avance
                {
                    moveDirection = transform.forward * vitesse;
                    rotationSpeedRight = -rotationSpeed; // rotation gauche
                }

                if (_dernierInputL == 2)//recul
                {
                    moveDirection = -transform.forward * vitesse;
                    rotationSpeedRight = rotationSpeed; // rotation gauche
                }

                break;

            case 2:
                if (_dernierInputL == 1)//avance
                {
                    moveDirection = transform.forward * vitesse;
                    rotationSpeedRight = -rotationSpeed; // rotation gauche
                }

                if (_dernierInputL == 3)//recul
                {
                    moveDirection = -transform.forward * vitesse;
                    rotationSpeedRight = rotationSpeed; // rotation gauche
                }
                break;

            case 3:
                if (_dernierInputL == 2)//avance
                {
                    moveDirection = transform.forward * vitesse;
                    rotationSpeedRight = -rotationSpeed; // rotation gauche
                }

                if (_dernierInputL == 4)//recul
                {
                    moveDirection = -transform.forward * vitesse;
                    rotationSpeedRight = rotationSpeed; // rotation gauche
                }
                break;

            case 4:
                if (_dernierInputL == 3)//avance
                {
                    moveDirection = transform.forward * vitesse;
                    rotationSpeedRight = -rotationSpeed; // rotation gauche
                }

                if (_dernierInputL == 1)//recul
                {
                    moveDirection = -transform.forward * vitesse;
                    rotationSpeedRight = rotationSpeed; // rotation gauche
                }
                break;

            default:
                break;
        }


        // gestion droit

        switch (_nouvelInputR)
        {
            case 5:
                if (_dernierInputR == 8)//avance
                {
                    moveDirection = transform.forward * vitesse;
                    rotationSpeedRight = rotationSpeed; //rotation à droite
                }

                if (_dernierInputR == 6)//recul
                {
                    moveDirection = -transform.forward * vitesse;
                    rotationSpeedRight = -rotationSpeed;
                }

                break;

            case 6:
                if (_dernierInputR == 5)//avance
                {
                    moveDirection = transform.forward * vitesse;
                    rotationSpeedRight = rotationSpeed; //rotation à droite
                }

                if (_dernierInputR == 7)//recul
                {
                    moveDirection = -transform.forward * vitesse;
                    rotationSpeedRight = -rotationSpeed;
                }
                break;

            case 7:
                if (_dernierInputR == 6)//avance
                {
                    moveDirection = transform.forward * vitesse;
                    rotationSpeedRight = rotationSpeed; //rotation à droite
                }

                if (_dernierInputR == 8)//recul
                {
                    moveDirection = -transform.forward * vitesse;
                    rotationSpeedRight = -rotationSpeed;
                }
                break;

            case 8:
                if (_dernierInputR == 7)//avance
                {
                    moveDirection = transform.forward * vitesse;
                    rotationSpeedRight = rotationSpeed; //rotation à droite
                }

                if (_dernierInputR == 5)//recul
                {
                    moveDirection = -transform.forward * vitesse;
                    rotationSpeedRight = -rotationSpeed;
                }
                break;

            default:
                break;

        }

        rotationSpeedRight = Mathf.Lerp(rotationSpeedRight, 0, deceleration * Time.deltaTime);
        rotationSpeedLeft = Mathf.Lerp(rotationSpeedLeft, 0, deceleration * Time.deltaTime);

        transform.Rotate(Vector3.up, (rotationSpeedRight + rotationSpeedLeft) * Time.deltaTime);

        if (moveDirection != Vector3.zero)
        {
            Debug.Log("ici zero");
            rb.velocity = moveDirection;
        }
        else
        {
            Debug.Log("là bouge");

            rb.velocity *= 1f - deceleration * Time.deltaTime;
        }


        _dernierInputL = _nouvelInputL;
        _dernierInputR = _nouvelInputR;

    }
}
