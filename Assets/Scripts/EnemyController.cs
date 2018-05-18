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

    AudioManager audioManager;

    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        health = 100;

        anim = GetComponent<Animator>();

        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();

    }
	
	void Update ()
    {
        if(player==null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        if(agent.remainingDistance<0.1f)
        {
            anim.SetBool("IsWalk", false);
            anim.SetBool("IsRun", false);
        }
        MoveToPlayer();
        Attack();
        Death();
	}
    void MoveToPlayer()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance <= 4f)
        {
            agent.SetDestination(player.transform.position);
            anim.SetBool("IsWalk", true);
            anim.SetBool("IsRun", true);
        }
    }
    void Attack()
    {
        if (Vector3.Distance(gameObject.transform.position, player.transform.position) < 1.5f && Time.time > nextAttackTime)
        {
            anim.SetTrigger("Attack_1");
            audioManager.Play("EnemyAttack");
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
            gameObject.GetComponent<CapsuleCollider>().enabled = false;
            Destroy(gameObject, 10f);
        }
    }
}
