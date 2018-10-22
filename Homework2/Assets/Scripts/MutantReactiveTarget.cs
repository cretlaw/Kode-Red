using UnityEngine;
using System.Collections;


public class MutantReactiveTarget : MonoBehaviour
{
    private Animator _anim;

    void Start()
    {
        _anim = GetComponent<Animator>();

    }
    public void ReactToHit()
    {
        MutantShoot ms = GetComponent<MutantShoot>();
        if ( ms!= null)
            ms.SetAlive(false);
        StartCoroutine(Die());

    }

    private IEnumerator Die()
    {
        if (this.gameObject.tag == "mutant")
        {
            _anim.SetBool("isDying", true);

            yield return new WaitForSeconds(5);

            Destroy(this.gameObject);
        }

    }
}
