using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PoltergeisScript : MonoBehaviour
{
    public GameObject PoltertextObject;
    private bool isPlayerInside = false;

    [SerializeField] float moveSpeed = 5.0f;

    private Playercontroller playerController;
    private BoxCollider boxCollider;

    private TextMeshProUGUI PoltertextComponent;
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
        if (HideMode)
        {
            if (playerController != null)
            {
                playerController.enabled = false;
            }
            if (boxCollider != null)
            {
                boxCollider.isTrigger = true;
            }
            hidetextComponent.text = "Exit!!!!";
            MoveToTarget(nowPoint.position, InSidePoint.position);

        }
        else
        {
            if (playerController != null)
            {
                playerController.enabled = true;
            }
            if (boxCollider != null)
            {
                boxCollider.isTrigger = false;
            }
            nowPoint.LookAt(OutSidePoint);
            hidetextComponent.text = "Hide!!!!";
            MoveToTarget(nowPoint.position, OutSidePoint.position);

        }
    }
}