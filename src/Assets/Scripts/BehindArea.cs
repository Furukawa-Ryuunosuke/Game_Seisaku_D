using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehindArea : MonoBehaviour
{
    public bool behindEnter;
    // Start is called before the first frame update
    void Start()
    {
        behindEnter = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            behindEnter = true; Debug.Log(behindEnter);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            behindEnter = false;
        }
    }
}
