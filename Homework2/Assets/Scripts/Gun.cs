using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    private ParticleSystem _muzzleFlash;
     private Transform _player;

    // Use this for initialization
    void Start()
    {
        _player = GameObject.Find("Player").transform;
        GameObject muzzleFlashObj = GameObject.Find("muzzleFlash");
        _muzzleFlash = muzzleFlashObj.GetComponent<ParticleSystem>();
    }



    public void ShootWeapon()
    {
      
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.SphereCast(ray, 0.75f, out hit))
        {

            transform.LookAt(_player);
            GameObject hitObject = hit.transform.gameObject;
            if (hitObject.GetComponent<PlayerController>())
            {
                Debug.Log("Player HIT!");
                _muzzleFlash.Play();

            }
            else
                _muzzleFlash.Stop();
            
        }

    }


}
