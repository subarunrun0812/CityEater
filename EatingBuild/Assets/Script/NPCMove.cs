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
    [SerializeField] private float waitTime;
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

    [SerializeField] private List<float> l_dis1p = new List<float>();

    private float minObj1p;//最も近いオブジェクトの距離感
    private int minIndex1p;//最も近いオブジェクトのインデックス
    private Vector3 _destination;
    [SerializeField] private GameObject player;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //目標地点に近づいても速度を落とさなくなる
        agent.autoBraking = false;
        minObj1p = 1000;
    }
    //     GoToNextPoint();
    // }

    // void GoToNextPoint()
    // {
    //     agent.isStopped = false;
    //     p = npceat.point;
    //     l_dis1p.Clear();

    //     // GameObject.Find("ゲームタグ名")で見つけたオブジェクトを配列に格納し、その格納したやつをfor文を使ってListに格納します。
    //     arrayobjs1p = GameObject.FindGameObjectsWithTag("1p");
    //     foreach (GameObject item in arrayobjs1p)//距離感を求めリストに格納する
    //     {
    //         float dis = Vector3.Distance(this.transform.position, item.transform.position);
    //         // Debug.Log("distance : " + dis);
    //         l_dis1p.Add(dis);
    //     }
    //     foreach (int item in l_dis1p)//リストの最大値とそのインデックスを求める
    //     {
    //         if (minObj1p > l_dis1p[item])
    //         {
    //             minObj1p = l_dis1p[item];
    //             minIndex1p = item;//インデックス
    //             Debug.Log("minObj1p : " + minObj1p);
    //         }
    //     }
    //     _destination = arrayobjs1p[minIndex1p].transform.position;
    //     float min = l_dis1p.Min();
    //     Debug.Log("min : " + min);
    // }

    void Update()
    {

        if (agent.remainingDistance <= 1f)
        {
            Debug.LogWarning("remainingDistance : " + agent.remainingDistance);

            //     // GoToNextPoint();
            StopHere();
        }
    }


    void StopHere()
    {

        Debug.LogWarning("Stop");
        //NavMeshAgentを止める
        // agent.isStopped = true;
        //待ち時間を数える
        time += Time.deltaTime;

        //待ち時間が設定された数値を超えると発動
        if (time > waitTime)
        {
            //目標地点を設定し直す
            agent.destination = player.transform.position;
            time = 0;
        }
    }
    // // IEnumerator DestinationWaitTime()
    // // {
    // //     Debug.LogWarning("コルーチンが呼ばれた");
    // //     yield return new WaitForSeconds(5);
    // //     // //エージェントの位置および現在の経路での目標地点の間の距離

    // // }

    void OnDisable()
    {
        npc_crown.SetActive(false);
    }

    //CollisionDetectorのonTriggerStayにセットし、衝突判定を受け取るメソッド
    public void OnDetectObject(Collider collider)
    {
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
        int objover1 = eatObj.objover1;
        int objover2 = eatObj.objover2;
        int objover3 = eatObj.objover3;
        int objover4 = eatObj.objover4;
        int objover5 = eatObj.objover5;
        int objover6 = eatObj.objover6;
        int objoverMax = eatObj.objoverMax;

        //衝突したオブジェクトにPlayerタグが付いていれば、そのオブジェクトを追いかける
        if (collider.CompareTag("Player"))
        {
            if (npceat.npc_level > eatObj.level)//npcとplayerが同じレベルなら追いかける
            {
                agent.destination = collider.transform.position;
                Debug.LogError("追いかける:Playerを追いかける");
            }
            // else if (npceat.npc_level <= eatObj.level)
            // {
            //     agent.destination = -collider.transform.position;//playerと反対方向にいく
            //     Debug.LogError("逃げる:Playerから逃げる");
            // }
        }
        else if (collider.CompareTag("AT"))
        {
            agent.destination = collider.transform.position;
        }
        else if (collider.CompareTag("INCR"))
        {
            agent.destination = collider.transform.position;
        }
        else if (collider.CompareTag("QUESTION"))
        {
            agent.destination = collider.transform.position;
        }
        else
        {

            //Playerの大きさをポイントに応じて変更する
            int p = npceat.point;

            if (p < obj5p)
            {
                if (collider.CompareTag("1p"))
                {
                    agent.destination = collider.transform.position;
                }
                else if (collider.CompareTag("2p"))
                {
                    agent.destination = collider.transform.position;
                }
            }
            else if (obj5p <= p && p < obj15p)
            {
                if (collider.CompareTag("3p"))
                {
                    agent.destination = collider.transform.position;
                }
                else if (collider.CompareTag("4p"))
                {
                    agent.destination = collider.transform.position;
                }
                else if (collider.CompareTag("5p"))
                {
                    agent.destination = collider.transform.position;
                }

            }
            else if (obj15p <= p && p < objover1)
            {
                if (collider.CompareTag("5p"))
                {
                    agent.destination = collider.transform.position;
                }
                else if (collider.CompareTag("8p"))
                {
                    agent.destination = collider.transform.position;
                }
                else if (collider.CompareTag("10p"))
                {
                    agent.destination = collider.transform.position;
                }
                else if (collider.CompareTag("12p"))
                {
                    agent.destination = collider.transform.position;
                }

            }
            else if (objover1 <= p)
            {

                if (collider.CompareTag("15p"))
                {
                    agent.destination = collider.transform.position;
                }
                else if (collider.CompareTag("20p"))
                {
                    agent.destination = collider.transform.position;
                }
                else if (collider.CompareTag("30p"))
                {
                    agent.destination = collider.transform.position;
                }
                else if (collider.CompareTag("50p"))
                {
                    agent.destination = collider.transform.position;
                }

            }

        }
    }
}
