using UnityEngine;

public class Mouvement_Test : MonoBehaviour
{
    int positionActuelle1 = 1;

    int positionActuelle2 = 1;


    private void Start()
    {
    }

    private void Update()
    {
        
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

    }

    // if passe sur le m�me ? bool pour savoir si monte ou descend ? 
    // pas parfait ex : si skip 2 et 3, passage 1 � 4 en avan�ant ou reculant ? 


    //        



    void VerifierProgression1(int nouvellePosition)
    {
        int distance = nouvellePosition - positionActuelle1;

        Debug.Log("nouvellePosition : " + nouvellePosition + " \n positionActuelle : " + positionActuelle1 + " \n distance : " + distance);

        if (distance == 1 || distance == -3)
        {
            Debug.Log("Vous montez dans la s�rie.");
            positionActuelle1 = nouvellePosition; // Mettez � jour la position actuelle
        }
        else if (distance == -1 || distance == 3)
        {
            Debug.Log("Vous descendez dans la s�rie.");
            positionActuelle1 = nouvellePosition; // Mettez � jour la position actuelle
        }
        else if (distance > 1)
        {
            Debug.Log("Vous montez dans la s�rie avec un saut de " + distance + ".");
            positionActuelle1 = nouvellePosition; // Mettez � jour la position actuelle
        }
        else if (distance < -1)
        {
            Debug.Log("Vous descendez dans la s�rie avec un saut de " + Mathf.Abs(distance) + ".");
            positionActuelle1 = nouvellePosition; // Mettez � jour la position actuelle
        }
        else
        {
            Debug.Log("Mouvement incorrect dans la s�rie.");
        }
    }

    void VerifierProgression2(int nouvellePosition)
    {
        int distance = nouvellePosition - positionActuelle2;

        Debug.Log("nouvellePosition : " + nouvellePosition + " \n positionActuelle : " + positionActuelle2 + " \n distance : " + distance);

        if (distance == 1 || distance == -3)
        {
            Debug.Log("Vous montez dans la s�rie.");
            positionActuelle2 = nouvellePosition; // Mettez � jour la position actuelle
        }
        else if (distance == -1 || distance == 3)
        {
            Debug.Log("Vous descendez dans la s�rie.");
            positionActuelle2 = nouvellePosition; // Mettez � jour la position actuelle
        }
        else if (distance > 1)
        {
            Debug.Log("Vous montez dans la s�rie avec un saut de " + distance + ".");
            positionActuelle2 = nouvellePosition; // Mettez � jour la position actuelle
        }
        else if (distance < -1)
        {
            Debug.Log("Vous descendez dans la s�rie avec un saut de " + Mathf.Abs(distance) + ".");
            positionActuelle2 = nouvellePosition; // Mettez � jour la position actuelle
        }
        else
        {
            Debug.Log("Mouvement incorrect dans la s�rie.");
        }
    }












    /*
    void VerifierProgression1(int nouvellePosition)
    {
        int distance = (nouvellePosition - positionActuelle + 4) % 4; // G�rez les boucles de 1 � 4

        if (distance > 0 && distance <= 2)
        {
            Debug.Log("Vous montez dans la s�rie.");
            positionActuelle = nouvellePosition; // Mettez � jour la position actuelle
        }
        else if (distance >= 3 || distance == 0)
        {
            Debug.Log("Vous descendez dans la s�rie.");
            positionActuelle = nouvellePosition; // Mettez � jour la position actuelle
        }
        else if (distance < 0 && distance >= -2)
        {
            Debug.Log("Vous descendez dans la s�rie.");
            positionActuelle = nouvellePosition; // Mettez � jour la position actuelle
        }
        else if (distance <= -3)
        {
            Debug.Log("Vous montez dans la s�rie.");
            positionActuelle = nouvellePosition; // Mettez � jour la position actuelle
        }
        else
        {
            Debug.Log("Mouvement incorrect dans la s�rie.");
        }
    }
    */
    //faire retour bool, pour monter ou descente ? idem pour autre controller

}
