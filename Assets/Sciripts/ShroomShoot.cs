using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShroomShoot : MonoBehaviour
{
    // Start is called before the first frame updatepublic GameObject shot;        // The prefab of the shot
    public float shootForce = 10f; // How fast the shot travels
    public Transform shootPoint;   // Where the shot comes from (e.g., front of the mushroom)

    public float shootInterval = 2f; // Time between shots
    private float nextShootTime = 0f;
    public GameObject shot;
    private Transform player;

    void Start()
    {
        // Find the player by tag (assuming the player has the "Player" tag)
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // If shootPoint isn't assigned, use the enemy's position
        if (shootPoint == null)
        {
            shootPoint = transform;
        }
    }

    public void Shoot()
    {
        // Instantiate the shot at the shootPoint's position and rotation
        if (Time.time >= nextShootTime)
        {
            GameObject newShot = Instantiate(shot, shootPoint.position, shootPoint.rotation);
            nextShootTime = Time.time + shootInterval;  // Set the time for the next shot
        }
    }
}
