using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PoltergeisScript : MonoBehaviour
{
    public GameObject PoltertextObject;
    private bool isPlayerInside = false;

    private Playercontroller playerController;
    private BoxCollider boxCollider;

    private TextMeshProUGUI PoltertextComponent;

    public Animator animator; // Animator�R���|�[�l���g�ւ̎Q��
    public AnimationClip animationClip; // �Đ���������AnimationClip
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
            if (Input.GetKeyDown(KeyCode.Z))
            {
                Poltergeist();
            }

        }
    }
    void Poltergeist()
    {
        animator.Play(animationClip.name);
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Pol")
        {
            isPlayerInside = true;
            PoltertextObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isPlayerInside = false;
        PoltertextObject.SetActive(false);
    }
}