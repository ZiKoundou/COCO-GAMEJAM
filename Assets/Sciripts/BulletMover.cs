using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour
{
    GameObject player;
    public float speed = 10f;
    Vector3 direction;
    public float bulletLifetime = 2f;
    private Healthbar healthbar;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        direction = (player.transform.position - transform.position).normalized; 
        Destroy(gameObject, bulletLifetime);
         
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction*speed*Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D other){
        healthbar = other.gameObject.GetComponentInChildren<Healthbar>();
        if(other.gameObject.tag == "Player" && healthbar != null){
            healthbar.TakeDamage(2);
        } 
        // agent.isStopped = false;
        // agent.SetDestination(player.position);
    }
}
