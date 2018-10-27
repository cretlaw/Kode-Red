using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public int health;
    public int RoomNumber;
    private Animator _anim;
    private SceneController _sceneController;
    private PlayerWeaponsController _playerWeaponsController;
    private FPSInput _fpsInput;

    void Start()
    {
        health = 100;
        _sceneController = GameObject.Find("Controller").GetComponent<SceneController>();
        _fpsInput = GetComponent<FPSInput>();
        _playerWeaponsController = GameObject.Find("Weapons").GetComponent<PlayerWeaponsController>();
    }

    void Update()
    {
        //if player is killed stop enemy and player from shooting and stop enemy from moving around only rotate.
        if (health <= 0)
        {
            //Prevents the player from moving and shooting only moving camera
            _fpsInput.enabled = false;
            _playerWeaponsController.enabled = false;
            StopEnemyShooting();

            if (Input.GetKeyDown(KeyCode.R))
            {
                _sceneController.Reset();
                _fpsInput.enabled = true;
                _playerWeaponsController.enabled = true;
            }
        }

        if (gameObject.transform.position.z < -13.5693f)
            RoomNumber = 3;
        else if (gameObject.transform.position.z >= -13.5693f && gameObject.transform.position.z <= 15.23492f)
            RoomNumber = 1;
        else
            RoomNumber = 2;



    }
    public void Hurt(int damage)
    {
        health -= damage;
        Debug.Log("Health: " + health);


    }

    public void HealthPickup(int heal)
    {
        health += heal;
        Debug.Log("Health: " + health);
    }

    private void StopEnemyShooting()
    {
       
        //Below is the code to stop all enemy fire and the walking enemies will wander around.
        GameObject[] mutants = GameObject.FindGameObjectsWithTag("mutant");

        if (mutants != null && mutants.Length != 0)
        {
            foreach (var m in mutants)
            {
                m.GetComponent<MutantMovement>().enabled = false;
                m.GetComponentInChildren<MutantShoot>().enabled = false;
                m.GetComponent<WanderingAI>().enabled = true;
                m.GetComponent<ReactiveTarget>().enabled = false;
            }
        }

        GameObject[] mutants2 = GameObject.FindGameObjectsWithTag("mutant2");

        if (mutants2 != null && mutants2.Length != 0)
        {
            foreach (var m2 in mutants2)
            {
                m2.GetComponent<StaticShootingEnemy>().enabled = false;
                m2.GetComponent<ReactiveTarget>().enabled = false;
                _anim = m2.GetComponent<Animator>();
                _anim.SetBool("shootM2", false);
                _anim.SetBool("playerDied", true);

            }
        }

        GameObject[] byStanders = GameObject.FindGameObjectsWithTag("byStander");

        if (byStanders != null && byStanders.Length !=  0)
        {

            foreach (var b in byStanders)
            {
                b.GetComponent<BystanderMovement>().enabled = false;
                b.GetComponent<ReactiveTarget>().enabled = false;
                b.GetComponent<WanderingAI>().enabled = true;
            }
        }



    }
}
