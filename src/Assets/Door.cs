using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject associatedKey; // �֘A���錮�̃Q�[���I�u�W�F�N�g���A�T�C��

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Key keyScript = associatedKey.GetComponent<Key>();
            if (keyScript != null && keyScript.isKeyUsed)
            {
                // �v���C���[���h�A�ɐG��A�������g�p�ς݂ł���ꍇ
                Destroy(gameObject); // �h�A������
            }
        }
    }
}
