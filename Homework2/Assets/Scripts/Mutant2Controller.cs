using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutant2Controller : MonoBehaviour {

    [SerializeField] float _alertDistance = 20f;
    private float _distance;
    private Transform _player;

    // Use this for initialization
    void Start () {
        _player = GameObject.Find("Player").transform;
    }
	

    public void AlertOthers()
    {
        //find all the mutant2 clones or otherwise and alert all others within a 20 feet radius that player has been spotted
        GameObject[] mutants2 = GameObject.FindGameObjectsWithTag("mutant2");

        if (mutants2 != null || mutants2.Length != 0)
        {
            foreach (var m2 in mutants2)
            {
                _distance = Vector3.Distance(this.transform.position, _player.transform.position);
                if (_distance < _alertDistance)
                    m2.GetComponent<StaticShootingEnemy>().IsAlert = true;
            }
        }

        //TODO: Do something similar to mutant2 and bystander

    }
}
