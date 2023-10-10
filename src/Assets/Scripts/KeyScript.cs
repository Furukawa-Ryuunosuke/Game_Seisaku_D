using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    public bool KeyEnter;

    public float Rotation = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        KeyEnter = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, Rotation, 0));
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            KeyEnter = true; Debug.Log("get Key");
            Destroy(gameObject);
        }
    }
}
