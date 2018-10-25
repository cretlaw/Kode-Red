using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    private ParticleSystem _muzzleFlash;
    private GameObject _player;
    private int _shootOffSet = 0;

    // Use this for initialization
    void Start()
    {
        _player = GameObject.Find("Player");
        
        _muzzleFlash = GetComponentInChildren<ParticleSystem>();
    }



    public void ShootWeapon()
    {

        

        Ray ray = new Ray(this.transform.position, this.transform.forward);
        RaycastHit hit;
        if (Physics.SphereCast(ray,0.75f, out hit))
        {

            transform.LookAt(_player.transform);
            GameObject hitObject = hit.transform.gameObject;
            if (hitObject.GetComponent<PlayerController>())
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
                _muzzleFlash.Stop();
                if (_shootOffSet == 60)
                {
                    _muzzleFlash.Play();
                    
                    _player.GetComponent<PlayerController>().Hurt(1);
                    _shootOffSet = 0;
                }

                _shootOffSet++;
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
