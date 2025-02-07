using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Slider slider;
    // public Color Low;
    // public Color High;
    //Vector3 Offset;

    [SerializeField]
    private float Health,maxHealth;
    private Enemy enemy;
    Animator animator;
    
    // Start is called before the first frame update
    public void UpdateHealthBar(float currentValue, float maxValue){
        
        //Debug.Log("Current Health: " + currentValue + ", Max Health: " + maxValue);
        
        //slider.gameObject.SetActive(currentValue < maxValue);
        slider.maxValue = maxValue;
        slider.value = currentValue;
        
        //slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(Low,High,slider.normalizedValue);
        //Debug.Log("Slider Normalized Value: " + slider.normalizedValue);

    }
    
    public void Start(){
        enemy = GetComponentInParent<Enemy>();
        animator = GetComponentInParent<Animator>();
    }
    void Update(){
        //slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + Offset);
        UpdateHealthBar(Health,maxHealth);
        
    }

    public void TakeDamage(float damage){
        Health -= damage;
        //animator.SetBool("takehit",true);
        if(Health == 0){
            enemy.Die();
        }
    }
    
    // Update is called once per frame
    
}
