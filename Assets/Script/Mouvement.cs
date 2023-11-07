using UnityEngine;

public class Mouvement : MonoBehaviour
{
    public float maxSpeed = 5.0f;
    public float rotationSpeed = 2.0f;
    public float acceleration = 1.0f;
    public float steeringFactor = 0.2f;
    public float deceleration = 1.0f;

    private float currentSpeed = 0.0f;

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

        if (Input.GetKey(KeyCode.Z) && Input.GetKey(KeyCode.E))
        {
            inputRotation = 0.0f;

        }

        if (!Input.GetKey(KeyCode.Z) && !Input.GetKey(KeyCode.E))
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0.0f, deceleration * Time.deltaTime);
        }

        currentSpeed = Mathf.Clamp(currentSpeed + inputSpeed * acceleration * Time.deltaTime, -maxSpeed, maxSpeed);
        transform.Rotate(Vector3.up, inputRotation * rotationSpeed * Time.deltaTime);
        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
    }
}
