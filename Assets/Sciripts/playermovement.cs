using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;

public class playermovement : MonoBehaviour
{
    private int speed = 4;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator animator;
    public bool still;
    // Start is called before the first frame update

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnMovement(InputValue value){
        movement = value.Get<Vector2>();
        animator.SetFloat("X", movement.x);
        animator.SetFloat("Y", movement.y);
    }
    // Update is called once per frame


    void Update()
    {
        Move();
        

        
        
    }

    void Move(){
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
