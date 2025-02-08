using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private NavMeshAgent agent;
    private GameObject player;
    private Vector2 playerDirection;
    private GameObject healthBar;
    private Healthbar health;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        player = GameObject.FindGameObjectWithTag("Player");
        if(player == null){
            Debug.Log("player not found :(");
        }
        healthBar = transform.Find("HealthBar").gameObject;
        health = healthBar.GetComponentInChildren<Healthbar>();
    }

    // Update is called once per frame
    void Update()
    {
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

    private void OnTriggerEnter2D(Collider2D other){
        health = other.gameObject.GetComponentInChildren<Healthbar>();
        if(other.gameObject.tag == "Player" && health != null){
        health.TakeDamage(1);
    } 
    // agent.isStopped = false;
    // agent.SetDestination(player.position);
    }

}
