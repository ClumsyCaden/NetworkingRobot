using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CameraScript : MonoBehaviour
{
    void Update()
    {
        if (!this.transform.parent.GetComponent<PlayerMovement>().isLocalPlayer)
        {
            gameObject.GetComponent<Camera>().enabled = false;
            gameObject.GetComponent<AudioListener>().enabled = false;
        }
       
    }
}
