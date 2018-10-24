using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Mutant2Controller : MonoBehaviour {

    [SerializeField] float _alertDistance = 20f;
    private float _distance;
    


    public void AlertOthers(GameObject callingMutant)
    {
        //find all the mutant2 clones or otherwise and alert all others within a 20 feet radius that player has been spotted
        GameObject[] mutants2 = GameObject.FindGameObjectsWithTag("mutant2");

        if (mutants2 != null && mutants2.Length != 0)
        {
            foreach (var m2 in mutants2)
            {
                _distance = Vector3.Distance(m2.gameObject.transform.position, callingMutant.transform.position);
                if (_distance < _alertDistance)
                    m2.GetComponent<StaticShootingEnemy>().IsAlert = true;
            }


        }

        StartCoroutine(TimerForAlertness(mutants2));


    }

    IEnumerator TimerForAlertness(GameObject [] mutants2)
    {
        yield return new WaitForSeconds(10);

        foreach (var m2 in mutants2)
        {
            //_distance = Vector3.Distance(this.transform.position, _player.transform.position);
                m2.GetComponent<StaticShootingEnemy>().IsAlert = false;
        }
    }
   
   

    //TODO: Do something similar to mutant and bystander
}
