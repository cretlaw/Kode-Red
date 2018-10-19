using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    private ParticleSystem muzzleFlash;
   

    // Use this for initialization
    void Start()
    {
        GameObject muzzleFlashObj = GameObject.Find("muzzleFlash");
        muzzleFlash = muzzleFlashObj.GetComponent<ParticleSystem>();
    }



    public void ShootWeapon()
    {

        muzzleFlash.Play();
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.SphereCast(ray, 0.75f, out hit))
        {
            Debug.Log("Name of component hit:" + hit.collider.gameObject.name);
          
            GameObject hitObject = hit.transform.gameObject;
            if (hitObject.GetComponent<PlayerController>())
            {
                muzzleFlash.Play();
            }
            else
                muzzleFlash.Stop();
        }

    }


}
