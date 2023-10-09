using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public GameObject checkObject; // BoxCollider������GameObject
    public GameObject triangleObject; // MeshRenderer�𐧌䂷��GameObject

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("1");
            // Player��CheckObject��BoxCollider�ɓ������Ƃ��ATriangleObject��MeshRenderer��L���ɂ���
            if (triangleObject != null && checkObject != null)
            {
                Debug.Log("2");
                BoxCollider boxCollider = checkObject.GetComponent<BoxCollider>();
                if (boxCollider != null && boxCollider.bounds.Contains(transform.position))
                {
                    Debug.Log("3");
                    MeshRenderer meshRenderer = triangleObject.GetComponent<MeshRenderer>();
                    if (meshRenderer != null)
                    {
                        Debug.Log("4");
                        meshRenderer.enabled = true;
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("5");
            // Player��BoxCollider����o���Ƃ��ATriangleObject��MeshRenderer�𖳌��ɂ���
            if (triangleObject != null)
            {
                Debug.Log("6");
                MeshRenderer meshRenderer = triangleObject.GetComponent<MeshRenderer>();
                if (meshRenderer != null)
                {
                    Debug.Log("7");
                    meshRenderer.enabled = false;
                }
            }
        }
    }
}
