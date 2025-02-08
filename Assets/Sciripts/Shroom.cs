using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shroom : MonoBehaviour
{
    // Start is called before the first frame update
    public delegate void DeathEvent();
    public event DeathEvent OnDeath;


    private Animator animator;
    
    public void Die(){
        OnDeath?.Invoke();
        Destroy(gameObject);
    }

    public void BackToIdle(){
        animator = gameObject.GetComponent<Animator>();
        animator.SetBool("takehit",false);
    }
}