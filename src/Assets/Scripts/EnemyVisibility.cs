using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVisibility : MonoBehaviour
{
    public bool visbilityEnter;

    // Start is called before the first frame update
    void Start()
    {
        visbilityEnter = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            visbilityEnter = true; Debug.Log(visbilityEnter);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            visbilityEnter = false;
        }
    }
}
