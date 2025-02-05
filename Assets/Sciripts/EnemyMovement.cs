using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private NavMeshAgent agent;
    private GameObject player;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        player = GameObject.FindGameObjectWithTag("Player");
        if(player == null){
            Debug.Log("player not found :(");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null){
            agent.SetDestination(player.transform.position);
        }
    }
}
