using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This script will act as the controller for the player's weapon system.
//Allowing enemy to switch guns, shoot bullets to harm enemies and create bulletholes.
public class WeaponsController : MonoBehaviour
{

    //storing different guns
    [SerializeField]
    private enum Guns
    {
        Handgun = 0,
        Shotgun = 1,
        Rifle = 2

    }
    //Setting the initial player weapon to handgun
    [SerializeField] private Guns _playerGun = Guns.Handgun;

    private Camera _camera;

    [SerializeField] private GameObject _handGunBulletHolePrefab;
    [SerializeField] private GameObject _shotGunBulletHolePrefab;
    [SerializeField] private GameObject _riffleBulletHolePrefab;
    private GameObject _BulletHole;


    // Use this for initialization
    void Start()
    {
        _camera = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void OnGUI()
    {
        int size = 12;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {


            Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
            Ray ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;
            /*Ray ray = new Ray(transform.position, transform.forward);*/
            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();

                if (target != null)
                {
                 
                    target.ReactToHit();
                }
                else
                {
                    //TODO: Figure out why bulletholes don't work on walls and floors
                    Vector3 normal = hit.normal;
                    Vector3 pos = hit.point;
                    SwitchBulletHoles(normal, pos);

                }


            }


        }

        if (Input.GetMouseButtonDown(1))
            SwitchWeapons();



    }

    private IEnumerator BulletholeIndicator()
    {


        yield return new WaitForSeconds(2);
        Destroy(_BulletHole);
    }


    private void SwitchWeapons()
    {
        if (_playerGun == Guns.Handgun)
        {
            _playerGun = Guns.Shotgun;
            Debug.Log("Shotgun now selected!");

        }

        else if (_playerGun == Guns.Shotgun)
        {
            _playerGun = Guns.Rifle;
            Debug.Log("Riffle now selected!");
        }

        else if (_playerGun == Guns.Rifle)
        {
            _playerGun = Guns.Handgun;
            Debug.Log("Handgun now Selected!");
        }
    }

    private void SwitchBulletHoles(Vector3 normal, Vector3 pos)
    {
        if (_playerGun == Guns.Handgun)
        {
            _BulletHole = Instantiate(_handGunBulletHolePrefab, pos, Quaternion.FromToRotation(Vector3.up, normal));
            StartCoroutine(BulletholeIndicator());

        }

        else if (_playerGun == Guns.Shotgun)
        {
            _BulletHole = Instantiate(_shotGunBulletHolePrefab, pos, Quaternion.FromToRotation(Vector3.up, normal));
            StartCoroutine(BulletholeIndicator());
        }

        else if (_playerGun == Guns.Rifle)
        {
            _BulletHole = Instantiate(_riffleBulletHolePrefab, pos, Quaternion.FromToRotation(Vector3.up, normal));
            StartCoroutine(BulletholeIndicator());
        }

    }
}
