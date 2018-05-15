using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {

    NavMeshAgent agent;
    GameObject player;
    public int health = 100;

    Animator anim;
    float attackRate = 1f;
    float nextAttackTime = 1f;


    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        health = 100;

        anim = GetComponent<Animator>();

    }
	
	void Update ()
    {
        if(player==null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        //MoveToPlayer();
        Attack();
        Death();
	}


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            player = other.gameObject;
            MoveToPlayer();
        }
    }

    void MoveToPlayer()
    {
        agent.SetDestination(player.transform.position);
        if (agent.steeringTarget != null)
        {
            anim.SetBool("IsWalk", true);
            anim.SetBool("IsRun", true);
        }
    }
    void Attack()
    {
        if (Vector3.Distance(gameObject.transform.position, player.transform.position) < 1f && Time.time > nextAttackTime)
        {
            anim.SetTrigger("Attack_1");
            nextAttackTime = Time.time + attackRate;
            player.GetComponent<PlayerController>().Damaged(10);
        }
    }
    void Death()
    {
        if (health <= 0)
        {
            anim.SetTrigger("Dead");
            gameObject.GetComponent<EnemyController>().enabled = false;
            agent.enabled = false;
            Destroy(gameObject, 10f);
        }
    }
}
