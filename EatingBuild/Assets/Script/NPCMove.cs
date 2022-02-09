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
        minObj = 1000;
        GoToNextPoint();
    }
    void GoToNextPoint()
    {        //eatObjectscriptと変数の値を統一する
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
        l_dis.Clear();


        if (0 <= p && p < obj3p)
        {
            objs = GameObject.FindGameObjectsWithTag("1p");
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
        }

        else if (obj3p <= p)
        {
            objs = GameObject.FindGameObjectsWithTag("3p");
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
        }

    }

    void MinFunction()
    {
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
    }
    void Update()
    {
        //エージェントの位置および現在の経路での目標地点の間の距離
        if (agent.remainingDistance >= 0.6f)
        {
            GoToNextPoint();
            Debug.LogError("GoToNextPoint");
        }
        else
        {
            agent.destination = objs[minIndex].transform.position;
            Debug.LogError("agent.destination");
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