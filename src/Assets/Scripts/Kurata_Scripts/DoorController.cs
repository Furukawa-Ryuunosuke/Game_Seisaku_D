using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int numberOfLocks = 3; // �싞���̐��i�K�X�ύX�j
    private int unlockedLocks = 0;

    public void UnlockLock()
    {
        unlockedLocks++;
        if (unlockedLocks >= numberOfLocks)
        {
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        Debug.Log("1");
        // �h�A���J���鏈���������ɋL�q����
    }
}
