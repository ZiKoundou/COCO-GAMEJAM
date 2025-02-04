using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CameraFollow : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 0f, -10f);
    //offset for camera
    private float smoothTime = 0.25f;
    //time to smooth camera
    private Vector3 velocity = Vector3.zero;

    [SerializeField]
    private GameObject target;
    
    // Update is called once per frame
    void Update(){
        Vector3 targetPosition = target.transform.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition,ref velocity,smoothTime);
    }
}
