using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public int health;
    

    void Start()
    {
        health = 100;
    }

    void Update()
    {
        //if player is killed stop enemy and player from shooting and stop enemy from moving around only rotate.
        if (health <= 0)
        {
            //TODO:Figure out how to destroy any bullets that are on the air when health reaches 0 
            StopEnemyShooting();
        }

       
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
        this.GetComponent<FPSInput>().enabled = false;
        GameObject.Find("Player View Camera").GetComponent<WeaponsController>().enabled = false;



    }
}
