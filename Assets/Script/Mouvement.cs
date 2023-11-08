using UnityEngine;

public class Mouvement : MonoBehaviour
{
    private Rigidbody rb;
    public float vitesse = 5.0f;
    public float rotationSpeed = 45.0f;
    private int dernierInput = 0;
    private int nouvelInput = 0;
    public float deceleration = 3f;
    private Vector3 moveDirection = Vector3.zero;
    private float rotationSpeedRight = 0.0f;
    private float rotationSpeedLeft = 0.0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.A))
        {
            nouvelInput = 1;
        }
        else if (Input.GetKey(KeyCode.Z))
        {
            nouvelInput = 2;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            nouvelInput = 3;
        }
        else if (Input.GetKey(KeyCode.R))
        {
            nouvelInput = 4;
        }
        else if (Input.GetKey(KeyCode.T))
        {
            nouvelInput = 5;
        }
        else if (Input.GetKey(KeyCode.Y))
        {
            nouvelInput = 6;
        }
        else if (Input.GetKey(KeyCode.U))
        {
            nouvelInput = 7;
        }
        else if (Input.GetKey(KeyCode.I))
        {
            nouvelInput = 8;
        }

        if (nouvelInput > dernierInput)
        {
            if (nouvelInput <= 4)
            {
                moveDirection = transform.forward * vitesse;
                rotationSpeedRight = -rotationSpeed;
                if (nouvelInput > 4)
                {
                    rotationSpeedLeft = 0.0f;
                }
            }
            else
            {
                moveDirection = transform.forward * vitesse;
                rotationSpeedLeft = rotationSpeed;
                if (nouvelInput <= 4)
                {
                    rotationSpeedRight = 0.0f;
                }
            }
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

        if (nouvelInput > 0)
        {
            dernierInput = nouvelInput;
        }
    }
}
