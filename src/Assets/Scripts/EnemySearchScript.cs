using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySearchScript : MonoBehaviour
{
    [Header("プレイヤーのオブジェクトぶち込む")]
    [SerializeField] GameObject player;

    [Space]
    [Header("行動速度 (0.1f～)")]
    public float Speed = 0.9f;

    [Space]
    [Header("巡回場所の数及び座標")]
    public Transform[] Waypoints;

    [Space]
    [Header("固定的の初期方向 (-180～180)")]
    public float StayRotation_y;

    [Space]
    [Header("周囲確認の振れ幅　(0.1f～)")]
    public float StopRotation = 0.0f;


    [Space]
    [Header("追跡の継続時間 (0.1f～)")]
    public float ChaseInterval = 2.0f;

    [Space]
    [Header("行動後の待機時間 (0.1f～)")]
    public float StopInterval = 3.0f;

    [Space]
    [Header("所持アイテム")]
    public GameObject DropItem;

    private int destPoint = 0;
    private NavMeshAgent agent;
    private float Interval;

    enum Move
    {
        None,
        Light,
        Escape,
        Chase,
        Search,
        Stop,
    };

    Move EnemyMove, BeforeMove;

    [Space]
    [Header("トリガーの名称はすべて分けてほしい")]
    [SerializeField] GameObject Light;
    EnemyLight _LIghtTrigger;
    [SerializeField] GameObject Visbility;
    EnemyVisibility _VisbilityTrigger;
    [SerializeField] GameObject Behind;
    BehindArea _BehindTrigger;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // autoBraking を無効にすると、目標地点の間を継続的に移動

        agent.autoBraking = false;

        _LIghtTrigger = Light.GetComponent<EnemyLight>();

        _VisbilityTrigger = Visbility.GetComponent<EnemyVisibility>();

        _BehindTrigger = Behind.GetComponent<BehindArea>();

        EnemyMove = Move.Search;
        BeforeMove = Move.None;

        destPoint = 0;
        agent.destination = Waypoints[destPoint].position;
        agent.speed = Speed;    
    }
    void ChangeMove()
    {
        if (_LIghtTrigger.lightEnter && EnemyMove != Move.Escape)
        {
            EnemyMove = Move.Light;
            return;
        }

        if (_VisbilityTrigger.visbilityEnter && EnemyMove != Move.Escape)
        {
            if (BeforeMove != Move.Light)
                EnemyMove = Move.Chase;
            return;
        }

        if (_BehindTrigger.behindEnter)
        {
            EnemyMove = Move.Escape;
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        ChangeMove();

        if (EnemyMove == Move.Escape)
        {
            EscapeCommand();
        }

        else if (EnemyMove == Move.Stop)
        {
            StopCommand();
        }

        else if (EnemyMove == Move.Light)
        {
            LightCommand();
        }

        else if (EnemyMove == Move.Chase)
        {
            ChaseCommand();
        }

        else if (EnemyMove == Move.Search)
        {
            SearchCommand();
        }

        Debug.Log(EnemyMove, gameObject);

        BeforeMove = EnemyMove;
    }

    void SearchCommand()
    {
        if (BeforeMove != EnemyMove)
        {
            Interval = 0.0f;
        }

        if (agent.speed != Speed)
            agent.speed = Speed;
        if (BeforeMove != EnemyMove)
            agent.destination = Waypoints[destPoint].position;
        // エージェントが現目標地点に近づいてきたら次の目標地点を選択
        if (!agent.pathPending && agent.remainingDistance < 0.8f)
            GotoNextPoint();
    }

    void ChaseCommand()
    {
        if (BeforeMove != EnemyMove)
        {
            Interval = 0.0f;
        }

        if (agent.speed != Speed)
            agent.speed = Speed;

        if (!_VisbilityTrigger.visbilityEnter)
            Interval += Time.deltaTime;
        else
            Interval = 0.0f;

        agent.destination = player.transform.position;

        if (!_VisbilityTrigger.visbilityEnter && Interval > ChaseInterval)
        {
            Interval = 0.0f;
            EnemyMove = Move.Stop;
        }
    }

    void LightCommand()
    {
        if (BeforeMove != EnemyMove)
        {
            Interval = 0.0f;
        }

        agent.speed = 0.0f;

        // ターゲットへの向きベクトル計算
        var dir = player.transform.position - transform.position;

        // ターゲットの方向への回転
        transform.rotation = Quaternion.LookRotation(dir, Vector3.up);

        //transform.rotation = Quaternion.Euler(0, transform.rotation.y, 0);

        //agent.destination = transform.position;

        if (!_LIghtTrigger.lightEnter && !_VisbilityTrigger.visbilityEnter)
        {
            EnemyMove = Move.Stop;
        }
    }

    void StopCommand()
    {
        if (BeforeMove != EnemyMove)
        {
            Interval = 0.0f;
        }

        agent.destination = transform.position;
        Interval += Time.deltaTime;

        if (Interval - StopInterval < 0)
        {
            if (StopInterval - Interval >= StopInterval * 3.0f / 4.0f)
                transform.Rotate(new Vector3(0, StopRotation, 0));

            else if (StopInterval - Interval >= StopInterval / 4.0f)
                transform.Rotate(new Vector3(0, -StopRotation, 0));

            else
                transform.Rotate(new Vector3(0, StopRotation, 0));
        }
        else
        {
            Interval = 0.0f;
            agent.destination = Waypoints[destPoint].position;
            EnemyMove = Move.Search;
        }

    }

    void EscapeCommand()
    {
        if (BeforeMove != EnemyMove)
        {
            Interval = 0.0f;

            agent.speed = 2.0f;
            Destroy(gameObject, 5.0f);
            agent.destination = transform.position - (player.transform.position - transform.position) * 2;
        }
        if (DropItem && BeforeMove != EnemyMove)
            CreateItem();
    }

    void CreateItem()
    {
        GameObject obj = Instantiate(DropItem, transform.position, Quaternion.identity);
    }

    void GotoNextPoint()
    {
        // 地点がなにも設定されていないときに返す
        if (Waypoints.Length == 0)
            return;

        if (Waypoints.Length == 1)
        {
            transform.rotation = Quaternion.Euler(0, StayRotation_y, 0);
            EnemyMove = Move.Stop;
            return;
        }

        // 配列内の次の位置を目標地点に設定
        destPoint++;

        // 一巡したら最初の地点に移動
        if (Waypoints.Length == destPoint)
        {
            destPoint = 0;
        }

        // エージェントが現在設定された目標地点に行くように設定
        agent.destination = Waypoints[destPoint].position;
    }

}
