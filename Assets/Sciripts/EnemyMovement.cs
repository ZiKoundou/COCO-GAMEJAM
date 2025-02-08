using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
    
    bool canTakeDamage = true;
    [SerializeField]
    private float damageCooldown = 0.5f; 
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
        transform.rotation = Quaternion.identity;
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
            StartCoroutine(DamageCooldown());
        } 
    }

    IEnumerator DamageCooldown()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(damageCooldown);
        canTakeDamage = true;
    }
    // private void OnCollisionEnter2D(Collision2D other){
    //     health = other.gameObject.GetComponentInChildren<Healthbar>();
    //     if(other.gameObject.tag == "Player" && health != null){
    //         health.TakeDamage(1);
    //         StartCoroutine(DamageCooldown());
    //     }
    //     agent.SetDestination(player.transform.position);
    // }


    // agent.isStopped = false;
    // agent.SetDestination(player.position);
    

}
