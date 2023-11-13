using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class PoltergeisScript : MonoBehaviour
{
    public GameObject PoltertextObject;
    private bool isPlayerInside = false;

    private TextMeshProUGUI PoltertextComponent;

    private Animator parentAnimator;

    private SphereCollider sphereCollider;
    // Start is called before the first frame update
    void Start()
    {
        PoltertextObject.SetActive(false);
        PoltertextComponent = PoltertextObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInside)
        {
            // �v���C���[���G���A���ɂ���ꍇ�̏���
            if (Gamepad.current.buttonSouth.wasReleasedThisFrame)// || Input.GetKeyDown(KeyCode.Z)
            {
                if (parentAnimator != null)
                {
                    parentAnimator.SetBool("isFall", true);
                    PoltertextObject.SetActive(false);
                    if (sphereCollider != null)
                    {
                        sphereCollider.enabled = true;
                    }
                }
            }

        }
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Pol")
        {
            isPlayerInside = true;
            PoltertextObject.SetActive(true);

            // �ڐG�����I�u�W�F�N�g�̐e�I�u�W�F�N�g���擾
            Transform parentTransform = col.transform.parent;

            // �e�I�u�W�F�N�g�ɃA�^�b�`����Ă���Animator�R���|�[�l���g���擾
            parentAnimator = parentTransform.GetComponent<Animator>();

            Transform FallCpllider = parentTransform.GetChild(4);
            Debug.Log(FallCpllider);
            sphereCollider = FallCpllider.GetComponent<SphereCollider>();

        }
    }

    private void OnTriggerExit(Collider other)
    {
        isPlayerInside = false;
        PoltertextObject.SetActive(false);
    }
}