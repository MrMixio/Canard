
using UnityEngine;

public class Mouvement : MonoBehaviour
{
    private Rigidbody rb;
    public float vitesse = 5.0f;
    public float rotationSpeed = 45.0f;

    [Header("roulette gauche")]
    /*[SerializeField]
    private int _nouvelInputL;
    [SerializeField]
    private int _dernierInputL;
    */
    int positionActuelle1 = 1;

    [Header("roulette droite")]
    /*
    [SerializeField]
    private int _nouvelInputR;
    [SerializeField]
    private int _dernierInputR;
    */
    int positionActuelle2 = 1;

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
            VerifierProgression1(1);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            VerifierProgression1(2);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            VerifierProgression1(3);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            VerifierProgression1(4);
        }

        //mvt droite
        if (Input.GetKeyDown(KeyCode.T))
        {
            VerifierProgression2(1);
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            VerifierProgression2(2);
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            VerifierProgression2(3);
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            VerifierProgression2(4);
        }


        /*
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
        */
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

        /*
        _dernierInputL = _nouvelInputL;
        _dernierInputR = _nouvelInputR;
        */
    }




    void VerifierProgression1(int nouvellePosition)
    {
        int distance = nouvellePosition - positionActuelle1;

        Debug.Log("nouvellePosition : " + nouvellePosition + " \n positionActuelle : " + positionActuelle1 + " \n distance : " + distance);

        if (distance == 1 || distance == -3)
        {
            Debug.Log("Vous montez dans la série.");
            positionActuelle1 = nouvellePosition; // Màj position actuelle
            moveDirection = transform.forward * vitesse;
            rotationSpeedRight = -rotationSpeed; // rotation gauche
        }
        else if (distance == -1 || distance == 3)
        {
            Debug.Log("Vous descendez dans la série.");
            positionActuelle1 = nouvellePosition; // Màj position actuelle
            moveDirection = -transform.forward * vitesse;
            rotationSpeedRight = rotationSpeed; // rotation gauche
        }
        else if (distance > 1)
        {
            Debug.Log("Vous montez dans la série avec un saut de " + distance + ".");
            positionActuelle1 = nouvellePosition; // Màj position actuelle
            moveDirection = transform.forward * vitesse;
            rotationSpeedRight = -rotationSpeed; // rotation gauche
        }
        else if (distance < -1)
        {
            Debug.Log("Vous descendez dans la série avec un saut de " + Mathf.Abs(distance) + ".");
            positionActuelle1 = nouvellePosition; // Màj position actuelle
            moveDirection = -transform.forward * vitesse;
            rotationSpeedRight = rotationSpeed; // rotation gauche
        }
        else
        {
            Debug.Log("Mouvement incorrect dans la série.");
        }
    }

    void VerifierProgression2(int nouvellePosition)
    {
        int distance = nouvellePosition - positionActuelle2;

        Debug.Log("nouvellePosition : " + nouvellePosition + " \n positionActuelle : " + positionActuelle2 + " \n distance : " + distance);

        if (distance == 1 || distance == -3)
        {
            Debug.Log("Vous montez dans la série.");
            positionActuelle2 = nouvellePosition; // Màj position actuelle
            moveDirection = transform.forward * vitesse;
            rotationSpeedRight = rotationSpeed; //rotation à droite
        }
        else if (distance == -1 || distance == 3)
        {
            Debug.Log("Vous descendez dans la série.");
            positionActuelle2 = nouvellePosition; // Màj position actuelle
            moveDirection = -transform.forward * vitesse;
            rotationSpeedRight = -rotationSpeed;
        }
        else if (distance > 1)
        {
            Debug.Log("Vous montez dans la série avec un saut de " + distance + ".");
            positionActuelle2 = nouvellePosition; // Màj position actuelle
            moveDirection = transform.forward * vitesse;
            rotationSpeedRight = rotationSpeed; //rotation à droite
        }
        else if (distance < -1)
        {
            Debug.Log("Vous descendez dans la série avec un saut de " + Mathf.Abs(distance) + ".");
            positionActuelle2 = nouvellePosition; // Màj position actuelle
            moveDirection = -transform.forward * vitesse;
            rotationSpeedRight = -rotationSpeed;
        }
        else
        {
            Debug.Log("Mouvement incorrect dans la série.");
        }
    }

}
