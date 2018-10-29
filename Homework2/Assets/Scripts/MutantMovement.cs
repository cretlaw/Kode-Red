using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof (NavMeshAgent))]
[RequireComponent (typeof (Animator))]
public class MutantMovement : MonoBehaviour {
	[SerializeField] private float _range = 10f;
    //public Transform _goal; // destination
    private Transform _player;
    private Animator _anim;
    private bool _alive;
    private float _distance;
    private NavMeshAgent _agent;

	
    void Start () 
    {
		_alive = true; 
        // get a reference to the NavMesh Agent component
        _agent = GetComponent<NavMeshAgent>();
		_player = GameObject.Find("Player").transform;
        _anim = GetComponent<Animator>();
        // _anim.SetBool("byStanderRunning", true);
    }

    void Update()
    {
        
		_distance = Vector3.Distance(this.transform.position, _player.transform.position);
		Vector3 direction = _player.position - this.transform.position;
		float angle = Vector3.Angle(direction, this.transform.forward);
        if(Vector3.Distance(_player.position, this.transform.position) < 10 && angle < 120){
			_anim.SetBool("isIdle", false);
			if(_alive && direction.magnitude > 5){
				_agent.destination = _player.position;
				_anim.SetBool("isWalking", true);
				_anim.SetBool("isRunning", false);
				_anim.SetBool("isAttacking", false);
				if(_alive && direction.magnitude > 6.5){
					_agent.destination = _player.position;
					_anim.SetBool("isRunning", true);
					_anim.SetBool("isWalking", false);
					_anim.SetBool("isAttacking", false);
				}
			}else{
				_anim.SetBool("isAttacking", true);
				_anim.SetBool("isWalking", false);
				_anim.SetBool("isRunning", false);
			}
		}else{
			_anim.SetBool("isIdle", true);
			_anim.SetBool("isWalking", false);
			_anim.SetBool("isAttacking", false);
		}
    }
    public void SetAlive(bool alive)
    {
        _alive = alive;
    }
}
