using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float detectDistance;
    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    bool IsDetected = false;

    enum Move
    {
        Escape,
        Chase,
        Search,
        Stop,
    };

    Move EnemyMove;
    GameObject Light;
    EnemyLight LIghtTrigger;
    GameObject Visbility;
    EnemyVisibility VisbilityTrigger;


    void Start()
    {
        Light = GameObject.Find("LightTrigger");
        LIghtTrigger = Light.GetComponent<EnemyLight>();

        Visbility = GameObject.Find("VisbilityTrigger");
        VisbilityTrigger = Visbility.GetComponent<EnemyVisibility>();




        EnemyMove = Move.Search;

        agent = GetComponent<NavMeshAgent>();

        // autoBraking �𖳌��ɂ���ƁA�ڕW�n�_�̊Ԃ��p���I�Ɉړ�
       
        agent.autoBraking = false;

        GotoNextPoint();
    }
    void GotoNextPoint()
    {
        // �n�_���Ȃɂ��ݒ肳��Ă��Ȃ��Ƃ��ɕԂ�
        if (points.Length == 0)
            return;

        // �G�[�W�F���g�����ݐݒ肳�ꂽ�ڕW�n�_�ɍs���悤�ɐݒ�
        agent.destination = points[destPoint].position;

        // �z����̎��̈ʒu��ڕW�n�_�ɐݒ�
        destPoint++;

        if (points.Length == destPoint)
        {
            destPoint = 0;
        }
    }

    void ChangeMove()
    {
        if (LIghtTrigger.lightEnter)
        {
            EnemyMove = Move.Search;
        }
        else
        {
            EnemyMove = Move.Search;
        }
        if (VisbilityTrigger.visbilityEnter)
        {
            EnemyMove = Move.Chase;
        }
        else
        {
            EnemyMove = Move.Search;
        }







    }





    // Update is called once per frame
    void Update()
    {
        float distance = 0;
       
        distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance <= detectDistance)
        {
            IsDetected = true;
        }
        else
        {
            IsDetected = false;
        }
        if (!IsDetected)
        {
            // �G�[�W�F���g�����ڕW�n�_�ɋ߂Â��Ă�����A
            // ���̖ڕW�n�_��I�����܂�
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
                GotoNextPoint();
        }
        else if (player)
        {
            agent.destination = player.transform.position;
        }
    }
}
