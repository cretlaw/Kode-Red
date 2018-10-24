using UnityEngine;
using System.Collections;


public class ReactiveTarget : MonoBehaviour
{
    private Animator _anim;
    


    void Start()
    {
        _anim = GetComponent<Animator>();
       
    }
    public void ReactToHit()
    {
        //TODO: I added box collider on enemis so that they may react to being hit by player.
        //TODO: We may need to change this in the feature to work with navmesh agent.
        StaticShootingEnemy staticShootingEnemy = GetComponent<StaticShootingEnemy>();
        if ( staticShootingEnemy!= null)
            staticShootingEnemy.SetAlive(false);

        MutantShoot ms = GetComponent<MutantShoot>();
        if(ms != null)
            ms.SetAlive(false);
        

        BystanderMovement byStander = GetComponent<BystanderMovement>();
        if(byStander != null)
            byStander.SetAlive(false);

        StartCoroutine(Die());
       
    }

    private IEnumerator Die()
    {
        if (this.gameObject.tag == "mutant2")
            _anim.SetBool("dieM2", true);

        else if (this.gameObject.tag == "mutant")
            _anim.SetBool("isDying", true);

        else
            _anim.SetBool("byStanderDead", true);
            
        
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }
}