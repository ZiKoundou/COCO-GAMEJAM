using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class ShroomMovement : MonoBehaviour
{
    NavMeshAgent agent;
    GameObject player;
    bool CanShoot = false;
    private Vector2 playerDirection;
    private GameObject healthBar;

    ShroomShoot shroomShoot;
    
    
    // Start is called before the first frame update
    void Start()
    {
        shroomShoot = GetComponent<ShroomShoot>();
        player = GameObject.FindGameObjectWithTag("Player");
        if(player == null){
            Debug.Log("player not found :(");
        }
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = Vector3.Distance(gameObject.transform.position, player.transform.position);
        if(agent.stoppingDistance >= distanceFromPlayer){
            shroomShoot.Shoot();
        }
        if (player != null){
            agent.SetDestination(player.transform.position);
        } 

        FacePlayer();
    }

    public void FacePlayer(){
        playerDirection = player.transform.position-gameObject.transform.position;
        if(playerDirection.x <0){
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
            healthBar.transform.localScale = new Vector3(-1, 1, 1);
        }else{
            gameObject.transform.localScale = new Vector3(1, 1, 1);
            healthBar.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}

