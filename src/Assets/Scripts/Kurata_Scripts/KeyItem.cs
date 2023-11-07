using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public string keyID; // ���j�[�N�Ȍ���ID
    public GameObject relatedLock; // �֘A�t����ꂽ�싞��

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // �v���C���[�������E�����Ƃ��̏���
            DoorController door = relatedLock.GetComponent<DoorController>();
            if (door != null)
            {
                door.UnlockLock();
            }

            // �v���C���[�������E������A���A�C�e�����\���ɂ��邩�j������Ȃǂ̏�����ǉ����邱�Ƃ��ł��܂��B
            gameObject.SetActive(false);
        }
    }
}
