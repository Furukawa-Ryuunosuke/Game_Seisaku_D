using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public int AllkeyCount = 0;
    private int keyCount = 0;
    public GameObject[] hasp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(keyCount);
        Debug.Log(AllkeyCount);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            Destroy(other.gameObject);
            AllkeyCount = AllkeyCount - 1;
        }

        // �ǉ�
        // �|�C���g�ikeyCount�̏����ǉ��E�E�E�����������Ă��Ȃ��Ɣ��͊J���Ȃ��j
        if (other.CompareTag("Door") && keyCount > 0)
        {
            Destroy(hasp[keyCount-1]);
            // �|�C���g
            // keyCount���P���炷
            keyCount -= 1;

        }
        /*if (other.CompareTag("Door") && keyCount == 0)
        {
            other.transform.parent.gameObject.SetActive(false);
        }*/

    }
}
