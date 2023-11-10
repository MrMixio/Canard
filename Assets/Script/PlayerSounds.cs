using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.N))
        {
            Debug.Log("fonctionnel");
            this.GetComponent<AudioSource>().Play();
        }
    }

}
