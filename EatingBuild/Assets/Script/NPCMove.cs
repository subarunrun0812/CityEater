using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//NavMeshAgent使うときに必要
using UnityEngine.AI;
using System.Linq;

//オブジェクトにNavMeshAgentコンポーネントを設置
[RequireComponent(typeof(NavMeshAgent))]

public class NPCMove : MonoBehaviour
{
    //設定した待機時間
    [SerializeField] float waitTime;
    //待機時間を数える
    [SerializeField] float time = 0;
    [SerializeField] private NPCEatObjectScript npceat;
    private int p;
    [SerializeField] GameManager gameManager;

    //位置の基準になるオブジェクトのTransformを収める
    public Transform central;
    private NavMeshAgent agent;
    [SerializeField] private EatObjectScript eatObj;
    [SerializeField] private GameObject npc_crown;
    private GameObject[] arrayobjs1p;
    // private GameObject[] arrayobjs4p;
    // private GameObject[] arrayobjs2p;
    // private GameObject[] arrayobjs3p;
    // private GameObject[] arrayobjs4p;
    // private GameObject[] arrayobjs4p;
    // private GameObject[] arrayobjs8p;
    // private GameObject[] arrayobjs10p;
    // private GameObject[] arrayobjs12p;
    // private GameObject[] arrayobjs15p;
    // private GameObject[] arrayobjs20p;
    // private GameObject[] arrayobjs30p;
    // private GameObject[] arrayobjs50p;
    [SerializeField] private List<float> l_dis1p = new List<float>();
    // [SerializeField] private List<float> l_dis4p = new List<float>();

    private float minObj1p;//最も近いオブジェクトの距離感
    // private float minObj4p;
    private int minIndex1p;//最も近いオブジェクトのインデックス
    // private int minIndex4p;
    private GameObject destination;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //目標地点に近づいても速度を落とさなくなる
        agent.autoBraking = false;
        minObj1p = 1000;
        // minObj4p = 1000;
        GoToNextPoint();

