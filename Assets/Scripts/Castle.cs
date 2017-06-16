using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour
{
    public GameObject explosionPrefab;

    void OnTriggerEnter(Collider other)
    {
        // Particle explosion 
        GameObject clone = Instantiate(explosionPrefab);
        clone.transform.position = transform.position;
        ParticleSystem explosion = clone.GetComponent<ParticleSystem>();
        explosion.Play();

        Scoreboard.lives -=1;
    }
}
