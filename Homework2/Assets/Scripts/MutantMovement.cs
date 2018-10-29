using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutantMovement : MonoBehaviour {

	public Transform player;
	static Animator anim;
    public int RoomNumber;

    // Use this for initialization
    void Start () {
		anim = GetComponent<Animator>();
	    player = GameObject.Find("Player").transform;
	}
	
	void Update ()
	{
	    _nav.SetDestination(_player.position);
	}	


   
}
