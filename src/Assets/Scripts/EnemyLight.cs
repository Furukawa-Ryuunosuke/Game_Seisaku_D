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
            //Debug.Log("�_���[�W");
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
