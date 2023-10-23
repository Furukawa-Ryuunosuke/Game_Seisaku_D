using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BackstabScript : MonoBehaviour
{
    public GameObject textObject;
    // Start is called before the first frame update
    void Start()
    {
        textObject.SetActive(false);
    }

        // Update is called once per frame
        void Update()
    {

    }
    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
        
            textObject.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
     
        textObject.SetActive(false);
    }
}