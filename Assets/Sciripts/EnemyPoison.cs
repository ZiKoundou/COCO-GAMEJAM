using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoison : MonoBehaviour
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
        Healthbar healthbar = other.GetComponentInChildren<Healthbar>();
        if (healthbar != null && other.CompareTag("Player")) // Ensure the enemy has a health system
        {
            StartCoroutine(DamageOverTime(healthbar));
        }
        else if(healthbar == null)
        {
            Debug.LogWarning(other.name + " does not have a HealthSystem!");
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if (other.CompareTag("Player"))
        {
            StopAllCoroutines(); // Stop applying damage when the enemy leaves
        }
    }
    
    private System.Collections.IEnumerator DamageOverTime(Healthbar Health)
    {
        while (Health != null) // Keep damaging while the Player is in the puddle
        {
            Health.TakeDamage(damagePerSecond * tickRate);
            yield return new WaitForSeconds(tickRate);
        }
    }

}