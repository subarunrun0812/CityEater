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
    [SerializeField] private NPCEatObjectScript npceat;
    private int p;
    [SerializeField] GameManager gameManager;

    //位置の基準になるオブジェクトのTransformを収める
    public Transform central;
    private NavMeshAgent agent;
    [SerializeField] private EatObjectScript eatObj;
    [SerializeField] private GameObject npc_crown;
    [SerializeField] private GameObject[] objs;
    [SerializeField] private List<float> l_dis = new List<float>();
    private float minObj;//最も近いオブジェクトの距離感
    private int minIndex;//最も近いオブジェクトのインデックス
    private float subMinObj;//比較用最も近いオブジェクト


    private GameObject destination;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //目標地点に近づいても速度を落とさなくなる
        agent.autoBraking = false;

        GoToNextPoint();
    }
    void GoToNextPoint()
    {
        objs = GameObject.FindGameObjectsWithTag("1p");
        l_dis.Clear();
        minObj = 1000;
        foreach (GameObject item in objs)//距離感を求めリストに格納する
        {
            float dis = Vector3.Distance(this.transform.position, item.transform.position);
            // Debug.Log("distance : " + dis);
            l_dis.Add(dis);
        }
        foreach (int item in l_dis)//リストの最大値とそのインデックスを求める
        {
            if (minObj > l_dis[item])
            {
                minObj = l_dis[item];
                minIndex = item;//インデックス
                Debug.Log("minObj : " + minObj);
            }
        }

        float min = l_dis.Min();
        Debug.Log("min : " + min);
        // l_dis.Sort();
        // l_dis[] =
    }
    void Update()
    {
        //エージェントの位置および現在の経路での目標地点の間の距離
        if (agent.remainingDistance >= 0.1f)
        {
            GoToNextPoint();
        }
        else
        {
            agent.destination = objs[minIndex].transform.position;
        }
    }



















    void OnDisable()
    {
        npc_crown.SetActive(false);
    }

    //CollisionDetectorのonTriggerStayにセットし、衝突判定を受け取るメソッド
    public void OnDetectObject(Collider collider)
    {
        p = npceat.point;
        //衝突したオブジェクトにPlayerタグが付いていれば、そのオブジェクトを追いかける
        if (collider.CompareTag("Player"))
        {
            if (npceat.npc_level > eatObj.level)//npcとplayerが同じレベルなら追いかける
            {
                agent.destination = collider.transform.position;
            }
            else
            {
                agent.destination = -collider.transform.position;//playerと反対方向にいく
            }
        }
    }
}