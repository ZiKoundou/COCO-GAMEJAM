using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;

public class PoisonSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject poison;
    [SerializeField]
    private float poisonTimer, currentPoisonTimer;
    
    
    // Start is called before the first frame update
    void Awake()
    {
        poisonTimer = 0.25f;
    }

    // Update is called once per frame
    void Update()
    {
        currentPoisonTimer += Time.deltaTime;
        if(currentPoisonTimer >= poisonTimer){
            Instantiate(poison, transform.position, Quaternion.identity);
            currentPoisonTimer = 0;
        }
    }
}
