using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class StaticShootingEnemy : MonoBehaviour
{

    [SerializeField] private float _range = 15f;
    private Transform _player;

    private bool _alive;
    private float _distance;
    private Animator _anim;
    private Gun _gun;

    // Use this for initialization
    void Start()
    {
        _player = GameObject.Find("Player").transform;
        _alive = true;
        _anim = GetComponent<Animator>();
        _gun = GameObject.Find("TipOfGun").GetComponent<Gun>();
    }

    // Update is called once per frame
    void Update()
    {
        _distance = Vector3.Distance(this.transform.position, _player.transform.position);
        if (_alive && _distance < _range)
            AttackPlayer();

        else if(!_alive || _distance >= _range)
        {
         
           _anim.SetBool("shootM2", false);
            
        }
    }


    private void AttackPlayer()
    {
        _anim.SetBool("shootM2", true);
        transform.LookAt(_player);
        _gun.ShootWeapon();

    }


    public void SetAlive(bool alive)
    {
        _alive = alive;
    }

}
