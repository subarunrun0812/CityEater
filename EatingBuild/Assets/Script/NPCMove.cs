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

    [SerializeField] private List<float> l_dis1p = new List<float>();

    private float minObj1p;//最も近いオブジェクトの距離感
    private int minIndex1p;//最も近いオブジェクトのインデックス
    private Vector3 _destination;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //目標地点に近づいても速度を落とさなくなる
        agent.autoBraking = false;
        minObj1p = 1000;
        GoToNextPoint();
    }

    void GoToNextPoint()
    {
        agent.isStopped = false;
        p = npceat.point;
        l_dis1p.Clear();

        // GameObject.Find("ゲームタグ名")で見つけたオブジェクトを配列に格納し、その格納したやつをfor文を使ってListに格納します。
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
        _destination = arrayobjs1p[minIndex1p].transform.position;
        float min = l_dis1p.Min();
        Debug.Log("min : " + min);
    }

    void Update()
    {
        agent.destination = _destination;

        if (agent.remainingDistance <= 1.2f)
        {
            GoToNextPoint();
            Debug.LogWarning("近い:目的地の1.2fより近い StopHere");
            //     // GoToNextPoint();
        }
    }
    // IEnumerator DestinationWaitTime()
    // {
    //     Debug.LogWarning("コルーチンが呼ばれた");
    //     yield return new WaitForSeconds(5);
    //     // //エージェントの位置および現在の経路での目標地点の間の距離

    // }

    void StopHere()
    {
        Debug.LogWarning("Stop");
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
        // else if (collider.CompareTag("NPC"))//NPCと近くにいた(衝突した)時
        // {
        //     NPCEatObjectScript otherNPC = collider.GetComponent<NPCEatObjectScript>();
        //     if (npceat.npc_level > otherNPC.point)//npcとplayerが同じレベルなら追いかける
        //     {
        //         agent.destination = collider.transform.position;
        //     }
        //     else if (npceat.npc_level < otherNPC.point)
        //     {
        //         agent.destination = -collider.transform.position;//playerと反対方向にいく
        //     }
        // }
    }
}