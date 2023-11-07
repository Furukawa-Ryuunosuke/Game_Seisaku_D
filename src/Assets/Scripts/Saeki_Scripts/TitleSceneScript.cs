using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneScript : MonoBehaviour
{
    //===== ��`�̈� =====
    private Animator anim;  //Animator��anim�Ƃ����ϐ��Œ�`����

    private bool Put = false;
    private float Interval;
    public float ChangeTime = 1.2f;

    GameObject Image;

    //===== �������� =====
    void Start()
    {
        //�ϐ�anim�ɁAAnimator�R���|�[�l���g��ݒ肷��
        anim = gameObject.GetComponent<Animator>();
        Put = false;
        Interval = 0.0f;
        Image = GameObject.Find("TitleImage");
    }

    //===== �又�� =====
    void Update()
    {
        if (Input.anyKeyDown && !Put)
        {
            anim.SetBool("GetAnyKey", true);
            Put = true;
            Destroy(Image);
        }

        else if(Put)
        {
            Interval += Time.deltaTime;
        }

        if(Interval > ChangeTime)
        {
            SceneManager.LoadSceneAsync("SerectScene");
        }
    }
}
