using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    

    private void OnTriggerEnter(Collider other)
    {
        if (this.gameObject.tag == "Portal1")
            other.transform.position = new Vector3(-15.7f, 4.66f, 24.2f);
        else if (this.gameObject.tag == "Portal2")
            other.transform.position = new Vector3(19.78f, 1, 1.73f);
        else if(this.gameObject.tag == "Portal3")
            other.transform.position = new Vector3(-16.02f, 4.66f, -21.18f);
        else 
            other.transform.position = new Vector3(-58.84f,1, 1.43f);

    }
}
