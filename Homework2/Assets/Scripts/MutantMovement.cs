using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutantMovement : MonoBehaviour {

    public Transform player;
    static Animator anim;
    private MutantShoot _MS;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        _MS = GetComponent<MutantShoot>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 direction = player.position - this.transform.position;
        float angle = Vector3.Angle(direction, this.transform.forward);
        if(Vector3.Distance(player.position, this.transform.position)< 10 && angle < 30){
            direction.y = 0;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

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
                        anim.SetBool("isRunning", false);
                        anim.SetBool("isWalking", false);
                        anim.SetBool("isAttacking", false);
                        anim.SetBool("isJumping", true);
                        anim.SetBool("isIdle", false);
                    }
                }
            }else{
                anim.SetBool("isAttacking", true);
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
	}

    private IEnumerator Run()
    {
        anim.SetBool("isRunning", true);
        yield return new WaitForSeconds(10);
    }

    private IEnumerator Jump()
    {
        anim.SetBool("isJumping", true);
        yield return new WaitForSeconds(10);
    }

    private IEnumerator Walk()
    {
        anim.SetBool("isWalking", true);
        yield return new WaitForSeconds(10);
    }

    private IEnumerator Attack()
    {
        anim.SetBool("isAttacking", true);
        yield return new WaitForSeconds(10);
    }

    private IEnumerator Idle(){
        anim.SetBool("isIdle", true);
        yield return new WaitForSeconds(10);
    }

}
