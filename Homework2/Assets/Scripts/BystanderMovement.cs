using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.AI;
using System.Collections;



public class BystanderMovement : MonoBehaviour
{
    [SerializeField] private float _range = 15f;
    private Vector3 _destination;
    private NavMeshAgent _agent;
    private Transform _player;
    private Animator _anim;
    private bool _alive;
    private bool _running;
    private bool _lookedAtPlayer;
    private float _distance;
    private GameObject _ally;
    private float _closesAllyDistance;
    private float _rotationY;

    void Start()
    {
        _alive = true;
        // get a reference to the NavMesh Agent component
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
        _player = GameObject.Find("Player").transform;
    }

    void Update()
    {


        _distance = Vector3.Distance(this.transform.position, _player.transform.position);
        if (_alive && _distance < _range || _running)
        {
            

            if (!_lookedAtPlayer)
            {
                transform.LookAt(_player);
                _rotationY = transform.localEulerAngles.y;
                transform.localEulerAngles = new Vector3(0, _rotationY, 0);
            }

            FindClosestAlly();
            if (_ally != null)
            {
                
                _agent.destination = _ally.transform.position;
                _anim.SetBool("byStanderRunning", true);
                _lookedAtPlayer = true;
            }
            else
            {
                GetComponent<BystanderMovement>().enabled = false;
                GetComponent<WanderingAI>().enabled = true;
            }


            if (!pathComplete())
                _running = true;
            else
            {
                _anim.SetBool("byStanderRunning", false);
                _running = false;
                transform.LookAt(_player);
                _rotationY = transform.localEulerAngles.y;
                transform.localEulerAngles = new Vector3(0, _rotationY, 0);
            }
        }
        /*else if (!_alive || _distance >= _range)
        {
         
                _anim.SetBool("byStanderRunning", false);
        }*/
    }

    IEnumerator RunToAlly()
    {
        yield return new WaitForSeconds(1);
    }
    private void FindClosestAlly()
    {

        GameObject[] mutants = GameObject.FindGameObjectsWithTag("mutant");
        if (mutants != null && mutants.Length != 0)
        {
            _closesAllyDistance = Vector3.Distance(gameObject.transform.position, mutants[0].transform.position);

            foreach (var m in mutants)
            {
                _distance = Vector3.Distance(gameObject.transform.position, m.transform.position);

                if (_distance <= _closesAllyDistance)
                {
                    _closesAllyDistance = _distance;
                    _ally = m;

                }

            }

        }

        GameObject[] mutant2s = GameObject.FindGameObjectsWithTag("mutant2");
        if (mutant2s != null && mutant2s.Length != 0)
        {
            foreach (var m2 in mutant2s)
            {
                _distance = Vector3.Distance(gameObject.transform.position, m2.transform.position);

                if (_distance <= _closesAllyDistance)
                {
                    _closesAllyDistance = _distance;
                    _ally = m2;

                }

            }

        }

      
    }


    public void SetAlive(bool alive)
    {
        _alive = alive;
    }

    protected bool pathComplete()
    {
        if (Vector3.Distance(_agent.destination, _agent.transform.position) <= _agent.stoppingDistance)
        {
            if (!_agent.hasPath || _agent.velocity.sqrMagnitude == 0f)
            {
                return true;
            }
        }

        return false;
    }

}