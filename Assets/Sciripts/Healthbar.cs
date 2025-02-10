using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.WSA;

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

    SpriteRenderer sprite;

    public float flashDuration, flashCount;

    SoundEffectManager soundEffectManager;
    
    public float GetHealth(){
        return Health;
    }
    
    // Start is called before the first frame update
    public void UpdateHealthBar(float currentValue, float maxValue){
        
        //Debug.Log("Current Health: " + currentValue + ", Max Health: " + maxValue);
        if(gameObject.tag == "Enemy"){
            slider.gameObject.SetActive(currentValue < maxValue);
        }
        
        
        slider.maxValue = maxValue;
        slider.value = currentValue;
        
        //slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(Low,High,slider.normalizedValue);
        //Debug.Log("Slider Normalized Value: " + slider.normalizedValue);

    }
    
    public void Start(){
        enemy = GetComponent<Enemy>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        soundEffectManager = GameObject.FindAnyObjectByType<SoundEffectManager>();
        
    }
    void Update(){
        //slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + Offset);
        UpdateHealthBar(Health,maxHealth);
        
    }

    public void TakeDamage(float damage){
        Health -= damage;
        soundEffectManager.PlayHitSound();
        StartCoroutine(FlashRedOnDamage());
        if(Health <= 0 && gameObject.tag == "Enemy"){
            
            enemy.Die();
        }
    }

    private IEnumerator FlashRedOnDamage()
    {
        for (int i = 0; i < flashCount; i++)
        {
            Color originalColor = sprite.color;
            // Set the color to red
            sprite.color = Color.red;

            // Wait for a short duration (flashDuration)
            yield return new WaitForSeconds(flashDuration);

            // Reset the color to the original color
            sprite.color = Color.white;

            // Wait again before flashing red again
            yield return new WaitForSeconds(flashDuration);
        }
    }
    
    // Update is called once per frame
    
}
