using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLight : MonoBehaviour
{
    public bool lightEnter;

    // Start is called before the first frame update
    void Start()
    {
        lightEnter = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            lightEnter = true;
            //Debug.Log("É_ÉÅÅ[ÉW");
            LifeScript life = other.GetComponent<LifeScript>();
            if (life != null)
            {
                life.TakeDamage(1);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            lightEnter = false;
        }
    }
}
