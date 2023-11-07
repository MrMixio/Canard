using UnityEngine;

public class Mouvement : MonoBehaviour
{

    [Header("Vitesse")]
    [SerializeField] public float maxSpeed = 20f;
    [SerializeField] public float acceleration = 10.0f;

    [Header("Rotation")]
    [SerializeField] public float steeringFactor = 1f;
    [SerializeField] public float rotationSpeed = 2.0f;

    public float deceleration = 3f;

    private Rigidbody rb;
    private float currentSpeed = 0.0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float inputSpeed = 0.0f;
        float inputRotation = 0.0f;



        if (Input.GetKey(KeyCode.Z))
        {
            inputSpeed = 1.0f;
            inputRotation = steeringFactor;
        }
        if (Input.GetKey(KeyCode.E))
        {
            inputSpeed = 1.0f;
            inputRotation = -steeringFactor;
        }


        // ------- Gestion des input same moment -------
        if (Input.GetKey(KeyCode.Z) && Input.GetKey(KeyCode.E))
        {
            inputRotation = 0.0f;
        }

        if (!Input.GetKey(KeyCode.Z) && !Input.GetKey(KeyCode.E))
        {
            currentSpeed = Mathf.Lerp(currentSpeed, 0.0f, deceleration * Time.deltaTime);
        }

        currentSpeed = Mathf.Clamp(currentSpeed + inputSpeed * acceleration * Time.deltaTime, -maxSpeed, maxSpeed);
        rb.MoveRotation(rb.rotation * Quaternion.Euler(0, inputRotation * rotationSpeed * Time.deltaTime, 0));
        rb.velocity = transform.forward * currentSpeed;

        // ------- End -------
    }
}
