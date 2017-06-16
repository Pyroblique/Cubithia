using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolPoints : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float movementSpeed = 10f;
    public int lives = 3;
    public GameObject explosionPrefab;

    private int currentPoint = 0;
    private Rigidbody rb;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if(lives == 0)
        {
            Destroy(gameObject);
        }
        if(lives <= 0)
        {
            Destroy(gameObject);
        }
    }

    void Movement()
    {
        // Check if we have reached our Waypoint
        if (transform.position == patrolPoints[currentPoint].position)
        {
            // Increment currentPoint by 1
            currentPoint++;
        }

        // Check if current point is outside range of array
        if (currentPoint >= patrolPoints.Length)
        {
            // Reset currentPoint to 0
            currentPoint = 0;
        }


        Vector3 movePos = Vector3.MoveTowards(transform.position, patrolPoints[currentPoint].position, movementSpeed * Time.deltaTime);
        transform.position = movePos;
    }
    void OnTriggerEnter (Collider other)
    {
        // When hit by bullet
        if (other.GetComponent<Bullet>() != null)
        {
            GameObject clone = Instantiate(explosionPrefab);
            clone.transform.position = transform.position;
            ParticleSystem explosion = clone.GetComponent<ParticleSystem>();
            explosion.Play();
            lives -= 1;
        }
        // When entering the castle
        if (other.GetComponent<Castle>() != null)
        {
            Destroy(gameObject);
        }
    }
}
