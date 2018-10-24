using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.AI;
using System.Collections;

public class BystanderMovement : MonoBehaviour {
    [SerializeField] private float _range = 15f;
    public Transform _goal; // destination
    public Transform _player;
    public Transform _self;
    private Animator _anim;
    private bool _alive;
    private float _distance;
    private NavMeshAgent _agent;
    void Start () 
    {
        _alive = true; 
        // get a reference to the NavMesh Agent component
        _agent = GetComponent<NavMeshAgent>();

        _anim = GetComponent<Animator>();
        // _anim.SetBool("byStanderRunning", true);
    }

    void Update()
    {
        _distance = Vector3.Distance(this.transform.position, _player.transform.position);
        if ((_alive && _distance < _range))
        {
            _agent.destination = _goal.position;
            _anim.SetBool("byStanderRunning", true);

            // if the bystander reaches its target, return to the idle position
            if(Vector3.Distance(_self.position, _goal.position) <= 1.0f) {
                _anim.SetBool("byStanderRunning", false);
            }
        }
        else if (!_alive || _distance >= _range) {
            _anim.SetBool("byStanderRunning", false);
            _agent.destination = _self.position;
        }
    }
}