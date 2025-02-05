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
    //private float poisonDamage;
    [SerializeField]
    private float timer,damagePerSecond,tickRate;

    // Start is called before the first frame update
    void Start()
    {
        
        Destroy(gameObject, lifetime);
    }
    
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 5){
            animator.SetBool("decay", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        Healthbar healthbar = other.GetComponent<Healthbar>();
        if (healthbar != null) // Ensure the enemy has a health system
        {
            StartCoroutine(DamageOverTime(healthbar));
        }
        else
        {
            Debug.LogWarning(other.name + " does not have a HealthSystem!");
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if (other.CompareTag("Enemy"))
        {
            StopAllCoroutines(); // Stop applying damage when the enemy leaves
        }
    }
    
    private System.Collections.IEnumerator DamageOverTime(Healthbar enemyHealth)
    {
        while (enemyHealth != null) // Keep damaging while the enemy is in the puddle
        {
            enemyHealth.TakeDamage(damagePerSecond * tickRate);
            yield return new WaitForSeconds(tickRate);
        }
    }

}
