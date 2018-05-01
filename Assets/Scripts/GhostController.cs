using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostController : MonoBehaviour {

    NavMeshAgent agent;
    GameObject player;
    

	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
	}
	
	void Update ()
    {
        agent.SetDestination(player.transform.position);
	}
}
