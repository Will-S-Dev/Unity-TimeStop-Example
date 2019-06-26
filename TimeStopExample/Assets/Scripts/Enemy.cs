using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    private GameObject player;
    private Animator anim;
    private TimeManager timemanager;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        timemanager = GameObject.FindGameObjectWithTag("TimeManager").GetComponent<TimeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!timemanager.TimeIsStopped)
        {
            agent.SetDestination(player.transform.position);  //go to player

            if (agent.remainingDistance <= agent.stoppingDistance )
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation( player.transform.position- transform.position),10f*Time.deltaTime); //Look at player
                anim.Play("Attack");
            }
        }
        if(timemanager.TimeIsStopped)
        {
        agent.velocity = Vector3.zero; // stop moving
        anim.speed = 0f;  //stop the animation
        }
        else
        {
        anim.speed = 1f;
        }
        
    }
}
