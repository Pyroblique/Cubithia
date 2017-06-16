using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, 0.8f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward / 2);


        //if (transform.position.y != 0.2770838f)
        {
            //Destroy(gameObject, 0.01f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EnemyPatrolPoints>() != null)
        {
            // Destroy object
            Destroy(gameObject);

        }
    }
}
