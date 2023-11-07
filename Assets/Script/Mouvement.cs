using UnityEngine;

public class Mouvement : MonoBehaviour
{
    private Rigidbody rb;
    public float vitesse = 5.0f;
    public float rotationSpeed = 45.0f; // Vitesse de rotation en degr�s par seconde
    public int dernierInput = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // V�rifie les entr�es 1, 2, 3 et 4
        int nouvelInput = 0;
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

        // G�re le mouvement en fonction de la nouvelle entr�e
        if (nouvelInput > dernierInput)
        {
            // Applique une force dans la direction inverse du "forward"
            Vector3 force = transform.forward * vitesse;
            rb.AddForce(force, ForceMode.VelocityChange);
        }

        if (nouvelInput < dernierInput)
        {
            Vector3 forcein = -transform.forward * vitesse;
            rb.AddForce(forcein, ForceMode.VelocityChange);
        }

        // G�re la rotation vers la gauche
        if (nouvelInput != dernierInput)
        {
            float rotationAmount = rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.up, -rotationAmount);
        }

        dernierInput = nouvelInput;
    }
}
