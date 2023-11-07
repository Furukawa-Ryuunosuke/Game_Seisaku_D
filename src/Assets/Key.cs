using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject associatedDoor; // �h�A�̃Q�[���I�u�W�F�N�g���A�T�C��
    public bool isKeyUsed = false; // �����g�p���ꂽ���Ƃ��L�^����ϐ�

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isKeyUsed)
        {
            // �v���C���[�����ɐG�ꂽ�Ƃ�
            other.gameObject.SetActive(false);
            if (associatedDoor != null)
            {
                // �v���C���[�����ɐG��A�������g�p����Ă��Ȃ��Ƃ�
                isKeyUsed = true; // �����g�p�ς݂Ƀ}�[�N
                associatedDoor.SetActive(false); // �֘A����h�A������
            }
        }
    }
}
