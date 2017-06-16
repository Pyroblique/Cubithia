using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{

    public EnemyPatrolPoints enemyPrefab;
    bool spawning = true;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(Enemies());
    }

    IEnumerator Enemies()
    {
        // To repeatedly spawn loads of obstacles
        while (spawning)
        {
            EnemyPatrolPoints clone = (EnemyPatrolPoints)Instantiate(enemyPrefab, new Vector3(6.7f, 0f, 26f), transform.rotation);
            yield return new WaitForSeconds(1f);
        }
    }
}
