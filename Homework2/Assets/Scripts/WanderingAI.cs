using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WanderingAI : MonoBehaviour
{

    
    private Vector3 destination;
    private NavMeshAgent agent;
    private int RoomNumber;
    private float _randX;
    private float _randZ;

    private Animator _anim;
    private SceneController _sceneController;

    //Todo: Figure out why bystander moves before animation starts
    void Start()
    {
        _anim = GetComponent<Animator>();

        _sceneController = GameObject.Find("Controller").GetComponent<SceneController>();

       
        if (this.gameObject.tag == "mutant")
            _anim.SetBool("isWalking", true);

        else
        {
            _anim.SetBool("byStanderRunning", true);

            StartCoroutine(WaitForAnimations());
        }

        // Cache agent component and destination
        agent = GetComponent<NavMeshAgent>();
        RoomNumber = GetRoomNumber();
        agent.destination = WalkTo();


    }



    // Update is called once per frame
    void Update()
    {

        if (pathComplete())
            agent.destination = WalkTo();

    }


    private Vector3 WalkTo()
    {
        if (RoomNumber == 1)
            destination = _sceneController.GetRoom1RandomLocations();
        else if (RoomNumber == 2)
            destination = _sceneController.GetRoom2RandomLocations();
        else
            destination = _sceneController.GetRoom3RandomLocations();

        return destination;
    }

    private int GetRoomNumber()
    {
        if (gameObject.transform.position.z < -13.5693f)
            RoomNumber = 3;
        else if (gameObject.transform.position.z >= -13.5693f && gameObject.transform.position.z <= 15.23492f)
            RoomNumber = 1;
        else
            RoomNumber = 2;

        return RoomNumber;
    }


    protected bool pathComplete()
    {
        if (Vector3.Distance(agent.destination, agent.transform.position) <= agent.stoppingDistance)
        {
            if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
            {
                return true;
            }
        }

        return false;
    }


    IEnumerator WaitForAnimations()
    {
        yield return new WaitForSeconds(10f);
        // Cache agent component and destination
        agent = GetComponent<NavMeshAgent>();
        RoomNumber = GetRoomNumber();
        agent.destination = WalkTo();
    }
}
