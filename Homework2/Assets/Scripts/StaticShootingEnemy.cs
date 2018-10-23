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
    private Vector3 _direction;
    public bool IsAlert;
    private Mutant2Controller _m2Controller;

    // Use this for initialization
    void Start()
    {
        _player = GameObject.Find("Player").transform;
        _alive = true;
        _anim = GetComponent<Animator>();
        _gun = GetComponentInChildren<Gun>();
        _m2Controller = gameObject.GetComponent<Mutant2Controller>();

    }

    // Update is called once per frame
    void Update()
    {
        _distance = Vector3.Distance(this.transform.position, _player.transform.position);
        if ((_alive && _distance < _range) || IsAlert)
        {
            _anim.SetBool("shootM2", true);
            AttackPlayer();
        }
        else if (!_alive || _distance >= _range) 
            _anim.SetBool("shootM2", false);

    }

    private void AttackPlayer()
    {
        _m2Controller.AlertOthers();
        _direction = _player.position - this.transform.position;
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(_direction), 0.1f);

        _gun.ShootWeapon();

    }

    public void SetAlive(bool alive)
    {
        _alive = alive;
    }

    




}

