using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class BoxsummonScript : MonoBehaviour
{
    public GameObject Box;
    public Image UIobj;
    //public int Max_Value = 2;
    public float Next_Box_Time_Cooldown = 15f;

    //private int Current_Value;
    //private float Interval;
    private bool Interval_Check;

    public AudioClip Actionvc;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
       // Current_Value = Max_Value;
        Interval_Check = true;
        audioSource = GetComponent<AudioSource>();
        //Interval = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //if (!Interval_Check && Next_Box_Time_Cooldown < Interval) 
        //{
        //   Interval_Check = true;
        //    Interval = 0f;
        //}
        //else if(!Interval_Check && Next_Box_Time_Cooldown >= Interval)
        //    Interval += Time.deltaTime;
        
        if(Interval_Check)
        {
            if (Gamepad.current.xButton.wasPressedThisFrame)
            {
                Interval_Check = false;
                //Current_Value--;
                audioSource.PlayOneShot(Actionvc);
                GameObject box = Instantiate(Box, new Vector3(transform.position.x, 0f, transform.position.z - 1.2f), Quaternion.identity);
                StartCoroutine(StartCooldown());
            }
        }
        else
        {
            // UIの表示状態を制御
            UIobj.enabled = true;  // デフォルトは表示

            UIobj.fillAmount -= 1.0f / Next_Box_Time_Cooldown * Time.deltaTime;

            // UIobj.fillAmountが0より大きい場合はImageを表示（true）、そうでない場合は非表示（false）
            UIobj.enabled = UIobj.fillAmount > 0;
        }
    }

    IEnumerator StartCooldown()
    {
        yield return new WaitForSeconds(Next_Box_Time_Cooldown);
        UIobj.fillAmount = 1;
        Interval_Check = true;

        // カウントダウンが終了したのでImageを非表示にする
        UIobj.enabled = false;
    }
}
