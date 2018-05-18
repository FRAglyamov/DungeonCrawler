using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RangeEnemyController : MonoBehaviour
{

    NavMeshAgent agent;
    GameObject player;
    public GameObject rangeEnemyAttack;
    public int health = 50;

    float attackRate = 1f;
    float nextAttackTime = 1f;
    Ray ray;
    RaycastHit hit;
    float distance;
    public LayerMask playerMask;

    AudioManager audioManager;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        health = 50;
        ray = new Ray(transform.position + transform.forward * 1f, transform.forward * 5f);

        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();

    }

    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        distance = Vector3.Distance(player.transform.position, transform.position);
        ray = new Ray(transform.position + transform.forward * 1f, transform.forward * 5f);
        Physics.Raycast(ray, out hit, 5f, playerMask);
        Debug.DrawRay(transform.position + transform.forward * 1f, transform.forward * 5f, Color.red);

        MoveToPlayer();
        LookAtPlayer();
        Attack();
        Death();
    }

    void MoveToPlayer()
    {
        if (distance <= 4f)
        {
            agent.SetDestination(player.transform.position);
        }
    }

    void LookAtPlayer()
    {
        if (distance <= 5f)
        {
            Quaternion rotation = Quaternion.LookRotation(player.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime);
        }
    }
    void Attack()
    {
        if (hit.collider!=null && Time.time > nextAttackTime)
        {
            nextAttackTime = Time.time + attackRate;
            audioManager.Play("RangeEnemyAttack");
            Instantiate(rangeEnemyAttack, transform.position + transform.forward*1f, transform.rotation);
        }
    }
    void Death()
    {
        if (health <= 0)
        {
            transform.Translate(0f, -0.5f, 0f);
            gameObject.GetComponent<RangeEnemyController>().enabled = false;
            agent.enabled = false;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            Destroy(gameObject, 10f);
        }
    }
}