        // arrayobjs2p = GameObject.FindGameObjectsWithTag("2p");
        // arrayobjs3p = GameObject.FindGameObjectsWithTag("3p");
        // arrayobjs4p = GameObject.FindGameObjectsWithTag("4p");
        // arrayobjs4p = GameObject.FindGameObjectsWithTag("5p");
        // arrayobjs8p = GameObject.FindGameObjectsWithTag("8p");
        // arrayobjs10p = GameObject.FindGameObjectsWithTag("10p");
        // arrayobjs12p = GameObject.FindGameObjectsWithTag("12p");
        // arrayobjs15p = GameObject.FindGameObjectsWithTag("15p");
        // arrayobjs20p = GameObject.FindGameObjectsWithTag("20p");
        // arrayobjs30p = GameObject.FindGameObjectsWithTag("30p");
        // arrayobjs50p = GameObject.FindGameObjectsWithTag("50p");
    }
    void GoToNextPoint()
    {
        //eatObjectscriptと変数の値を統一する
        int obj2p = eatObj.obj2p;
        int obj3p = eatObj.obj3p;
        int obj4p = eatObj.obj4p;
        int obj5p = eatObj.obj5p;
        int obj8p = eatObj.obj8p;
        int obj10p = eatObj.obj10p;
        int obj12p = eatObj.obj12p;
        int obj15p = eatObj.obj15p;
        int obj20p = eatObj.obj20p;
        int obj30p = eatObj.obj30p;
        int obj50p = eatObj.obj50p;
        agent.isStopped = false;
        p = npceat.point;
        l_dis1p.Clear();
        // l_dis4p.Clear();

        // GameObject.Find("ゲームタグ名")で見つけたオブジェクトを配列に格納し、その格納したやつをfor文を使ってListに格納します。
        if (0 <= p)
        {
            arrayobjs1p = GameObject.FindGameObjectsWithTag("1p");
            foreach (GameObject item in arrayobjs1p)//距離感を求めリストに格納する
            {
                float dis = Vector3.Distance(this.transform.position, item.transform.position);
                // Debug.Log("distance : " + dis);
                l_dis1p.Add(dis);
            }
            foreach (int item in l_dis1p)//リストの最大値とそのインデックスを求める
            {
                if (minObj1p > l_dis1p[item])
                {
                    minObj1p = l_dis1p[item];
                    minIndex1p = item;//インデックス
                    Debug.Log("minObj1p : " + minObj1p);
                }
            }
            agent.destination = arrayobjs1p[minIndex1p].transform.position;
            float min = l_dis1p.Min();
            Debug.Log("min : " + min);
        }
        // else if (obj4p <= p)
        // {
        //     Debug.LogWarning("obj4p <= p");
        //     arrayobjs4p = GameObject.FindGameObjectsWithTag("4p");
        //     foreach (GameObject item in arrayobjs4p)//距離感を求めリストに格納する
        //     {
        //         float dis = Vector3.Distance(this.transform.position, item.transform.position);
        //         Debug.LogWarning("最初のforeach");
        //         l_dis4p.Add(dis);
        //     }
        //     foreach (int item in l_dis4p)//リストの要素の最小値とそのインデックスを求める
        //     {
        //         Debug.LogWarning("2つ目のforeachの最初");
        //         if (minObj4p > l_dis4p[item])
        //         {
        //             minObj4p = l_dis4p[item];
        //             minIndex4p = item;//インデックス
        //             Debug.Log("minObj4p : " + minObj4p);
        //             Debug.LogWarning("2つ目のforeach");
        //         }
        //     }
        //     Debug.LogWarning("目的地が設定できていないよ");

        //     Debug.LogWarning("agent.destination : " + agent.destination);
        //     float min = l_dis4p.Min();
        // }
    }
    void Update()
    {
        //eatObjectscriptと変数の値を統一する
        int obj2p = eatObj.obj2p;
        int obj3p = eatObj.obj3p;
        int obj4p = eatObj.obj4p;
        int obj5p = eatObj.obj5p;
        int obj8p = eatObj.obj8p;
        int obj10p = eatObj.obj10p;
        int obj12p = eatObj.obj12p;
        int obj15p = eatObj.obj15p;
        int obj20p = eatObj.obj20p;
        int obj30p = eatObj.obj30p;
        int obj50p = eatObj.obj50p;
        p = npceat.point;

        //エージェントの位置および現在の経路での目標地点の間の距離
        if (agent.remainingDistance >= 0.8f)
        {
            Debug.LogWarning("遠い:目的地の0.8fより遠いGoToNextPoint");
            GoToNextPoint();

        }
        else
        {
            Debug.LogWarning("近い:目的地の0.8fより近いStopHere");
            StopHere();
        }

        // else if (obj4p <= p)
        // {
        //     //エージェントの位置および現在の経路での目標地点の間の距離
        //     if (agent.remainingDistance >= 0.8f)
        //     {
        //         GoToNextPoint();
        //     }
        //     else
        //     {
        //         agent.SetDestination(arrayobjs4p[minIndex4p].transform.position);
        //     }
        // }
    }

    void StopHere()
    {
        Debug.LogError("Stop");
        //NavMeshAgentを止める
        agent.isStopped = true;
        //待ち時間を数える
        time += Time.deltaTime;

        //待ち時間が設定された数値を超えると発動
        if (time > waitTime)
        {
            //目標地点を設定し直す
            GoToNextPoint();
            time = 0;
        }
    }

    void OnDisable()
    {
        npc_crown.SetActive(false);
    }

    //CollisionDetectorのonTriggerStayにセットし、衝突判定を受け取るメソッド
    public void OnDetectObject(Collider collider)
    {
        //衝突したオブジェクトにPlayerタグが付いていれば、そのオブジェクトを追いかける
        if (collider.CompareTag("Player"))
        {
            if (npceat.npc_level > eatObj.level)//npcとplayerが同じレベルなら追いかける
            {
                agent.destination = collider.transform.position;
            }
            else if (npceat.npc_level < eatObj.level)
            {
                agent.destination = -collider.transform.position;//playerと反対方向にいく
            }
        }
    }
}