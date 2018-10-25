using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{

    
    public float speed = 1.5f;

    public float obstacleRange = 5.0f;
    private Animator _anim;

    void Start()
    {
        _anim = GetComponent<Animator>();
        if (this.gameObject.tag == "mutant")
            _anim.SetBool("isWalking", true);
        
        else
            _anim.SetBool("byStanderRunning", true);
        
    }



    // Update is called once per frame
    void Update()
    {


        //moving forward
        transform.Translate(0, 0, speed * Time.deltaTime);



        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.SphereCast(ray, 0.75f, out hit))
        {


            if (hit.distance < obstacleRange)
            {
                float angle = Random.Range(-110, 110);
                transform.Rotate(0, angle, 0);
            }
        }

    }




}
