using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostController : MonoBehaviour {

    NavMeshAgent agent;
    GameObject player;
    public int health = 100;
    

	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        health = 100;

    }
	
	void Update ()
    {
        agent.SetDestination(player.transform.position);
        if (health <= 0)
        {
            Destroy(gameObject);
        }
	}
}
