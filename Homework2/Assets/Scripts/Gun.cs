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
      
        Ray ray = new Ray(this.transform.position, this.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {

            transform.LookAt(_player);
            GameObject hitObject = hit.transform.gameObject;
            if (hitObject.GetComponent<PlayerController>())
            {
                Debug.Log("Player HIT!");
                _muzzleFlash.Play();
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
                _muzzleFlash.Stop();
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }

    }


}
