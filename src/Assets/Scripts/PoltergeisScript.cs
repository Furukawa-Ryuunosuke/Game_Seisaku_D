using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoltergeisScript : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float distance = 0.8f;    // ���o�\�ȋ���

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Ray�̓J�����̈ʒu����Ƃ΂�
        var rayStartPosition = player.transform.position;
        // Ray�̓J�����������Ă�����ɂƂ΂�
        var rayDirection = player.transform.forward.normalized;

        // Hit�����I�u�W�F�N�g�i�[�p
        RaycastHit raycastHit;

        // Ray���΂��iout raycastHit ��Hit�����I�u�W�F�N�g���擾����j
        var isHit = Physics.Raycast(rayStartPosition, rayDirection, out raycastHit, distance);

        // Debug.DrawRay (Vector3 start(ray���J�n����ʒu), Vector3 dir(ray�̕����ƒ���), Color color(���C���̐F));
        Debug.DrawRay(rayStartPosition, rayDirection * distance, Color.red);

        // �Ȃɂ������o������
        if (isHit)
        {
           // Debug.Log("A");
            // Log��Hit�����I�u�W�F�N�g�����o��
            Debug.Log("HitObject : " + raycastHit.collider.gameObject.name);
            if (raycastHit.collider.CompareTag("Vase"))
            {
               // Debug.Log("B");
                if (Input.GetKeyDown(KeyCode.Z))
                {
                   // Debug.Log("C");
                    var vaseRb = raycastHit.collider.gameObject.GetComponent<Rigidbody>();
                    if (vaseRb != null)
                    {
                        vaseRb.velocity = new Vector3(1f, 0, 0);
                        //Debug.Log("aA");
                    }
                }

            }
           /* else if (raycastHit.collider.CompareTag("Hide"))
            {
               // Debug.Log("BB");
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    Transform hitTransform = raycastHit.transform;
                    Debug.Log("HitObject's Transform: " + hitTransform.name);

                    BoxCollider boxCollider = raycastHit.collider.gameObject.GetComponent<BoxCollider>();
                    if (boxCollider != null)
                    {
                        boxCollider.isTrigger = true;
                    }
                    GetComponent<Playercontroller>().enabled = false;

                }
            }*/
        }
    }
}