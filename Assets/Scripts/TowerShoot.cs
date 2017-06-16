using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShoot : MonoBehaviour
{
    public Bullet bulletPrefab;
    public Arrow arrowPrefab;
    public Transform shootPoint;
    bool spawning = true;
    Vector3 returnPos = Vector3.zero;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(Bullets());
    }

    void LateUpdate()
    {
        if (gameObject.transform.position.y != -0.5f)
        {
            StopCoroutine(Bullets());
        }
        else
        {

        }

        // To make sure players cannot place the tower(s) on the enemy pathway
        if (!Input.GetMouseButton(0))
        {
            if (gameObject.transform.position.y >= 5f && gameObject.transform.position.y <= 20f)
            {
                gameObject.transform.position = returnPos;
            }
        }

        if (gameObject.transform.position.y <= 2f)
        {
            returnPos = gameObject.transform.position;
        }
    }

    IEnumerator Bullets()
    {
        // To repeatedly spawn loads of obstacles
        while (spawning)
        {
            Bullet clone = (Bullet)Instantiate(bulletPrefab, transform.position, transform.rotation);
            clone.transform.position = shootPoint.transform.position;
            yield return new WaitForSeconds(0.12f);
        }
        while (spawning)
        {
            Arrow clone = (Arrow)Instantiate(arrowPrefab, transform.position, transform.rotation);
            clone.transform.position = shootPoint.transform.position;
            yield return new WaitForSeconds(0.12f);
        }
    }
}    
