using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutantMovement : MonoBehaviour {

<<<<<<< HEAD
    public Transform player;
    static Animator anim;
    private MutantShoot _MS;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        _MS = GetComponent<MutantShoot>();
=======
	public Transform player;
	static Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
>>>>>>> 7f63d157e92ad5516bdcf2198ab77b62769c38de
	}
	
	// Update is called once per frame
	void Update () {
<<<<<<< HEAD
        
        Vector3 direction = player.position - this.transform.position;
        float angle = Vector3.Angle(direction, this.transform.forward);
        if(Vector3.Distance(player.position, this.transform.position)< 10 && angle < 50){
            direction.y = 0;
=======
		MutantShoot _MS = GetComponent<MutantShoot>();
		Vector3 direction = player.position - this.transform.position;
		float angle = Vector3.Angle(direction, this.transform.forward);
		if(Vector3.Distance(player.position, this.transform.position)< 10 && angle < 30){
			direction.y = 0;
>>>>>>> 7f63d157e92ad5516bdcf2198ab77b62769c38de

			this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

<<<<<<< HEAD
            anim.SetBool("isIdle", false);
            if(direction.magnitude > 5){
                this.transform.Translate(0, 0, 0.05f);
                anim.SetBool("isWalking", true);
                anim.SetBool("isAttacking", false);
                anim.SetBool("isRunning", false);
                anim.SetBool("isJumping", false);
                anim.SetBool("isIdle", false);
                if(direction.magnitude > 6.5){
                    this.transform.Translate(0, 0, 0.07f);
                    anim.SetBool("isRunning", true);
                    anim.SetBool("isWalking", false);
                    anim.SetBool("isAttacking", false);
                    anim.SetBool("isJumping", false);
                    anim.SetBool("isIdle", false);
                }
            }else{
                anim.SetBool("isRunning", false);
                anim.SetBool("isWalking", false);
                anim.SetBool("isAttacking", true);
                anim.SetBool("isJumping", false);
                anim.SetBool("isIdle", false);
            }
        }else{
            anim.SetBool("isIdle", true);
            anim.SetBool("isWalking", false);
            anim.SetBool("isAttacking", false);
            anim.SetBool("isRunning", false);
            anim.SetBool("isJumping", false);
        }
=======
			anim.SetBool("isIdle", false);
			if(direction.magnitude > 5){
				this.transform.Translate(0, 0, 0.05f);
				anim.SetBool("isWalking", true);
				anim.SetBool("isAttacking", false);
				anim.SetBool("isRunning", false);
				anim.SetBool("isJumping", false);
				anim.SetBool("isIdle", false);
				if(direction.magnitude > 6){
					this.transform.Translate(0, 0, 0.07f);
					anim.SetBool("isRunning", true);
					anim.SetBool("isWalking", false);
					anim.SetBool("isAttacking", false);
					anim.SetBool("isJumping", false);
					anim.SetBool("isIdle", false);
					if(direction.magnitude > 8){
						this.transform.Translate(0,0,0.01f);
						anim.SetBool("isRunning", false);
						anim.SetBool("isWalking", false);
						anim.SetBool("isAttacking", false);
						anim.SetBool("isJumping", true);
						anim.SetBool("isIdle", false);
					}
				}
			}else{
				anim.SetBool("isAttacking", true);
				this.transform.Translate(0,0,0.01f);
				_MS.enabled = true;
				anim.SetBool("isWalking", false);
				anim.SetBool("isRunning", false);
				anim.SetBool("isJumping", false);
				anim.SetBool("isIdle", false);
			}
		}else{
			anim.SetBool("isIdle", true);
			anim.SetBool("isWalking", false);
			anim.SetBool("isAttacking", false);
			anim.SetBool("isRunning", false);
			anim.SetBool("isJumping", false);
		}
>>>>>>> 600db938947957cda41c4ae4d5a54b1d1612926b
	}

    private IEnumerator Jump()
    {
            anim.SetBool("isJumping", true);
            yield return new WaitForSeconds(5);
    }
}