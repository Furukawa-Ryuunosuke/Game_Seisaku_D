using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
            // プレイヤーがエリア内にいる場合の処理
            if (Input.GetKeyDown(KeyCode.Z))
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

            // 接触したオブジェクトの親オブジェクトを取得
            Transform parentTransform = col.transform.parent;

            // 親オブジェクトにアタッチされているAnimatorコンポーネントを取得
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