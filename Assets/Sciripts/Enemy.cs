using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public delegate void DeathEvent();
    public event DeathEvent OnDeath;
    private Healthbar healthbar;

    private Animator animator;
    
    public void Die(){
        OnDeath?.Invoke();
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other){
        healthbar = other.gameObject.GetComponentInChildren<Healthbar>();
        if(other.gameObject.tag == "Player" && healthbar != null){
            healthbar.TakeDamage(1);
        } 
        // agent.isStopped = false;
        // agent.SetDestination(player.position);
    }

    public void BackToIdle(){
        animator = gameObject.GetComponent<Animator>();
        animator.SetBool("takehit",false);
    }
}
