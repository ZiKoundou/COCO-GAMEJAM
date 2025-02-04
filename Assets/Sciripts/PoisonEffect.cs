using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

public class PoisonEffect : MonoBehaviour
{
    [SerializeField]
    private float lifetime;
    [SerializeField]
    private Animator animator;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
        Destroy(gameObject, lifetime);
    }
    
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer == 5){
            animator.SetBool("decay", true);
        }
    }
}
