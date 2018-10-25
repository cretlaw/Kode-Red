﻿using System.Collections;
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
	
	// Update is called once per frame
	void Update () {
		
		Vector3 direction = player.position - this.transform.position;
		float angle = Vector3.Angle(direction, this.transform.forward);
		if(Vector3.Distance(player.position, this.transform.position)< 10 && angle < 50){
			direction.y = 0;

			this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);


			anim.SetBool("isIdle", false);
			if(direction.magnitude > 5){
				this.transform.Translate(0, 0, 0.05f);
				anim.SetBool("isWalking", true);
				anim.SetBool("isAttacking", false);
				anim.SetBool("isRunning", false);
				anim.SetBool("isIdle", false);
				
				if(direction.magnitude > 6.5){
					this.transform.Translate(0, 0, 0.07f);
					anim.SetBool("isRunning", true);
					anim.SetBool("isWalking", false);
					anim.SetBool("isAttacking", false);
					anim.SetBool("isIdle", false);
				}
			}else{
				anim.SetBool("isAttacking", true);
				anim.SetBool("isWalking", false);
				anim.SetBool("isRunning", false);
				anim.SetBool("isIdle", false);
			}
		}else{
			anim.SetBool("isIdle", true);
			anim.SetBool("isWalking", false);
			anim.SetBool("isAttacking", false);
			anim.SetBool("isRunning", false);
		}

	    
	}


   
}
