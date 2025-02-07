using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;

public class playermovement : MonoBehaviour
{
    public float speed = 4f;
    public float dashSpeed = 10f;
    public float dashTime = 0.2f;
    public float dashCooldown = 1f;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator animator;
    private bool canDash = true;
    private bool isDashing = false;
    public bool still;

    PoisonSpawn poisonSpawn;
    // Start is called before the first frame update

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        poisonSpawn = GetComponentInChildren<PoisonSpawn>();
    }

    private void OnMovement(InputValue value){
        movement = value.Get<Vector2>();
        animator.SetFloat("X", movement.x);
        animator.SetFloat("Y", movement.y);
    }
    // Update is called once per frame
    private void OnDash(){
        if(canDash && movement != Vector2.zero){
            StartCoroutine(Dash());
        }
    }

    private IEnumerator Dash(){
        canDash = false;
        isDashing = true;
        float oldPoisonTimer = poisonSpawn.poisonTimer;
        float startTime = Time.time;
        while(Time.time<startTime+dashTime){
            rb.MovePosition(rb.position + movement.normalized * dashSpeed *Time.fixedDeltaTime);
            
            poisonSpawn.poisonTimer = 0.05f;
            yield return null; //wait
        }
        poisonSpawn.poisonTimer = oldPoisonTimer;
        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

    void Update()
    {
        if(!isDashing){
            Move();
        }
   
    }

    void Move(){
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
